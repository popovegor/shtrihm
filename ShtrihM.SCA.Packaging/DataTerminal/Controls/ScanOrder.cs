using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShtrihM.SCA.Packaging.DataTerminal.Controls
{
  public partial class ScanOrder : ScanText, IScanControl
  {
    public delegate void OnCompleteDelegate();
    public event OnCompleteDelegate OnComplete;
  
    public ScanOrder()
    {
      InitializeComponent();
      //this.TextChanged += new EventHandler(ScanOrder_TextChanged);
    }

    public override void OnScan(int type, string data)
    {
      base.OnScan(type, data);
      if(OnComplete != null)
      {
        OnComplete();
      }
    }

    void ScanOrder_TextChanged(object sender, EventArgs e)
    {
      /*if (this.Text.Length >= Lenght)
      {
        if (OnCodeComplete != null)
        {
          OnCodeComplete();
        }
      }*/
    }
  }
}
