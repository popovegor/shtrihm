namespace ShtrihM.SpbBank.Scanner
{
  partial class frmSetAtm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetAtm));
      this.lblATM = new System.Windows.Forms.Label();
      this.btnApply = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.txtAtmNumber = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // lblATM
      // 
      resources.ApplyResources(this.lblATM, "lblATM");
      this.lblATM.Name = "lblATM";
      this.lblATM.ParentChanged += new System.EventHandler(this.lblATM_ParentChanged);
      // 
      // btnApply
      // 
      resources.ApplyResources(this.btnApply, "btnApply");
      this.btnApply.Name = "btnApply";
      this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
      // 
      // btnCancel
      // 
      resources.ApplyResources(this.btnCancel, "btnCancel");
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Name = "btnCancel";
      // 
      // txtAtmNumber
      // 
      resources.ApplyResources(this.txtAtmNumber, "txtAtmNumber");
      this.txtAtmNumber.Name = "txtAtmNumber";
      this.txtAtmNumber.GotFocus += new System.EventHandler(this.txtAtmNumber_GotFocus);
      // 
      // frmSetAtm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.txtAtmNumber);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnApply);
      this.Controls.Add(this.lblATM);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "frmSetAtm";
      this.Load += new System.EventHandler(this.frmSetATM_Load);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSetATM_Closing);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblATM;
    private System.Windows.Forms.Button btnApply;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox txtAtmNumber;
  }
}