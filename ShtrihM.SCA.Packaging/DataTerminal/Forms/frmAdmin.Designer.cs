using ShtrihM.SCA.Packaging.DataTerminal.Controls;
using System.Windows.Forms;
namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  partial class frmAdmin
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
      this.tbl = new System.Windows.Forms.TabControl();
      this.tbDb = new System.Windows.Forms.TabPage();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnTest = new System.Windows.Forms.Button();
      this.txtPort = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanText();
      this.label5 = new System.Windows.Forms.Label();
      this.txtpwd = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanText();
      this.label4 = new System.Windows.Forms.Label();
      this.txtLogin = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanText();
      this.label3 = new System.Windows.Forms.Label();
      this.txtDB = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanText();
      this.label2 = new System.Windows.Forms.Label();
      this.txtServer = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanText();
      this.label1 = new System.Windows.Forms.Label();
      this.tbUser = new System.Windows.Forms.TabPage();
      this.btnUserClear = new System.Windows.Forms.Button();
      this.btnUserSave = new System.Windows.Forms.Button();
      this.txtUserPassword = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cbxUserRole = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.lblUserName = new System.Windows.Forms.Label();
      this.txtUserName = new System.Windows.Forms.TextBox();
      this.btnUserSearch = new System.Windows.Forms.Button();
      this.lblUserID = new System.Windows.Forms.Label();
      this.txtUserID = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanText();
      this.tbProd = new System.Windows.Forms.TabPage();
      this.tbPlacement = new System.Windows.Forms.TabPage();
      this.tbLoad = new System.Windows.Forms.TabPage();
      this.btnCancel = new System.Windows.Forms.Button();
      this.tbl.SuspendLayout();
      this.tbDb.SuspendLayout();
      this.tbUser.SuspendLayout();
      this.SuspendLayout();
      // 
      // tbl
      // 
      this.tbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.tbl.Controls.Add(this.tbDb);
      this.tbl.Controls.Add(this.tbUser);
      this.tbl.Controls.Add(this.tbProd);
      this.tbl.Controls.Add(this.tbPlacement);
      this.tbl.Controls.Add(this.tbLoad);
      this.tbl.Dock = System.Windows.Forms.DockStyle.None;
      this.tbl.Location = new System.Drawing.Point(3, 0);
      this.tbl.Name = "tbl";
      this.tbl.SelectedIndex = 0;
      this.tbl.Size = new System.Drawing.Size(234, 254);
      this.tbl.TabIndex = 1;
      // 
      // tbDb
      // 
      this.tbDb.Controls.Add(this.btnSave);
      this.tbDb.Controls.Add(this.btnTest);
      this.tbDb.Controls.Add(this.txtPort);
      this.tbDb.Controls.Add(this.label5);
      this.tbDb.Controls.Add(this.txtpwd);
      this.tbDb.Controls.Add(this.label4);
      this.tbDb.Controls.Add(this.txtLogin);
      this.tbDb.Controls.Add(this.label3);
      this.tbDb.Controls.Add(this.txtDB);
      this.tbDb.Controls.Add(this.label2);
      this.tbDb.Controls.Add(this.txtServer);
      this.tbDb.Controls.Add(this.label1);
      this.tbDb.Location = new System.Drawing.Point(0, 0);
      this.tbDb.Name = "tbDb";
      this.tbDb.Size = new System.Drawing.Size(234, 227);
      this.tbDb.Text = "БД";
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(113, 177);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(118, 47);
      this.btnSave.TabIndex = 6;
      this.btnSave.Text = "Сохранить";
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnTest
      // 
      this.btnTest.Location = new System.Drawing.Point(3, 177);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(104, 47);
      this.btnTest.TabIndex = 5;
      this.btnTest.Text = "Тест";
      this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(109, 34);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(122, 25);
      this.txtPort.TabIndex = 1;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(3, 37);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(100, 20);
      this.label5.Text = "Порт";
      // 
      // txtpwd
      // 
      this.txtpwd.Location = new System.Drawing.Point(109, 123);
      this.txtpwd.Name = "txtpwd";
      this.txtpwd.Size = new System.Drawing.Size(122, 25);
      this.txtpwd.TabIndex = 4;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(3, 126);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(100, 20);
      this.label4.Text = "Пароль";
      // 
      // txtLogin
      // 
      this.txtLogin.Location = new System.Drawing.Point(109, 93);
      this.txtLogin.Name = "txtLogin";
      this.txtLogin.Size = new System.Drawing.Size(122, 25);
      this.txtLogin.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(3, 96);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(100, 20);
      this.label3.Text = "Логин";
      // 
      // txtDB
      // 
      this.txtDB.Location = new System.Drawing.Point(109, 64);
      this.txtDB.Name = "txtDB";
      this.txtDB.Size = new System.Drawing.Size(122, 25);
      this.txtDB.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(3, 67);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(100, 20);
      this.label2.Text = "База данных";
      // 
      // txtServer
      // 
      this.txtServer.BackColor = System.Drawing.Color.White;
      this.txtServer.Location = new System.Drawing.Point(109, 4);
      this.txtServer.Name = "txtServer";
      this.txtServer.Size = new System.Drawing.Size(122, 25);
      this.txtServer.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 20);
      this.label1.Text = "Сервер данных";
      // 
      // tbUser
      // 
      this.tbUser.Controls.Add(this.btnUserClear);
      this.tbUser.Controls.Add(this.btnUserSave);
      this.tbUser.Controls.Add(this.txtUserPassword);
      this.tbUser.Controls.Add(this.label7);
      this.tbUser.Controls.Add(this.cbxUserRole);
      this.tbUser.Controls.Add(this.label6);
      this.tbUser.Controls.Add(this.lblUserName);
      this.tbUser.Controls.Add(this.txtUserName);
      this.tbUser.Controls.Add(this.btnUserSearch);
      this.tbUser.Controls.Add(this.lblUserID);
      this.tbUser.Controls.Add(this.txtUserID);
      this.tbUser.Location = new System.Drawing.Point(0, 0);
      this.tbUser.Name = "tbUser";
      this.tbUser.Size = new System.Drawing.Size(226, 225);
      this.tbUser.Text = "Польз.";
      // 
      // btnUserClear
      // 
      this.btnUserClear.Location = new System.Drawing.Point(3, 177);
      this.btnUserClear.Name = "btnUserClear";
      this.btnUserClear.Size = new System.Drawing.Size(106, 47);
      this.btnUserClear.TabIndex = 14;
      this.btnUserClear.Text = "Очистить";
      this.btnUserClear.Click += new System.EventHandler(this.btnUserClear_Click);
      // 
      // btnUserSave
      // 
      this.btnUserSave.Location = new System.Drawing.Point(115, 177);
      this.btnUserSave.Name = "btnUserSave";
      this.btnUserSave.Size = new System.Drawing.Size(115, 47);
      this.btnUserSave.TabIndex = 13;
      this.btnUserSave.Text = "Сохранить";
      // 
      // txtUserPassword
      // 
      this.txtUserPassword.Location = new System.Drawing.Point(73, 122);
      this.txtUserPassword.Name = "txtUserPassword";
      this.txtUserPassword.Size = new System.Drawing.Size(157, 25);
      this.txtUserPassword.TabIndex = 12;
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(3, 127);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(62, 20);
      this.label7.Text = "Пароль";
      // 
      // cbxUserRole
      // 
      this.cbxUserRole.Location = new System.Drawing.Point(72, 90);
      this.cbxUserRole.Name = "cbxUserRole";
      this.cbxUserRole.Size = new System.Drawing.Size(157, 26);
      this.cbxUserRole.TabIndex = 9;
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(3, 96);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(48, 20);
      this.label6.Text = "Роль";
      // 
      // lblUserName
      // 
      this.lblUserName.Location = new System.Drawing.Point(3, 62);
      this.lblUserName.Name = "lblUserName";
      this.lblUserName.Size = new System.Drawing.Size(48, 20);
      this.lblUserName.Text = "ФИО";
      // 
      // txtUserName
      // 
      this.txtUserName.Location = new System.Drawing.Point(72, 59);
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new System.Drawing.Size(158, 25);
      this.txtUserName.TabIndex = 4;
      // 
      // btnUserSearch
      // 
      this.btnUserSearch.Location = new System.Drawing.Point(121, 3);
      this.btnUserSearch.Name = "btnUserSearch";
      this.btnUserSearch.Size = new System.Drawing.Size(110, 48);
      this.btnUserSearch.TabIndex = 2;
      this.btnUserSearch.Text = "Найти";
      this.btnUserSearch.Click += new System.EventHandler(this.btnUserSearch_Click);
      // 
      // lblUserID
      // 
      this.lblUserID.Location = new System.Drawing.Point(3, 3);
      this.lblUserID.Name = "lblUserID";
      this.lblUserID.Size = new System.Drawing.Size(88, 20);
      this.lblUserID.Text = "ID пользов.";
      // 
      // txtUserID
      // 
      this.txtUserID.Location = new System.Drawing.Point(3, 26);
      this.txtUserID.Name = "txtUserID";
      this.txtUserID.Size = new System.Drawing.Size(113, 25);
      this.txtUserID.TabIndex = 0;
      // 
      // tbProd
      // 
      this.tbProd.Location = new System.Drawing.Point(0, 0);
      this.tbProd.Name = "tbProd";
      this.tbProd.Size = new System.Drawing.Size(226, 225);
      this.tbProd.Text = "Прод.";
      // 
      // tbPlacement
      // 
      this.tbPlacement.Location = new System.Drawing.Point(0, 0);
      this.tbPlacement.Name = "tbPlacement";
      this.tbPlacement.Size = new System.Drawing.Size(226, 225);
      this.tbPlacement.Text = "Прих.";
      // 
      // tbLoad
      // 
      this.tbLoad.Location = new System.Drawing.Point(0, 0);
      this.tbLoad.Name = "tbLoad";
      this.tbLoad.Size = new System.Drawing.Size(226, 225);
      this.tbLoad.Text = "Отгруз.";
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(124, 262);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(111, 29);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Закрыть";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // frmAdmin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(240, 294);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.tbl);
      this.Name = "frmAdmin";
      this.Text = "SCA: Администрирование";
      this.Load += new System.EventHandler(this.frmAdmin_Load);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAdmin_Closing);
      this.tbl.ResumeLayout(false);
      this.tbDb.ResumeLayout(false);
      this.tbUser.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tbl;
    private System.Windows.Forms.TabPage tbDb;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label1;
    private ScanText txtServer;
    private ScanText txtDB;
    private System.Windows.Forms.Label label2;
    private ScanText txtLogin;
    private System.Windows.Forms.Label label3;
    private ScanText txtpwd;
    private System.Windows.Forms.Label label4;
    private ScanText txtPort;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnTest;
    private System.Windows.Forms.Button btnSave;
    private TabPage tbUser;
    private Label lblUserID;
    private ScanText txtUserID;
    private Button btnUserSearch;
    private Label lblUserName;
    private TextBox txtUserName;
    private ComboBox cbxUserRole;
    private Label label6;
    private Button btnUserSave;
    private TextBox txtUserPassword;
    private Label label7;
    private Button btnUserClear;
    private TabPage tbProd;
    private TabPage tbPlacement;
    private TabPage tbLoad;
  }
}