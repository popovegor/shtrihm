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
  public partial class frmLoading : ActionScanForm
  {
    long? listId = null;

    public frmLoading()
    {
      InitializeComponent();
      txtOrder.OnComplete += new ScanOrder.OnCompleteDelegate(txtOrder_OnComplete);
      lstData.OnComplete += new PalletList.OnCompleteDelegate(lstData_OnComplete);
      btnAccept.Click += new EventHandler(btnAccept_Click);
      btnCancel.Click += new EventHandler(btnCancel_Click);
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        if (listId.HasValue == true)
        {
          if (FormHelper.ShowPrompt("Вы уверены, что хотите прервать задание на отгрузку?") == DialogResult.Yes)
          {
            Database.EndOfPickingList(listId.Value, 1, ShtrihM.SCA.Packaging.DataTerminal.Models.LoginModel.User.Id);
            FormHelper.ShowInfo("Задание на отгрузку было прервано.");
            this.Close();
          }
        }
        else
        {
          this.Close();
        }
      });
      FormHelper.HandleAction(act);
    }

    void lstData_OnComplete()
    {
      var act = new Action(() =>
      {
        btnAccept_Click(this, new EventArgs());
      });
      this.Invoke(() => FormHelper.HandleAction(act));
    }

    void txtOrder_OnComplete()
    {
      var act = new Action(() =>
      {
        btnLoad_Click(this, new EventArgs());
      });
      this.Invoke(() => FormHelper.HandleAction(act));
    }

    private void frmLoading_Load(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        lstData.Counter = lblCounter;
        FormHelper.ClearListView(lstData, true);
      });
      FormHelper.HandleAction(act);
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          var num = txtOrder.Text.Trim();
          //validate input data
          if (string.IsNullOrEmpty(num))
          {
            var msg = "Не указан номер задания.";
            throw new ExternalException(msg);
          }
          try
          {
            listId = long.Parse(num);
          }
          catch (Exception ex)
          {
            var msg = "Неверный формат введенного номера задания: допустимы только целочисленные значения.";
            throw new ExternalException(msg, ex);
          }

          //get info from database
          var data = Database.LoadPickingList(listId.Value, 3, ShtrihM.SCA.Packaging.DataTerminal.Models.LoginModel.User.Id);
          FormHelper.ClearListView(lstData, true);
          //if all pallets have OK status [2]
          if (data.Rows.Cast<DataRow>().All((row) => false == "1".Equals(ConversionHelper.ToString(row["Status"]))))
          {
            FormHelper.ShowInfo("Задание на отгрузку уже обработано.");
            listId = null;
            txtOrder.Text = string.Empty;
            txtOrder.Focus();
          }
          else
          {
            //set total and done values of the counters
            foreach (DataRow row in data.Rows)
            {
              var item = new ListViewItem(new string[] {
              ConversionHelper.ToString(row["TaskListID"])
              , ConversionHelper.ToString(row["SSCCNumber"])
              , ConversionHelper.ToString(row["BinName"])
              , "1".Equals(ConversionHelper.ToString(row["Status"]),StringComparison.InvariantCultureIgnoreCase) 
                ? string.Empty : PalletList.OK });
              lstData.Items.Add(item);
            }
            lstData.Focus();
          }
          lstData.UpdateCounters(lstData);
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception ex)
        {
          var msg = "Полученные данные о продукции явл. некорректными.";
          throw new ExternalException(msg, ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          int total, done;
          lstData.GetCounters(lstData, out total, out done);
          if (total == 0 || listId.HasValue == false)
          {
            txtOrder.Focus();
            throw new ExternalException("Задание на отгрузку не загружено.");
          }
          if (done < total)
          {
            lstData.Focus();
            throw new ExternalException("Нельзя завершить задание на отгрузку, так как часть продукции не обработана.");
          }
          Database.EndOfPickingList(listId.Value, 2, ShtrihM.SCA.Packaging.DataTerminal.Models.LoginModel.User.Id);
          FormHelper.ShowInfo("Задание на отгрузку успешно завершено.");
          listId = null;
          txtOrder.Text = string.Empty;
          FormHelper.ClearListView(lstData, true);
          lstData.UpdateCounters(lstData);
          this.Close();
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception ex)
        {
          var msg = "Не удалось завершить задание на отгрузку.";
          throw new ExternalException(msg, ex);
        }
      });
      FormHelper.HandleAction(act);
    }



    private void frmInventory_Closing(object sender, CancelEventArgs e)
    {

    }

    /*protected override void OnScanInternal(int type, string data)
    {
      var act = new Action(() =>
      {
        if (listId.HasValue == false)
        {
          txtNumber.Text = data;
        }
        else
        {
          long taskid = default(long);
          try
          {
            taskid = long.Parse(data);
          }
          catch (Exception e)
          {
            throw new ExternalException("Сканируемое значение штрих-кода не может быть преобразовано к целочисленному типу.", e);
          }
          CheckPallet(taskid);
        }
      });
      this.Invoke(() => FormHelper.HandleAction(act));
    }*/

    public override long ActionStartId
    {
      get { return 3; }
    }

    public override long ActionFinishId
    {
      get { return 13; }
    }
  }
}