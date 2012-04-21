using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;
using ShtrihM.SCA.Packaging.DataTerminal.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;

namespace ShtrihM.SCA.Packaging.DataTerminal.Controls
{
  public partial class ScanText : TextBox, IScanControl
  {
    //private BaseScanForm _frm;

    public ScanText()
    {
      InitializeComponent();
      //if(frm == null)
      //{
      //  throw new ArgumentNullException("frm");
      //}
      //_frm = frm;
      this.GotFocus += new EventHandler(ScanText_GotFocus);
      this.LostFocus += new EventHandler(ScanText_LostFocus);
    }

    /*private void ScanText_KeyUp(object sender, KeyEventArgs e)
    {
      _frm.HandleKeyUp(sender, e);
    }*/

    public virtual void OnScan(int type, string data)
    {
      var act = new Action(() => {
        Text = data ?? string.Empty;  
      });
      this.Invoke(() => FormHelper.HandleAction(act));
    }

    void ScanText_GotFocus(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        //this.KeyUp += new KeyEventHandler(ScanText_KeyUp);
        //_frm.OnScan += new BaseScanForm.OnScanDelegate(OnScan);
        FormHelper.GotFocus(this);
      });
      FormHelper.HandleAction(act);
    }

    void ScanText_LostFocus(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        //this.KeyUp -= new KeyEventHandler(ScanText_KeyUp);
        //_frm.OnScan -= new BaseScanForm.OnScanDelegate(OnScan);
        FormHelper.LostFocus(this);
      });
      FormHelper.HandleAction(act);
    }


  }
}
