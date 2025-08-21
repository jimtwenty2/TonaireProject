using System.Configuration;
using Microsoft.Data.SqlClient;
namespace TonaireProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // if conneted : Open Form
            if (isConnectedToDb())
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            
        }
        // Check can connect to db or not
        static bool isConnectedToDb()
        {
            string connString = ConfigDb.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Cannot connect to the database", "Connection to Datebase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.LogError(ex);
                    return false;
                }
            }
        } 
    }
}