using ShtrihM.SCA.Packaging.DataTerminal.Controls;
namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
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
      this.btnClose = new System.Windows.Forms.Button();
      this.lgn = new Login();
      btnPlace = new System.Windows.Forms.Button();
      btnReplace = new System.Windows.Forms.Button();
      btnLoad = new System.Windows.Forms.Button();
      btnInventory = new System.Windows.Forms.Button();
      btnAdmin = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnPlace
      // 
      btnPlace.Enabled = false;
      btnPlace.Location = new System.Drawing.Point(3, 63);
      btnPlace.Name = "btnPlace";
      btnPlace.Size = new System.Drawing.Size(236, 38);
      btnPlace.TabIndex = 1;
      btnPlace.Text = "Приходование";
      btnPlace.Click += new System.EventHandler(this.btnPlace_Click);
      // 
      // btnReplace
      // 
      btnReplace.Enabled = false;
      btnReplace.Location = new System.Drawing.Point(3, 103);
      btnReplace.Name = "btnReplace";
      btnReplace.Size = new System.Drawing.Size(236, 38);
      btnReplace.TabIndex = 2;
      btnReplace.Text = "Перемещение";
      btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
      // 
      // btnLoad
      // 
      btnLoad.Enabled = false;
      btnLoad.Location = new System.Drawing.Point(3, 143);
      btnLoad.Name = "btnLoad";
      btnLoad.Size = new System.Drawing.Size(236, 38);
      btnLoad.TabIndex = 3;
      btnLoad.Text = "Отгрузка";
      btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // btnInventory
      // 
      btnInventory.Enabled = false;
      btnInventory.Location = new System.Drawing.Point(3, 183);
      btnInventory.Name = "btnInventory";
      btnInventory.Size = new System.Drawing.Size(236, 38);
      btnInventory.TabIndex = 4;
      btnInventory.Text = "Инвентаризация";
      btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
      // 
      // btnAdmin
      // 
      btnAdmin.Location = new System.Drawing.Point(3, 223);
      btnAdmin.Name = "btnAdmin";
      btnAdmin.Size = new System.Drawing.Size(236, 38);
      btnAdmin.TabIndex = 5;
      btnAdmin.Text = "Администрирование";
      btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
      // 
      // button1
      // 
      this.btnClose.Location = new System.Drawing.Point(136, 264);
      this.btnClose.Name = "button1";
      this.btnClose.Size = new System.Drawing.Size(102, 28);
      this.btnClose.TabIndex = 6;
      this.btnClose.Text = "Закрыть";
      this.btnClose.Click += new System.EventHandler(this.button1_Click);
      // 
      // lgn
      // 
      this.lgn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lgn.Location = new System.Drawing.Point(3, 3);
      this.lgn.Name = "lgn";
      this.lgn.Size = new System.Drawing.Size(234, 51);
      this.lgn.TabIndex = 0;
      this.lgn.Resize += new System.EventHandler(this.lgn_Resize);
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(240, 294);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(btnAdmin);
      this.Controls.Add(btnInventory);
      this.Controls.Add(btnLoad);
      this.Controls.Add(btnReplace);
      this.Controls.Add(btnPlace);
      this.Controls.Add(this.lgn);
      this.Name = "frmMain";
      this.Text = "SCA: Программа сбора данных";
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.ResumeLayout(false);

    }

    #endregion

    private Login lgn;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnPlace;
    private System.Windows.Forms.Button btnReplace;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Button btnInventory;
    private System.Windows.Forms.Button btnAdmin;
  }
}

