namespace ShtrihM.SpbBank.Scanner
{
  partial class frmSearch
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
      this.btnFind = new System.Windows.Forms.Button();
      this.lstFiltered = new System.Windows.Forms.ListView();
      this.clm = new System.Windows.Forms.ColumnHeader();
      this.btnClose = new System.Windows.Forms.Button();
      this.cmbAtm = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.label1.Location = new System.Drawing.Point(3, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(132, 20);
      this.label1.Text = "№ банкомата";
      // 
      // btnFind
      // 
      this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFind.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.btnFind.Location = new System.Drawing.Point(559, 3);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new System.Drawing.Size(76, 43);
      this.btnFind.TabIndex = 1;
      this.btnFind.Text = "Найти";
      this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
      // 
      // lstFiltered
      // 
      this.lstFiltered.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lstFiltered.Columns.Add(this.clm);
      this.lstFiltered.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.lstFiltered.Location = new System.Drawing.Point(3, 58);
      this.lstFiltered.Name = "lstFiltered";
      this.lstFiltered.Size = new System.Drawing.Size(635, 340);
      this.lstFiltered.TabIndex = 2;
      this.lstFiltered.View = System.Windows.Forms.View.Details;
      // 
      // clm
      // 
      this.clm.Text = "Найденные штрихкоды";
      this.clm.Width = 150;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.btnClose.Location = new System.Drawing.Point(3, 404);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(632, 48);
      this.btnClose.TabIndex = 3;
      this.btnClose.Text = "Выход";
      // 
      // cmbAtm
      // 
      this.cmbAtm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbAtm.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular);
      this.cmbAtm.Location = new System.Drawing.Point(3, 23);
      this.cmbAtm.Name = "cmbAtm";
      this.cmbAtm.Size = new System.Drawing.Size(550, 33);
      this.cmbAtm.TabIndex = 0;
      this.cmbAtm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAtm_KeyDown);
      // 
      // frmSearch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(638, 455);
      this.Controls.Add(this.cmbAtm);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.lstFiltered);
      this.Controls.Add(this.btnFind);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
      this.Name = "frmSearch";
      this.Text = "Поиск";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.ListView lstFiltered;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.ComboBox cmbAtm;
    private System.Windows.Forms.ColumnHeader clm;
  }
}