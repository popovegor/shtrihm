using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Forms;

namespace ShtrihM.SCA.Packaging.DataTerminal.Controls
{
  public partial class ScanSSCC : ScanText, IScanControl
  {
    private const int Lenght = 18;

    public delegate void OnCodeCompleteDelegate();
    public event OnCodeCompleteDelegate OnCodeComplete;

    public ScanSSCC()
    {
      InitializeComponent();
      this.TextChanged += new EventHandler(ScanSSCC_TextChanged);
    }

    void ScanSSCC_TextChanged(object sender, EventArgs e)
    {
      if (this.Text.Length >= Lenght)
      {
        if (OnCodeComplete != null)
        {
          OnCodeComplete();
        }
      }
    }



  }
}
