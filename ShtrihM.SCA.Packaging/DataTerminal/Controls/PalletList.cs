using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using ShtrihM.SCA.Packaging.DataTerminal.Repositories;
using ShtrihM.SCA.Packaging.DataTerminal.Models;

namespace ShtrihM.SCA.Packaging.DataTerminal.Controls
{
  public partial class PalletList : ListView, IScanControl
  {
    public enum Field
    {
      Id = 0,
      Num = 1,
      Bin = 2,
      Status = 3
    }

    //public long TaskId { get; set; }

    public Label Counter { get; set; }

    public const string OK = "OK";

    public delegate void OnCompleteDelegate();
    public event OnCompleteDelegate OnComplete;

    public PalletList()
    {
      InitializeComponent();
      this.GotFocus += new EventHandler(Text_GotFocus);
      this.LostFocus += new EventHandler(Text_LostFocus);
    }

    void Text_GotFocus(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        FormHelper.GotFocus(this);
      });
      FormHelper.HandleAction(act);
    }

    void Text_LostFocus(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        FormHelper.LostFocus(this);
      });
      FormHelper.HandleAction(act);
    }

    public virtual void OnScan(int type, string data)
    {
      var sscc = data;
      CheckPallet(sscc);
    }

    private void CheckPallet(string sscc)
    {
      var act = new Action(() =>
      {
        long? id = null;
        int index = 0;
        string status = string.Empty;
        try
        {
          for (var i = 0; i < Items.Count; i++)
          {
            var subs = Items[i].SubItems;
            //check by id
            if (subs[(int)Field.Num].Text.Equals(sscc, StringComparison.InvariantCultureIgnoreCase))
            {
              id = long.Parse(subs[(int)Field.Id].Text);
              sscc = subs[(int)Field.Num].Text;
              status = subs[(int)Field.Status].Text;
              index = i;
              break;
            }
          }

          if (id.HasValue == false || string.IsNullOrEmpty(sscc))
          {
            var msg = string.Format("Продукция с кодом {0} отсутствует в задании.", sscc);
            throw new ExternalException(msg);
          }
          else
          {
            if (status == OK)
            {
              var msg = string.Format("Продукция с кодом {0} уже обработана.", sscc);
              throw new ExternalException(msg);
            }
            else
            {
              long? leftPallets = Database.CheckPallet(id.Value, sscc, LoginModel.User.Id);
              if (leftPallets.HasValue == false)
              {
                var msg = string.Format("Продукция с кодом {0} отсутствует в задании.", sscc);
                throw new ExternalException(msg);
              }
              Items[index].SubItems[(int)Field.Status].Text = OK;
              FormHelper.SelectListItem(this, index);
              UpdateCounters(this);
              if (leftPallets.HasValue && leftPallets.Value == 0 && OnComplete != null)
              {
                OnComplete();
              }
            }
          }
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось обработать продукцию с номером.", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    public void UpdateCounters(ListView lst)
    {
      var total = 0;
      var done = 0;
      GetCounters(lst, out total, out done);
      Counter.Text = string.Format("{0}/{1}", done, total);
    }

    public void GetCounters(ListView lst, out int total, out int done)
    {
      total = 0;
      done = 0;
      foreach (ListViewItem i in lst.Items)
      {
        total++;
        var field = (int)PalletList.Field.Status;
        if (i.SubItems.Count >= field && i.SubItems[field].Text.Equals(OK, StringComparison.InvariantCultureIgnoreCase))
        {
          done++;
        }
      }
    }
  }
}
