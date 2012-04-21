using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Entities;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;
using ShtrihM.SCA.Packaging.DataTerminal.Repositories;
using ShtrihM.SCA.Packaging.DataTerminal.Forms;

namespace ShtrihM.SCA.Packaging.DataTerminal.Controls
{
  public partial class Login2 : UserControl
  {

    private BaseScanForm _frm;

    public delegate void OnLoginDelegate();
    public delegate void OnLogoutDelegate();

    public event OnLoginDelegate OnLogin;
    public event OnLogoutDelegate OnLogout;

    public static UserEntity User { get; set; }

    public Login2(BaseScanForm frm)
    {
      if (frm == null)
      {
        throw new ArgumentNullException("frm");
      }
      else
      {
        _frm = frm;
        InitializeComponent();
        Toggle();
      }
    }

    public void Toggle()
    {
      if (Models.LoginModel.IsAuthenticated)
      {
        lblId.Text = UserHelper.GetUserName(Models.LoginModel.User.Id);
        lblRole.Text = Models.LoginModel.User.RoleName;
        if (OnLogin != null)
        {
          OnLogin();
        }
      }
      else
      {
        if (OnLogout != null)
        {
          OnLogout();
        }
      }
      pnlLogin.Visible = !Models.LoginModel.IsAuthenticated;
      pnlLogout.Visible = Models.LoginModel.IsAuthenticated;
      txtPassword.Text = string.Empty;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        var id = default(long);
        try
        {
          //user id
          id = long.Parse(txtUserId.Text.Trim());
        }
        catch (Exception ex)
        {
          throw new ExternalException("Неверный ID пользователя.", ex);
        }
        //password
        var pwd = txtPassword.Text.Trim();
        if (string.IsNullOrEmpty(pwd) == true)
        {
          throw new ExternalException("Не указан пароль.");
        }
        //login and set in global param (TODO:global) 
        Models.LoginModel.User = Database.Login(id, pwd);
        Toggle();
      });
      FormHelper.HandleAction(act);
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        Database.Logout(Models.LoginModel.User.Id);
        Models.LoginModel.User = null;
        Toggle();
      });
      FormHelper.HandleAction(act);
    }

    private void pnlLogout_GotFocus(object sender, EventArgs e)
    {

    }
  }
}
