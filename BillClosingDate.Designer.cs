
namespace SISCOFIN_v1
{
    partial class BillClosingDate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbCloseDate = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.dpCloseDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbCloseDate
            // 
            this.lbCloseDate.AutoSize = true;
            this.lbCloseDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCloseDate.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbCloseDate.Location = new System.Drawing.Point(18, 9);
            this.lbCloseDate.Name = "lbCloseDate";
            this.lbCloseDate.Size = new System.Drawing.Size(165, 15);
            this.lbCloseDate.TabIndex = 6;
            this.lbCloseDate.Text = "Data de fechamento da fatura";
            // 
            // btOK
            // 
            this.btOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btOK.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.ForeColor = System.Drawing.Color.DarkGreen;
            this.btOK.Location = new System.Drawing.Point(50, 63);
            this.btOK.Margin = new System.Windows.Forms.Padding(15);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(100, 23);
            this.btOK.TabIndex = 5;
            this.btOK.Text = "Ok";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.Click_btOK);
            // 
            // dpCloseDate
            // 
            this.dpCloseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpCloseDate.Location = new System.Drawing.Point(54, 29);
            this.dpCloseDate.Name = "dpCloseDate";
            this.dpCloseDate.Size = new System.Drawing.Size(93, 20);
            this.dpCloseDate.TabIndex = 0;
            // 
            // BillClosingDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(200, 100);
            this.Controls.Add(this.lbCloseDate);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dpCloseDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillClosingDate";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillClosingDate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbCloseDate;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.DateTimePicker dpCloseDate;
    }
}