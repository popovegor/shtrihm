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
using ShtrihM.SCA.Packaging.DataTerminal.Models;

namespace ShtrihM.SCA.Packaging.DataTerminal.Controls
{
  public partial class Login : UserControl
  {

    //private BaseScanForm _frm;

    public delegate void OnLoginDelegate();
    public delegate void OnLogoutDelegate();

    public event OnLoginDelegate OnLogin;
    public event OnLogoutDelegate OnLogout;

    long _adminId = 1;
    string _adminPassword = "567";

    public static UserEntity User { get; set; }

    public Login()
    {
      InitializeComponent();
      Toggle();
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
        if (id == _adminId && _adminPassword == pwd)
        {
          LoginModel.User = new UserEntity();
          LoginModel.User.Id = LoginModel.FakeId;
          LoginModel.User.Role = UserRole.Admin;
        }
        else
        {
          LoginModel.User = Database.Login(id, pwd);
        }
        Toggle();
      });
      FormHelper.HandleAction(act);
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        if (LoginModel.User.Id == LoginModel.FakeId && LoginModel.Role == UserRole.Admin)
        {
        }
        else
        {
          Database.Logout(Models.LoginModel.User.Id);
        }
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
