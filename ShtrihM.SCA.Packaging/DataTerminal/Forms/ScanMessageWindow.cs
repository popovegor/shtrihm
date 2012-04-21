using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsCE.Forms;

namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  public class ScanMessageWindow : MessageWindow
  {
    // Assign integers to messages.
    // Note that custom Window messages start at WM_USER = 0x400.
    public const int WM_CUSTOMMSG = 0x0400;


    // Create an instance of the form.
    private BaseScanForm _frm;

    // Save a reference to the form so it can
    // be notified when messages are received.
    public ScanMessageWindow(BaseScanForm frm)
    {
      this._frm = frm;
    }

    // Override the default WndProc behavior to examine messages.
    protected override void WndProc(ref Message msg)
    {
      switch (msg.Msg)
      {
        case WM_CUSTOMMSG:
          this._frm.Scan();
          break;
      }
      // Call the base WndProc method
      // to process any messages not handled.
      base.WndProc(ref msg);
    }
  }
}
