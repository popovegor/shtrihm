using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using System.Diagnostics;
using ShtrihM.SCA.Packaging.DataTerminal.Repositories;
using ShtrihM.SCA.Packaging.DataTerminal.Models;
using ShtrihM.SCA.Packaging.DataTerminal.Controls;

namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  public class BaseScanForm : BaseForm
  {
    //private ScanMessageWindow wnd;

    public delegate void OnScanDelegate(int type, string data);

    public event OnScanDelegate OnScan;

    public BaseScanForm()
    {
      this.Load += new EventHandler(BaseScanForm_Load);
      this.Closed += new EventHandler(BaseScanForm_Closed);
      //wnd = new ScanMessageWindow(this);
    }

    void BaseScanForm_Closed(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          ScanHelper.Close();
          foreach (Control ctl in this.Controls)
          {
            ctl.KeyUp -= new KeyEventHandler(HandleKeyUp);
          }
          //this.KeyUp -= new KeyEventHandler(HandleKeyUp);
          OnClose();
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось корректно закрыть форму. Произошла внутренняя ошибка приложения.", ex);
        }
        finally
        {
          this.Load -= new EventHandler(BaseScanForm_Load);
          this.Closed -= new EventHandler(BaseScanForm_Closed);
        }
      });
      FormHelper.HandleAction(act);
    }

    public void HandleKeyUp(object sender, KeyEventArgs e)
    {
      switch (e.KeyValue)
      {
        case 125:
          ScanInternal();
          break;
      }
    }

    protected virtual void OnClose()
    {
    }

    protected virtual void OnOpen()
    {
    }

    void BaseScanForm_Load(object sender, EventArgs e)
    {
      var act = new Action(() =>
      {
        try
        {
          ScanHelper.Init(new ScanHelper.OnScanDataDelegate(OnScanInternal));
          //set a handler for controls on a keyup event
          foreach (Control ctl in this.Controls)
          {
            ctl.KeyUp += new KeyEventHandler(HandleKeyUp);
          }
          //this.KeyUp += new KeyEventHandler(HandleKeyUp);
          OnOpen();
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось корректно открыть форму. Произошла внутренняя ошибка приложения.", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    private void ScanInternal()
    {
      ScanHelper.CancelRead();
      ScanHelper.Read();
    }

    protected virtual void OnScanInternal(int type, string data)
    {
      //if( OnScan != null)
      //{
      //OnScan(type, data);
      var act = new Action(() =>
      {
        foreach (Control ctl in this.Controls)
        {
          if (ctl.Focused && (ctl is IScanControl))
          {
            (ctl as IScanControl).OnScan(type, data);
          }
        }
      });
      this.Invoke(() => FormHelper.HandleAction(act));
      //}
    }
  }
}
