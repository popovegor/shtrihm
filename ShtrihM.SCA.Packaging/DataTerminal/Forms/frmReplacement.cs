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
using ShtrihM.SCA.Packaging.DataTerminal.Repositories;
using ShtrihM.SCA.Packaging.DataTerminal.Models;
using ShtrihM.SCA.Packaging.DataTerminal.Controls;

namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  public partial class frmReplacement : ActionScanForm
  {

    public enum Field
    {
      Order = 0,
      Stock,
      Spec,
      Pallet,
      PalletsTotal,
      Prod,
      Customer
    }

    private const int listValueIndex = 1;
    private long _palletId = 0;

    public frmReplacement()
    {
      InitializeComponent();
      txtProdCode.OnCodeComplete += new ScanSSCC.OnCodeCompleteDelegate(txtProdCode_OnCodeComplete);
    }

    private void txtProdCode_OnCodeComplete()
    {
      var act = new Action(() =>
      {
        btnSearch_Click_1(this, new EventArgs());
      });
      FormHelper.HandleAction(act);
    }

    private void btnSearch_Click_1(object sender, EventArgs e)
    {
      var failed = false;
      var act = new Action(() =>
      {
        var code = txtProdCode.Text.Trim();
        try
        {
          FormHelper.ValidateProductCode(code);
          //get prod info
          var prod = Database.GetForMove(code, ShtrihM.SCA.Packaging.DataTerminal.Models.LoginModel.User.Id);
          //an unified approach to set a value in the treeview from DataRow
          //FormHelper.ClearListView(lstData);
          _palletId = _palletId = Convert.ToInt64(prod["ID"]);
          var setVal = new Action<string, Field>((v, f) =>
          {
            //lstData.Items[(int)f].SubItems[listValueIndex].Text = string.Empty;
            lstData.Items[(int)f].SubItems[listValueIndex].Text = ConversionHelper.ToString(prod[v]);
          });
      
          //set node's values in the treeview
          setVal("CustName", Field.Customer);
          setVal("NoPallets", Field.PalletsTotal);
          setVal("SpecNumber", Field.Spec);
          setVal("OrderNumber", Field.Order);
          setVal("PalletNumber", Field.Pallet);
          setVal("ProdName", Field.Prod);
          setVal("Stock", Field.Stock);
          btnAccept.Enabled = true;
        }
        catch (ExternalException)
        {
          failed = true;
          throw;
        }
        catch (Exception ex)
        {
          failed = true;
          var msg = string.Format("Полученные данные об изделии с номером {0} явл. некорректными.", code);
          throw new ExternalException(msg, ex);
        }
        finally
        {
          if (failed == true)
          {
            Clear();
          }
        }
      });
      FormHelper.HandleAction(act);
    }

    private void Clear()
    {
      var act = new Action(() =>
      {
        txtNewBin.Text = string.Empty;
        txtProdCode.Text = string.Empty;
        for (var i = 0; i < lstData.Items.Count; i++)
        {
          var subs = lstData.Items[i];
          for (var j = 1; j < subs.SubItems.Count; j++)
          {
            subs.SubItems[j].Text = string.Empty;
          }
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnAccept_Click_1(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        var code = txtProdCode.Text.Trim();
        string bin;
        try
        {
          FormHelper.ValidateProductCode(code);
          //get prod info
          bin = txtNewBin.Text.Trim();
          if (string.IsNullOrEmpty(bin))
          {
            throw new ExternalException("Не указано \"Новое место хранения\".");
          }
          //long palletId = long.Parse(lstData.Items[(int)Field.Pallet].SubItems[listValueIndex].Text);
          int leftPallets = Database.MoveBin(_palletId, bin, ShtrihM.SCA.Packaging.DataTerminal.Models.LoginModel.User.Id);

          switch (leftPallets)
          {
            case 0:
              throw new ExternalException("Выберите другую ячейку.");
            case -1:
              throw new ExternalException("Текущую паллету использовать нельзя.");
          }
          var msg = string.Format("Продукция была успешно перемещена.", code);
          FormHelper.ShowInfo(msg);
          txtNewBin.Text = string.Empty;
          txtProdCode.Text = string.Empty;

          //FormHelper.ClearTreeview(tvProduct);
          //FormHelper.ClearListView(lstData);
          for (int i = 0; i < lstData.Items.Count; i++)
          {
            var subs = lstData.Items[i].SubItems;
            subs[listValueIndex].Text = string.Empty;
          }
          txtProdCode.Focus();
        }
        catch (ExternalException ext)
        {
          txtNewBin.Focus();
          throw ext;
        }
        catch (Exception ex)
        {
          var msg = string.Format("Продукция с номером {0} не была перемещена.", code);
          throw new ExternalException(msg, ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    public override long ActionStartId
    {
      get { return 2; }
    }

    public override long ActionFinishId
    {
      get { return 12; }
    }

    /*public override void OnScanInternal(int type, string data)
    {
      var act = new Action(() =>
      {
        if (string.IsNullOrEmpty(txtProdCode.Text))
        {
          txtProdCode.Text = data;
        }
        else
        {
          txtNewBin.Text = data;
        }
      });
      this.Invoke(() => FormHelper.HandleAction(act));
    }*/
  }
}