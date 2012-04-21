using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;

namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  public class BaseForm : Form
  {
    public BaseForm()
    {
      this.GotFocus += new EventHandler(BaseForm_GotFocus);
      //this.LostFocus += new EventHandler(BaseForm_LostFocus);
    }

    void BaseForm_LostFocus(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        KioskHelper.BackNormalScreen();
      });
      FormHelper.HandleAction(act);
    }

    void BaseForm_GotFocus(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        KioskHelper.SetFullScreen(string.Empty);
      });
      FormHelper.HandleAction(act);
    }

    void BaseForm_Closed(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        KioskHelper.BackNormalScreen();
      });
      //FormHelper.HandleAction(act);
    }

    void BaseForm_Load(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        KioskHelper.SetFullScreen(string.Empty);
      });
      FormHelper.HandleAction(act);
    }
  }
}
