namespace TonaireProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnGenerate = new Button();
            label3 = new Label();
            btnExport = new Button();
            label4 = new Label();
            txtProductName = new TextBox();
            SuspendLayout();
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(77, 208);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 27);
            dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(77, 277);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 27);
            dtpEndDate.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 182);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 2;
            label1.Text = "Start date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 251);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 3;
            label2.Text = "End date";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(198, 330);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(129, 29);
            btnGenerate.TabIndex = 4;
            btnGenerate.Text = "Generate Report";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(121, 126);
            label3.Name = "label3";
            label3.Size = new Size(169, 28);
            label3.TabIndex = 5;
            label3.Text = "Generate Report";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(77, 330);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 29);
            btnExport.TabIndex = 6;
            btnExport.Text = "Export PDF";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(77, 46);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 7;
            label4.Text = "Product Name :";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(80, 73);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(247, 27);
            txtProductName.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 423);
            Controls.Add(txtProductName);
            Controls.Add(label4);
            Controls.Add(btnExport);
            Controls.Add(label3);
            Controls.Add(btnGenerate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label1;
        private Label label2;
        private Button btnGenerate;
        private Label label3;
        private Button btnExport;
        private Label label4;
        private TextBox txtProductName;
    }
}
