using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using ShtrihM.SCA.Packaging.DataTerminal.Controls;
using ShtrihM.SCA.Packaging.DataTerminal.Models;
using ShtrihM.SCA.Packaging.DataTerminal.Entities;

namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  public partial class frmMain : BaseForm
  {
    private List<Button> _actions = new List<Button>();

    public frmMain()
    {
      InitializeComponent();
      lgn.OnLogin += new Login.OnLoginDelegate(lgn_OnLogin);
      lgn.OnLogout += new Login.OnLogoutDelegate(lgn_OnLogout);
      _actions.Clear();
      _actions.Add(btnInventory);
      _actions.Add(btnPlace);
      _actions.Add(btnReplace);
      _actions.Add(btnLoad);
    }

    void lgn_OnLogout()
    {
      var act = new Action(() =>
      {
        foreach (var a in _actions)
        {
          a.Enabled = false;
        }
        btnAdmin.Enabled = false;
        btnClose.Enabled = false;
      });
      FormHelper.HandleAction(act);
    }

    void lgn_OnLogin()
    {
      var act = new Action(() =>
      {
        if (LoginModel.IsAuthenticated)
        {
          foreach (var a in _actions)
          {
            a.Enabled = true;
          }
        }

        if (LoginModel.Role == UserRole.Admin)
        {
          btnAdmin.Enabled = true;
          btnClose.Enabled = true;
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnPlace_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          var frm = new frmPlacement();
          frm.ShowDialog();
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось открыть форму \"Приходования\".", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnReplace_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          var frm = new frmReplacement();
          frm.ShowDialog();
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось открыть форму \"Перемещения\".", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          var frm = new frmLoading();
          frm.ShowDialog();
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось открыть форму \"Отгрузки\".", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnInventory_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          var frm = new frmInventory();
          frm.ShowDialog();
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось открыть форму \"Инвентаризации\".", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnAdmin_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          var frm = new frmAdmin();
          frm.ShowDialog();
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось открыть форму \"Администрирования\".", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void lgn_Resize(object sender, EventArgs e)
    {
      FormHelper.HandleAction(() => lgn.Toggle());
    }

    private void button1_Click(object sender, EventArgs e)
    {

      var act = new Action(() =>
      {
        if (FormHelper.ShowPrompt("Вы уверены, что хотите закрыть приложение?") == DialogResult.Yes)
        {
          this.Close();
        }
      });
      //TODO: remove it, because it's for test only
      var act2 = new Action(() =>
      {
        var frm = new Message("text", "catpion");
        frm.ShowDialog();
      });

      FormHelper.HandleAction(act);
    }
  }
}