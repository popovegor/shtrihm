using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShtrihM.SpbBank.Scanner
{
  public partial class frmSearch : Form
  {
    ListView _data = null;

    public frmSearch(ref ListView lst)
    {
      _data = lst;
      InitializeComponent();
      cmbAtm.DropDownStyle = ComboBoxStyle.DropDown;
      cmbAtm.SuspendLayout();
      foreach (ListViewItem item in _data.Items)
      {
        if (item != null && item.SubItems.Count >= 2)
        {
          if (cmbAtm.Items.Contains(item.SubItems[0].Text) == false)
          {
            cmbAtm.Items.Add(item.SubItems[0].Text);
          }
        }
      }
      cmbAtm.ResumeLayout();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      var atm = cmbAtm.Text;
      int index = -1;
      lstFiltered.SuspendLayout();
      lstFiltered.Items.Clear();
      if (_data != null)
      {
        foreach (ListViewItem v in _data.Items)
        {
          if (v.SubItems.Count >= 2 && v.SubItems[0].Text.Equals(atm, StringComparison.InvariantCultureIgnoreCase))
          {
            index = v.Index;
            lstFiltered.Items.Add(new ListViewItem(v.SubItems[1].Text));
          }
        }
      }
      if (index <= -1)
      {
        MessageBox.Show(string.Format("Не удалось найти записей для банкомата № {0}.", atm),
          "Нет записей", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
      }
      lstFiltered.ResumeLayout();
    }

    private void cmbAtm_KeyDown(object sender, KeyEventArgs e)
    {
      //cmbAtm.DropDown = true;
    }
  }
}