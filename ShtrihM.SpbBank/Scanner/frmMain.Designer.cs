namespace ShtrihM.SpbBank.Scanner
{
  partial class frmMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.btnCollect = new System.Windows.Forms.Button();
      this.btnExport = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.lblAtmTitle = new System.Windows.Forms.Label();
      this.btnAddNest = new System.Windows.Forms.Button();
      this.lblAtmNumber = new System.Windows.Forms.Label();
      this.lstData = new System.Windows.Forms.ListView();
      this.clmAtm = new System.Windows.Forms.ColumnHeader();
      this.clmNest = new System.Windows.Forms.ColumnHeader();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnFind = new System.Windows.Forms.Button();
      this.btnFirst = new System.Windows.Forms.Button();
      this.btnPrev = new System.Windows.Forms.Button();
      this.btnNext = new System.Windows.Forms.Button();
      this.btnLast = new System.Windows.Forms.Button();
      this.btnDel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnCollect
      // 
      resources.ApplyResources(this.btnCollect, "btnCollect");
      this.btnCollect.Name = "btnCollect";
      this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
      // 
      // btnExport
      // 
      resources.ApplyResources(this.btnExport, "btnExport");
      this.btnExport.Name = "btnExport";
      this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
      // 
      // btnClose
      // 
      resources.ApplyResources(this.btnClose, "btnClose");
      this.btnClose.Name = "btnClose";
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // lblAtmTitle
      // 
      resources.ApplyResources(this.lblAtmTitle, "lblAtmTitle");
      this.lblAtmTitle.Name = "lblAtmTitle";
      // 
      // btnAddNest
      // 
      resources.ApplyResources(this.btnAddNest, "btnAddNest");
      this.btnAddNest.Name = "btnAddNest";
      this.btnAddNest.Click += new System.EventHandler(this.btnAddNest_Click);
      // 
      // lblAtmNumber
      // 
      resources.ApplyResources(this.lblAtmNumber, "lblAtmNumber");
      this.lblAtmNumber.Name = "lblAtmNumber";
      // 
      // lstData
      // 
      resources.ApplyResources(this.lstData, "lstData");
      this.lstData.Columns.Add(this.clmAtm);
      this.lstData.Columns.Add(this.clmNest);
      this.lstData.FullRowSelect = true;
      this.lstData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstData.Name = "lstData";
      this.lstData.View = System.Windows.Forms.View.Details;
      // 
      // clmAtm
      // 
      resources.ApplyResources(this.clmAtm, "clmAtm");
      // 
      // clmNest
      // 
      resources.ApplyResources(this.clmNest, "clmNest");
      // 
      // btnClear
      // 
      resources.ApplyResources(this.btnClear, "btnClear");
      this.btnClear.Name = "btnClear";
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnFind
      // 
      resources.ApplyResources(this.btnFind, "btnFind");
      this.btnFind.Name = "btnFind";
      this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
      // 
      // btnFirst
      // 
      resources.ApplyResources(this.btnFirst, "btnFirst");
      this.btnFirst.Name = "btnFirst";
      this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
      // 
      // btnPrev
      // 
      resources.ApplyResources(this.btnPrev, "btnPrev");
      this.btnPrev.Name = "btnPrev";
      this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
      // 
      // btnNext
      // 
      resources.ApplyResources(this.btnNext, "btnNext");
      this.btnNext.Name = "btnNext";
      this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
      // 
      // btnLast
      // 
      resources.ApplyResources(this.btnLast, "btnLast");
      this.btnLast.Name = "btnLast";
      this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
      // 
      // btnDel
      // 
      resources.ApplyResources(this.btnDel, "btnDel");
      this.btnDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.btnDel.Name = "btnDel";
      this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.btnDel);
      this.Controls.Add(this.btnLast);
      this.Controls.Add(this.btnNext);
      this.Controls.Add(this.btnPrev);
      this.Controls.Add(this.btnFirst);
      this.Controls.Add(this.btnFind);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.lstData);
      this.Controls.Add(this.lblAtmNumber);
      this.Controls.Add(this.btnAddNest);
      this.Controls.Add(this.lblAtmTitle);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnExport);
      this.Controls.Add(this.btnCollect);
      this.Name = "frmMain";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnCollect;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label lblAtmTitle;
    private System.Windows.Forms.Button btnAddNest;
    private System.Windows.Forms.Label lblAtmNumber;
    private System.Windows.Forms.ListView lstData;
    private System.Windows.Forms.ColumnHeader clmAtm;
    private System.Windows.Forms.ColumnHeader clmNest;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.Button btnFirst;
    private System.Windows.Forms.Button btnPrev;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnLast;
    private System.Windows.Forms.Button btnDel;
  }
}