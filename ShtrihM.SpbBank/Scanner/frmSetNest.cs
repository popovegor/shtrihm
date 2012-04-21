using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MCSSLibNet;
using ShtrihM.SpbBank.BL;

namespace ShtrihM.SpbBank.Scanner
{
  public partial class frmSetNest : Form
  {

    BaseScannerControl _scanner;
    BarCode _br = new BarCode();

    public frmSetNest(ref BarCode br)
    {
      InitializeComponent();
      _scanner = new BaseScannerControl(OnScan, this);
      _scanner.Init();
      _br = br;
    }

    private void OnScan(object sender, ScannerDataArgs args)
    {
      if (string.IsNullOrEmpty(args.ScanData) == false)
      {
        txtNest.Text = args.ScanData;
        _br.BarCodeData = args.ScanData;
        _br.BarCodeType = args.ScanType;
      }
    }

    private void txtNest_TextChanged(object sender, EventArgs e)
    {
    }

    private void frmSetNest_Load(object sender, EventArgs e)
    {
      txtNest.Focus();
    }

    private void frmSetNest_Closing(object sender, CancelEventArgs e)
    {
      if (_scanner != null)
      {
        _scanner.Close();
        _scanner = null;
      } 
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
      string nest = txtNest.Text.Trim();
      if (string.IsNullOrEmpty(nest) == true)
      {
        MessageBox.Show(
          string.Format("Укажите штрихкод вложения, преждем чем нажать кнопку „{0}“.", btnApply.Text)
          , "Не указан штрихкод вложения"
          , MessageBoxButtons.OK
          , MessageBoxIcon.Asterisk
          , MessageBoxDefaultButton.Button1);
      }
      else
      {
        _br.BarCodeData = nest;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}