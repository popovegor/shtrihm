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
  public partial class frmPlacement : ActionScanForm
  {

    public enum Field
    {
      Order = 0,
      //Stock = 1,
      Spec,
      Pallet,
      PalletsTotal,
      Prod,
      Customer
    }

    //private bool placed = false;
    private long _palletId = 0;
    private const int listValueIndex = 1;

    public frmPlacement()
    {
      InitializeComponent();
      txtProdCode.OnCodeComplete += new ScanSSCC.OnCodeCompleteDelegate(txtProdCode_OnCodeComplete);
    }

    private void txtProdCode_OnCodeComplete()
    {
      var act = new Action(() =>
      {
        btnSearch_Click(this, new EventArgs());
      });
      this.Invoke(() => FormHelper.HandleAction(act));
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      var failed = false;
      var act = new Action(() =>
      {
        string code = txtProdCode.Text.Trim();
        try
        {
          FormHelper.ValidateProductCode(code);
          var Prod = Database.GetProduct(code);
          var bin = ConversionHelper.ToString(Prod["BinName"]);
          txtBin.Text = bin.Equals("0", StringComparison.InvariantCultureIgnoreCase) ? string.Empty : bin;

          _palletId = Convert.ToInt64(Prod["PalletID"]);
          //placed = txtBin.Text.Equals("0", StringComparison.InvariantCultureIgnoreCase);
          //FormHelper.ClearListView(lstData);
          var setVal = new Action<string, Field>((v, f) =>
          {
            lstData.Items[(int)f].SubItems[listValueIndex].Text = string.Empty;
            lstData.Items[(int)f].SubItems[listValueIndex].Text = ConversionHelper.ToString(Prod[v]);
          });
          setVal("CustName", Field.Customer);
          setVal("NoPallets", Field.PalletsTotal);
          setVal("SpecNumber", Field.Spec);
          setVal("OrderNumber", Field.Order);
          setVal("PalletNumber", Field.Pallet);
          setVal("ProdName", Field.Prod);
          txtBin.Focus();
        }
        catch (ExternalException)
        {
          failed = true;
          throw;
        }
        catch (Exception ex)
        {
          failed = true;
          var msg = string.Format("Полученные данные о продукции с кодом {0} явл. некорректными.", code);
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
      //var act2 = new Action(() => { Clear(); });
      FormHelper.HandleAction(act);
    }

    private void Clear()
    {
      var act = new Action(() =>
      {
        txtBin.Text = string.Empty;
        txtProdCode.Text = string.Empty;
        for (var i = 0; i < lstData.Items.Count; i++)
        {
          var subs = lstData.Items[i];
          for (var j = 1; j < subs.SubItems.Count; j++)
          {
            subs.SubItems[j].Text = string.Empty;
          }
        }
        txtProdCode.Focus();
      });
      FormHelper.HandleAction(act);
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        var code = txtProdCode.Text.Trim();
        try
        {
          FormHelper.ValidateProductCode(code);
          var bin = txtBin.Text.Trim();
          FormHelper.ValidateBin(bin);
          var leftPallets = Database.PutToBin(_palletId, code, bin, ShtrihM.SCA.Packaging.DataTerminal.Models.LoginModel.User.Id);
          if (leftPallets == 0)
          {
            throw new ExternalException("Размещение продукции в выбранную ячейку невозможно, укажите другую ячейку.");
          }
          if (leftPallets == -1)
          {
            throw new ExternalException("Повторное размещение недопустимо.");
          }
          var msg = "Продукция была успешно оприходована.";
          FormHelper.ShowInfo(msg);
          txtBin.Text = string.Empty;
          txtProdCode.Text = string.Empty;
          _palletId = default(long);
          for (int i = 0; i < lstData.Items.Count; i++)
          {
            var subs = lstData.Items[i].SubItems;
            subs[listValueIndex].Text = string.Empty;
          }
          txtProdCode.Focus();
        }
        catch (ExternalException)
        {
          txtBin.Focus();
          throw;
        }
        catch (Exception ex)
        {
          var msg = string.Format("Не удалось разместить продукцию c кодом {0}.", code);
          throw new ExternalException(msg, ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    public override long ActionStartId
    {
      get { return 1; }
    }

    public override long ActionFinishId
    {
      get { return 11; }
    }

    /*public override void OnScan(int type, string data)
    {
      var act = new Action(() =>
      {
        if (string.IsNullOrEmpty(txtProdCode.Text))
        {
          txtProdCode.Text = data;
        }
        else
        {
          txtBin.Text = data;
        }
      });
      this.Invoke(() => FormHelper.HandleAction(act));
    }*/
  }
}