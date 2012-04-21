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
  public partial class frmSetAtm : Form
  {
    BaseScannerControl _scanner;
    BarCode _br = new BarCode();
    
    public frmSetAtm(ref BarCode br)
    {
      InitializeComponent();
      _scanner = new BaseScannerControl(OnScan, this);
      _scanner.Init();
      _br = br;
    }
    
    private void OnScan(object sender, ScannerDataArgs args)
    {
      if(string.IsNullOrEmpty(args.ScanData) == false)
      {
        txtAtmNumber.Text = args.ScanData;
        _br.BarCodeData = args.ScanData;
        _br.BarCodeType = args.ScanType;
        
      }
    }

    private void lblATM_ParentChanged(object sender, EventArgs e)
    {

    }

    private void frmSetATM_Load(object sender, EventArgs e)
    {
      txtAtmNumber.Focus();
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
      string atm = txtAtmNumber.Text.Trim();
      if(string.IsNullOrEmpty(atm) == true)
      {
        MessageBox.Show(
          string.Format("Укажите № банкомата, преждем чем нажать кнопку „{0}“.", btnApply.Text)
          , "Не указан № банкомата"
          , MessageBoxButtons.OK
          , MessageBoxIcon.Asterisk
          , MessageBoxDefaultButton.Button1);
      }
      else
      {
        _br.BarCodeData = atm;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void frmSetATM_Closing(object sender, CancelEventArgs e)
    {
      if (_scanner != null)
      {
        _scanner.Close();
        _scanner = null;
      }  
    }

    private void btnScan_Click(object sender, EventArgs e)
    {
      _scanner.ScanRead();
    }

    private void txtAtmNumber_GotFocus(object sender, EventArgs e)
    {
      
    }
  }
}