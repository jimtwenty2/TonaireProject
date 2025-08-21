using System.IO;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Model;
using Microsoft.Data.SqlClient;

namespace TonaireProject
{
    public partial class Form1 : Form
    {
        private string _connectionString = ConfigDb.ConnectionString;
        public Form1()
        {
            InitializeComponent();
            btnGenerate.Click += onClickbtnGenerate;
            btnExport.Click += onClickbtnExport;
        }

        private void onClickbtnExport(object? sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            string productNameFilter = txtProductName.Text.Trim();

            var sales = getSales(startDate, endDate, productNameFilter);

            if (sales == null || sales.Count == 0)
            {
                MessageBox.Show("No result to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XtraReport report = new SalesReport();
            report.DataSource = sales;
            report.DataMember = "";

            if (report.Parameters["StartDate"] != null && report.Parameters["EndDate"] != null)
            {
                report.Parameters["StartDate"].Value = dtpStartDate.Value.Date;
                report.Parameters["EndDate"].Value = dtpEndDate.Value.Date;
                // hide the parameter promt
                report.Parameters["StartDate"].Visible = false;
                report.Parameters["EndDate"].Visible = false;
            }

            // Get project root
            string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;

            // Ensure ReportPdf folder exists
            string exportFolder = Path.Combine(projectRoot, "ReportPdf");
            Directory.CreateDirectory(exportFolder);

            // Construct PDF path
            string safeProductName = string.IsNullOrEmpty(productNameFilter)
                                        ? "AllProducts"
                                        : productNameFilter;
            string pdfFileName = $"SalesReport_{safeProductName}_{dtpStartDate.Value:yyyyMMdd}_to_{dtpEndDate.Value:yyyyMMdd}.pdf";
            string pdfPath = Path.Combine(exportFolder, pdfFileName);

            // Export
            report.ExportToPdf(pdfPath);

            MessageBox.Show($"Report exported successfully to :\n{pdfPath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onClickbtnGenerate(object? sender, EventArgs e)
        {
            // Value that selected bu user from Datetime Picker
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            string productNameFilter = txtProductName.Text.Trim();
            var sales = getSales(startDate, endDate, productNameFilter);

            // Pass data to the report
            ShowReport(sales);
        }
        private void ShowReport(List<SaleDto> sales)
        {
            if (sales == null || sales.Count == 0)
            {
                MessageBox.Show("No result to show as a Report", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XtraReport report = new SalesReport();
            report.DataSource = sales;
            report.DataMember = "";

            if (report.Parameters["StartDate"] != null && report.Parameters["EndDate"] != null)
            {
                report.Parameters["StartDate"].Value = dtpStartDate.Value.Date;
                report.Parameters["EndDate"].Value = dtpEndDate.Value.Date;
                // hide the parameter promt
                report.Parameters["StartDate"].Visible = false;
                report.Parameters["EndDate"].Visible = false;
            }

            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreview();
        }

        public List<SaleDto> getSales(DateTime startDate, DateTime endDate, String productName)
        {
            var sales = new List<SaleDto>();

            /* raw sql
            string sql = @"
            SELECT ProductCode, ProductName, Quantity, UnitPrice, SaleDate
            FROM ProductSales
            WHERE SaleDate BETWEEN @StartDate AND @EndDate
            ORDER BY ProductCode, SaleDate;
            ";
            */

            // using StoreProcedured
            string spName = "sp_GetSalesByDateOpName";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(spName, con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(productName) ? (object)DBNull.Value : productName);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.Add(new SaleDto(
                                reader["ProductCode"].ToString(),
                                reader["ProductName"].ToString(),
                                Convert.ToInt32(reader["Quantity"]),
                                Convert.ToDouble(reader["UnitPrice"]),
                                Convert.ToDateTime(reader["SaleDate"])
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.LogError(ex);
                    MessageBox.Show("Error occured", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                return sales;
            }

        }
    }
 }
