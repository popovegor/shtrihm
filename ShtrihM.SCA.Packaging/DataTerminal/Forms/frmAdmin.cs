using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;
using System.Text.RegularExpressions;
using ShtrihM.SCA.Packaging.DataTerminal.Repositories;

namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  public partial class frmAdmin : BaseForm
  {
    public frmAdmin()
    {
      InitializeComponent();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

    }

    private void frmAdmin_Closing(object sender, CancelEventArgs e)
    {
      var act = new Action(() =>
      {
        if (FormHelper.ShowPrompt("Вы уверены, что хотите закрыть форму \"Администрирования\"?") == DialogResult.No)
        {
          e.Cancel = true;
        }
      });
      //FormHelper.HandleAction(act);
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          var cs = ConnectionStringHelper.To(txtServer.Text, txtDB.Text, txtPort.Text,
            txtLogin.Text, txtpwd.Text);
          Database.CheckConnection(cs);
          FormHelper.ShowInfo("Успех.");
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception ex)
        {
          throw new ExternalException("Указаны неверные параметры соединения.", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void frmAdmin_Load(object sender, EventArgs e)
    {
    
      var act = new Action(() => {
        try
        {
          string server, db, user, pwd, port;
          var cs = ConfigHelper.GetConnectionString("db");
          ConnectionStringHelper.From(cs
            , out server
            , out db
            , out port
            , out user
            , out pwd);
          txtServer.Text = server ?? string.Empty;
          txtDB.Text = db ?? string.Empty;
          txtPort.Text = port ?? string.Empty;
          txtLogin.Text = user ?? string.Empty;
          txtpwd.Text = pwd ?? string.Empty;
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception ex)
        {
          var msg = "Не удалось загрузить данные о настройках подключения.";
          new ExternalException(msg, ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          if(FormHelper.ShowPrompt("Сохранить настройки?") == DialogResult.Yes) 
          {
          var cs = ConnectionStringHelper.To(txtServer.Text, txtDB.Text, txtPort.Text,
            txtLogin.Text, txtpwd.Text);
          //Database.CheckConnection(cs);
          ConfigHelper.SaveConnectionString("db", cs);
          FormHelper.ShowInfo("Операция была выполнена успешно.");
          }
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось сохранить настройки.", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnUserClear_Click(object sender, EventArgs e)
    {
      var act = new Action(() => {
        txtUserID.Text = string.Empty;
        txtUserName.Text = string.Empty;
        cbxUserRole.Text = string.Empty;
        txtUserPassword.Text = string.Empty;
      });
      FormHelper.HandleAction(act);
    }
    
    private void btnUserSearch_Click(object sender, EventArgs e)
    {
      var act = new Action(() => {
        //TODO:
      });
      FormHelper.HandleAction(act);
    }

  }
}