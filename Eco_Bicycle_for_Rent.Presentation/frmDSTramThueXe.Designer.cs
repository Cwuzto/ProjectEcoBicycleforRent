namespace Eco_Bicycle_for_Rent.Presentation
{
    partial class frmDSTramThueXe
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCN = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDSTram = new System.Windows.Forms.DataGridView();
            this.DiaChiTram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChiCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTram)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(350, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(691, 36);
            this.label1.TabIndex = 30;
            this.label1.Text = "DANH SÁCH CÁC TRẠM TẠI CÁC CHI NHÁNH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(445, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 29);
            this.label3.TabIndex = 31;
            this.label3.Text = "Chi Nhánh:";
            // 
            // cmbCN
            // 
            this.cmbCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCN.FormattingEnabled = true;
            this.cmbCN.Location = new System.Drawing.Point(622, 119);
            this.cmbCN.Name = "cmbCN";
            this.cmbCN.Size = new System.Drawing.Size(315, 30);
            this.cmbCN.TabIndex = 32;
            this.cmbCN.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDSTram);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(239, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 347);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách";
            // 
            // dgvDSTram
            // 
            this.dgvDSTram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DiaChiTram,
            this.TenCN,
            this.DiaChiCN});
            this.dgvDSTram.Location = new System.Drawing.Point(0, 26);
            this.dgvDSTram.Name = "dgvDSTram";
            this.dgvDSTram.RowHeadersWidth = 51;
            this.dgvDSTram.RowTemplate.Height = 24;
            this.dgvDSTram.Size = new System.Drawing.Size(915, 315);
            this.dgvDSTram.TabIndex = 0;
            // 
            // DiaChiTram
            // 
            this.DiaChiTram.DataPropertyName = "DiaChiTram";
            this.DiaChiTram.HeaderText = "Địa chỉ của trạm";
            this.DiaChiTram.MinimumWidth = 6;
            this.DiaChiTram.Name = "DiaChiTram";
            this.DiaChiTram.ReadOnly = true;
            this.DiaChiTram.Width = 200;
            // 
            // TenCN
            // 
            this.TenCN.DataPropertyName = "TenCN";
            this.TenCN.HeaderText = "Tên chi nhánh";
            this.TenCN.MinimumWidth = 6;
            this.TenCN.Name = "TenCN";
            this.TenCN.ReadOnly = true;
            this.TenCN.Width = 200;
            // 
            // DiaChiCN
            // 
            this.DiaChiCN.DataPropertyName = "DiaChiCN";
            this.DiaChiCN.HeaderText = "Địa chỉ của chi nhánh";
            this.DiaChiCN.MinimumWidth = 6;
            this.DiaChiCN.Name = "DiaChiCN";
            this.DiaChiCN.ReadOnly = true;
            this.DiaChiCN.Width = 250;
            // 
            // frmDSTramThueXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 548);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbCN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmDSTramThueXe";
            this.Text = "frmDSTramThueXe";
            this.Load += new System.EventHandler(this.frmDSTramThueXe_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDSTram;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiTram;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiCN;
    }
}