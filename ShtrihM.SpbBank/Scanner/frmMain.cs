using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShtrihM.SpbBank.BL;
using MCSSLibNet;
using System.Runtime.InteropServices;

namespace ShtrihM.SpbBank.Scanner
{

  public partial class frmMain : Form
  {
    public BarCode _brAtm = new BarCode();
    BaseScannerControl _scanner;

    public frmMain()
    {
      InitializeComponent();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      if (new DataMemento().HasState == true)
      {
        if (DialogResult.Yes == MessageBox.Show(
          "При последнем запуске программа была закрыта некорректно. Хотите восстановить работу и продолжить сбор данных?"
          , "Восстановление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question
          , MessageBoxDefaultButton.Button2))
        {
          Restore();
        }
      }

      //populate the list with test data
      /*for (int i = 0; i < 100; i++)
      {
        lstData.SuspendLayout();
        var l = new ListViewItem(new string[] { (i % 20).ToString(), i.ToString() });
        lstData.Items.Add(l);
        lstData.ResumeLayout();
      }*/
    }

    private void OnScan(object sender, ScannerDataArgs args)
    {
      if (string.IsNullOrEmpty(args.ScanData) == false)
      {
        if (_brAtm.IsEmpty == false)
        {
          AddBarcode(new BarCode(args.ScanType, args.ScanData));
        }
        //txtAtmNumber.Text = args.ScanData;
        //_br.BarCodeData = args.ScanData;
        //_br.BarCodeType = args.ScanType;
      }
    }

    private void frmMain_Closing(object sender, CancelEventArgs e)
    {
      DialogResult res = MessageBox.Show(
        "Вы уверены, что хотите выйти из программы?"
        , "Выход из программы", MessageBoxButtons.YesNo
        , MessageBoxIcon.Question
        , MessageBoxDefaultButton.Button2);
      if (res == DialogResult.No)
      {
        e.Cancel = true;
      }
      else
      {
        new DataMemento().RemoveState();
        if (_scanner != null)
        {
          _scanner.Close();
          _scanner = null;
        }
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      //throw new Exception();
      this.Close();
    }

    private void btnCollect_Click(object sender, EventArgs e)
    {
      if (_scanner != null)
      {
        _scanner.Close();
        _scanner = null;
      }
      BarCode br = new BarCode();
      frmSetAtm form = new frmSetAtm(ref br);
      form.Focus();
      if (form.ShowDialog() == DialogResult.OK)
      {
        if (br.IsEmpty == false)
        {
          lblAtmNumber.Text = br.BarCodeData;
          lblAtmNumber.ForeColor = Color.Red;
          _brAtm = br;
          //btnAddNest.Enabled = true;
          //btnAddNest.Focus();
          btnCollect.Text = "След. банкомат";
          btnClear.Enabled = false;
        }
      }
      else
      {
        //TODO:if the barcode is empty
      }

      if (_brAtm.IsEmpty == false)
      {
        _scanner = new BaseScannerControl(OnScan, this);
        _scanner.Init();
      }

    }

    private void btnAddNest_Click(object sender, EventArgs e)
    {
      BarCode br = new BarCode();
      frmSetNest form = new frmSetNest(ref br);
      form.Focus();
      if (form.ShowDialog() == DialogResult.OK)
      {
        AddBarcode(br);
      }
      else
      {
        //TODO:if the barcode is empty
      }
    }

    private void AddBarcode(BarCode br)
    {
      if (br.IsEmpty == false && _brAtm.IsEmpty == false)
      {
        int indexInList;
        var existing = FindBarCode(br.BarCodeData, out indexInList);
        if (existing.HasValue)
        {
          //такой штрих код есть в текущем банкомате - ничего делать не надо
          if (_brAtm.BarCodeData.Equals(existing.Value.Key, StringComparison.InvariantCultureIgnoreCase))
          {
            MessageBox.Show(
              string.Format("Штрихкод {0} уже был считан ранее для текущего банкомата.", br.BarCodeData)
              , "Повторное считывание штрихкода", MessageBoxButtons.OK
              , MessageBoxIcon.Asterisk
              , MessageBoxDefaultButton.Button1);
          }
          else //такой шк уже есть, но в другом банкомате, заменить?
          {
            DialogResult res = MessageBox.Show(
             string.Format("Штрихкод {0} уже был считан ранее для банкомата № {1}. Хотите заменить его?", existing.Value.Value, existing.Value.Key)
             , "Повторное считывание штрихкода", MessageBoxButtons.YesNo
             , MessageBoxIcon.Question
             , MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
              btnExport.Enabled = true;
              lstData.Items.RemoveAt(indexInList);
              ListViewItem item = new ListViewItem(
              new string[] { _brAtm.BarCodeData, br.BarCodeData });
              lstData.Items.Insert(0, item);
              btnClear.Enabled = false;
            }
          }
        }
        else
        {
          //новый шк - добавляем
          btnExport.Enabled = true;
          ListViewItem item = new ListViewItem(
          new string[] { _brAtm.BarCodeData, br.BarCodeData });
          lstData.Items.Insert(0, item);
          btnClear.Enabled = false;
        }

        Backup();
      }
    }

    private KeyValuePair<string, string>? FindBarCode(string code, out int indexInList)
    {
      KeyValuePair<string, string>? item = null;
      indexInList = 0;
      if (string.IsNullOrEmpty(code) == false && lstData.Items.Count > 0)
      {
        foreach (ListViewItem v in lstData.Items)
        {
          if (v.SubItems.Count >= 2)
          {
            var atm = v.SubItems[0].Text;
            var c = v.SubItems[1].Text;
            if (c.Equals(code, StringComparison.InvariantCultureIgnoreCase))
            {
              item = new KeyValuePair<string, string>(atm, c);
              indexInList = v.Index;
              break;
            }
          }
        }
      }
      return item;
    }

    private void Restore()
    {
      try
      {
        DataMemento mem = new DataMemento();
        List<DataMemento.DataItem> data = mem.GetState();
        foreach (DataMemento.DataItem row in data)
        {
          ListViewItem li = new ListViewItem(
          new string[] { row.Atm, row.Barcode });
          lstData.Items.Insert(0, li);
        }
        if (data.Count > 0)
        {
          //btnCollect.Text = "След. банкомат";
          //btnAddNest.Enabled = false;
          btnExport.Enabled = true;
        }
      }
      catch (Exception)
      {
        //TODO:
      }
    }

    private void Backup()
    {
      try
      {
        List<DataMemento.DataItem> data = new List<DataMemento.DataItem>();
        for (int i = lstData.Items.Count - 1; i >= 0; i--)
        {
          ListViewItem item = lstData.Items[i];
          string atm = item.SubItems[0].Text;
          string nest = item.SubItems[1].Text;
          data.Add(new DataMemento.DataItem(atm, nest));
        }
        DataMemento mem = new DataMemento();
        mem.SetState(data);
      }
      catch (Exception)
      {
        //TODO: handle an exception
      }
    }


    private void btnExport_Click(object sender, EventArgs e)
    {
      /*SaveFileDialog dlg = new SaveFileDialog();
      string dir = "temp";
      if (Directory.Exists(dir))
      {
        dlg.InitialDirectory = "\\temp";
      }
      if (dlg.ShowDialog() == DialogResult.OK)
      {*/
      //string file = string.Concat(dlg.FileName.TrimEnd(".txt".ToCharArray()), ".txt");
      string file = @"\temp\data.txt";
      if (ExportData(file) == true)
      {
        MessageBox.Show(
         string.Format("Данные были успешно выгружены в следующий файл „{0}“", file)
         , "Выгрузка данных");
        btnClear.Enabled = true;
      }
      else
      {
        MessageBox.Show(
         string.Format("Данные не были выгружены в следующий файл „{0}“", file)
         , "Произошла ошибка выгрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
      }
      /*}*/
    }

    private bool ExportData(string file)
    {
      bool success = false;
      try
      {
        using (FileStream stream = File.Create(file))
        {
          for (int i = lstData.Items.Count - 1; i >= 0; i--)
          {
            ListViewItem item = lstData.Items[i];
            string atm = item.SubItems[0].Text;
            string nest = item.SubItems[1].Text;
            string row = string.Format("P;{0};{1}{2}", atm, nest, "\r\n");
            byte[] bytes = Encoding.Default.GetBytes(row);
            stream.Write(bytes, 0, bytes.Length);
          }
          success = true;
        }
      }
      catch (Exception e)
      {
        success = false;
        throw e;
      }
      return success;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      if (DialogResult.Yes
        == MessageBox.Show("Вы уверены, что хотите очистить введенные данные?",
        "Очистка данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
      {
        for (var i = lstData.Items.Count - 1; i >= 0; i--)
        {
          lstData.Items.RemoveAt(i);
        }
        btnClear.Enabled = false;
        btnAddNest.Enabled = false;
        btnExport.Enabled = false;
        btnCollect.Text = "Сбор данных";
        lblAtmNumber.Text = "не указан";
      }
    }

    private void btnFirst_Click(object sender, EventArgs e)
    {
      SelectListItem(0);
    }


    private void SelectListItem(int index)
    {
      if (lstData.Items.Count > 0)
      {
        foreach (ListViewItem v in lstData.Items)
        {
          if (v.Index == index)
          {
            v.Focused = true;
            v.Selected = true;
            lstData.EnsureVisible(index);
            break;
          }
        }
      }
    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
      if (lstData.FocusedItem != null && lstData.FocusedItem.Selected && lstData.FocusedItem.Index > 0)
      {
        SelectListItem(lstData.FocusedItem.Index - 1);
      }
      else
      {
        SelectListItem(0);
      }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      if (lstData.FocusedItem != null && lstData.FocusedItem.Selected && lstData.FocusedItem.Index < lstData.Items.Count - 1)
      {
        SelectListItem(lstData.FocusedItem.Index + 1);
      }
      else
      {
        SelectListItem(0);
      }
    }

    private void btnLast_Click(object sender, EventArgs e)
    {
      SelectListItem(lstData.Items.Count - 1);
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      if (lstData.FocusedItem != null && lstData.FocusedItem.Selected)
      {
        if (DialogResult.Yes
          == MessageBox.Show("Вы уверены, что хотите удалить запись?",
          "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
        {
          lstData.Items.RemoveAt(lstData.FocusedItem.Index);
          SelectListItem(lstData.FocusedItem.Index);
        }
      }
      else
      {
        MessageBox.Show("Не выбрана ни одна запись?",
         "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
      }
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      var form = new frmSearch(ref lstData);
      form.Focus();
      form.ShowDialog();
      this.Focus();
    }
  }
}