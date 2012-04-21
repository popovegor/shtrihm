namespace ShtrihM.SpbBank.Scanner
{
  partial class frmSetNest
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
      this.lbl1 = new System.Windows.Forms.Label();
      this.txtNest = new System.Windows.Forms.TextBox();
      this.btnApply = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lbl1
      // 
      this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lbl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.lbl1.Location = new System.Drawing.Point(4, 4);
      this.lbl1.Name = "lbl1";
      this.lbl1.Size = new System.Drawing.Size(205, 38);
      this.lbl1.Text = "Введите или отсканируйте штрихкод вложения";
      this.lbl1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // txtNest
      // 
      this.txtNest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNest.Location = new System.Drawing.Point(3, 45);
      this.txtNest.Name = "txtNest";
      this.txtNest.Size = new System.Drawing.Size(202, 27);
      this.txtNest.TabIndex = 0;
      this.txtNest.TextChanged += new System.EventHandler(this.txtNest_TextChanged);
      // 
      // btnApply
      // 
      this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnApply.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.btnApply.Location = new System.Drawing.Point(4, 80);
      this.btnApply.Name = "btnApply";
      this.btnApply.Size = new System.Drawing.Size(98, 60);
      this.btnApply.TabIndex = 1;
      this.btnApply.Text = "Принять";
      this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.btnClose.Location = new System.Drawing.Point(108, 80);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(97, 60);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "Отмена";
      // 
      // frmSetNest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(209, 143);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnApply);
      this.Controls.Add(this.txtNest);
      this.Controls.Add(this.lbl1);
      this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "frmSetNest";
      this.Text = "Штрихкод вложение";
      this.Load += new System.EventHandler(this.frmSetNest_Load);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSetNest_Closing);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lbl1;
    private System.Windows.Forms.TextBox txtNest;
    private System.Windows.Forms.Button btnApply;
    private System.Windows.Forms.Button btnClose;
  }
}