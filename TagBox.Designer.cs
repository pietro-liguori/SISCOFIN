
using System.ComponentModel;

namespace SISCOFIN_v1
{
    partial class TagBox
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TagFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.TagSource = new System.Windows.Forms.ComboBox();
            this.Title = new System.Windows.Forms.Label();
            this.Subtitle = new System.Windows.Forms.Label();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TagFlow
            // 
            this.TagFlow.AutoSize = true;
            this.TagFlow.BackColor = System.Drawing.SystemColors.Window;
            this.TagFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.TagFlow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TagFlow.Location = new System.Drawing.Point(0, 0);
            this.TagFlow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TagFlow.MinimumSize = new System.Drawing.Size(0, 27);
            this.TagFlow.Name = "TagFlow";
            this.TagFlow.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.TagFlow.Size = new System.Drawing.Size(174, 27);
            this.TagFlow.TabIndex = 2;
            this.TagFlow.Click += new System.EventHandler(this.DropList);
            this.TagFlow.Resize += new System.EventHandler(this.TagsResize);
            // 
            // ComboBox
            // 
            this.TagSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.TagSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TagSource.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TagSource.FormattingEnabled = true;
            this.TagSource.Location = new System.Drawing.Point(0, 27);
            this.TagSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TagSource.Name = "ComboBox";
            this.TagSource.Size = new System.Drawing.Size(174, 25);
            this.TagSource.TabIndex = 0;
            this.TagSource.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            this.TagSource.Click += new System.EventHandler(this.DropList);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.SystemColors.Window;
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.DarkGreen;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Margin = new System.Windows.Forms.Padding(0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(176, 17);
            this.Title.TabIndex = 4;
            // 
            // Subtitle
            // 
            this.Subtitle.BackColor = System.Drawing.SystemColors.Window;
            this.Subtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.Subtitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Subtitle.Location = new System.Drawing.Point(0, 17);
            this.Subtitle.Margin = new System.Windows.Forms.Padding(0);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(176, 14);
            this.Subtitle.TabIndex = 5;
            // 
            // ControlPanel
            // 
            this.ControlPanel.AutoSize = true;
            this.ControlPanel.BackColor = System.Drawing.SystemColors.Window;
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Controls.Add(this.TagSource);
            this.ControlPanel.Controls.Add(this.TagFlow);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlPanel.Location = new System.Drawing.Point(0, 31);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(176, 54);
            this.ControlPanel.TabIndex = 0;
            // 
            // TagBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.Subtitle);
            this.Controls.Add(this.Title);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TagBox";
            this.Size = new System.Drawing.Size(176, 85);
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel TagFlow;
        public System.Windows.Forms.ComboBox TagSource;
        public System.Windows.Forms.Label Subtitle;
        public System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel ControlPanel;
    }
}
