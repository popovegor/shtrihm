namespace ShtrihM.SCA.Packaging.DataTerminal.Controls
{
  partial class Login2
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pnlLogin = new System.Windows.Forms.Panel();
      this.btnLogin = new System.Windows.Forms.Button();
      this.txtPassword = new ScanText();
      this.txtUserId = new ScanText();
      this.lblUserId = new System.Windows.Forms.Label();
      this.lblPassword = new System.Windows.Forms.Label();
      this.pnlLogout = new System.Windows.Forms.Panel();
      this.lblRole = new System.Windows.Forms.Label();
      this.lblId = new System.Windows.Forms.Label();
      this.lblRoleTitle = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.btnLogout = new System.Windows.Forms.Button();
      this.pnlLogin.SuspendLayout();
      this.pnlLogout.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlLogin
      // 
      this.pnlLogin.Controls.Add(this.btnLogin);
      this.pnlLogin.Controls.Add(this.txtPassword);
      this.pnlLogin.Controls.Add(this.txtUserId);
      this.pnlLogin.Controls.Add(this.lblUserId);
      this.pnlLogin.Controls.Add(this.lblPassword);
      this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlLogin.Location = new System.Drawing.Point(0, 0);
      this.pnlLogin.Name = "pnlLogin";
      this.pnlLogin.Size = new System.Drawing.Size(250, 64);
      // 
      // btnLogin
      // 
      this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLogin.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
      this.btnLogin.Location = new System.Drawing.Point(192, 5);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(54, 55);
      this.btnLogin.TabIndex = 4;
      this.btnLogin.Text = ">";
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // txtPassword
      // 
      this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPassword.Location = new System.Drawing.Point(99, 35);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(87, 25);
      this.txtPassword.TabIndex = 3;
      // 
      // txtUserId
      // 
      this.txtUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtUserId.Location = new System.Drawing.Point(99, 5);
      this.txtUserId.Name = "txtUserId";
      this.txtUserId.Size = new System.Drawing.Size(87, 25);
      this.txtUserId.TabIndex = 2;
      // 
      // lblUserId
      // 
      this.lblUserId.Location = new System.Drawing.Point(3, 10);
      this.lblUserId.Name = "lblUserId";
      this.lblUserId.Size = new System.Drawing.Size(132, 20);
      this.lblUserId.Text = "ID польз-ля:";
      // 
      // lblPassword
      // 
      this.lblPassword.Location = new System.Drawing.Point(3, 40);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(100, 20);
      this.lblPassword.Text = "Пароль:";
      // 
      // pnlLogout
      // 
      this.pnlLogout.Controls.Add(this.lblRole);
      this.pnlLogout.Controls.Add(this.lblId);
      this.pnlLogout.Controls.Add(this.lblRoleTitle);
      this.pnlLogout.Controls.Add(this.label3);
      this.pnlLogout.Controls.Add(this.btnLogout);
      this.pnlLogout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlLogout.Location = new System.Drawing.Point(0, 0);
      this.pnlLogout.Name = "pnlLogout";
      this.pnlLogout.Size = new System.Drawing.Size(250, 64);
      this.pnlLogout.GotFocus += new System.EventHandler(this.pnlLogout_GotFocus);
      // 
      // lblRole
      // 
      this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblRole.Location = new System.Drawing.Point(75, 40);
      this.lblRole.Name = "lblRole";
      this.lblRole.Size = new System.Drawing.Size(111, 20);
      // 
      // lblId
      // 
      this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblId.Location = new System.Drawing.Point(75, 10);
      this.lblId.Name = "lblId";
      this.lblId.Size = new System.Drawing.Size(111, 20);
      // 
      // lblRoleTitle
      // 
      this.lblRoleTitle.Location = new System.Drawing.Point(3, 40);
      this.lblRoleTitle.Name = "lblRoleTitle";
      this.lblRoleTitle.Size = new System.Drawing.Size(77, 20);
      this.lblRoleTitle.Text = "Роль:";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(3, 10);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(77, 20);
      this.label3.Text = "Польз.:";
      // 
      // btnLogout
      // 
      this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLogout.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
      this.btnLogout.Location = new System.Drawing.Point(192, 5);
      this.btnLogout.Name = "btnLogout";
      this.btnLogout.Size = new System.Drawing.Size(55, 54);
      this.btnLogout.TabIndex = 5;
      this.btnLogout.Text = "<";
      this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
      // 
      // Login
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this.pnlLogout);
      this.Controls.Add(this.pnlLogin);
      this.Name = "Login";
      this.Size = new System.Drawing.Size(250, 64);
      this.pnlLogin.ResumeLayout(false);
      this.pnlLogout.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlLogin;
    private System.Windows.Forms.Label lblUserId;
    private System.Windows.Forms.Label lblPassword;
    private ScanText txtPassword;
    private ScanText txtUserId;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Panel pnlLogout;
    private System.Windows.Forms.Button btnLogout;
    private System.Windows.Forms.Label lblRoleTitle;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblRole;
    private System.Windows.Forms.Label lblId;
  }
}
