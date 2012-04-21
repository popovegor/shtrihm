using System;

using System.Collections.Generic;
using System.Text;
using MCSSLibNet;
using System.Windows.Forms;

namespace BarCodeScanner.Common
{
  public class BaseScannerControl
  {
    private ScannerControl _scanner = null;
    private bool _isReading = false;
    private bool _isKeyDown = true;
    private Form _frm = null;

    public BaseScannerControl(ScannerDataDelegate onScan, Form frm)
    {
      _scanner = new ScannerControl();

      if (onScan != null)
      {
        _scanner.ScannerDataEvent += onScan;
      }
      
      _frm = frm;

      if (_frm != null)
      {
        _frm.KeyDown += frm_KeyDown;
        _frm.KeyUp += frm_KeyUp;
        _frm.Activated += _frm_Activated;
        _frm.Load += _frm_Load;
        foreach(Control ctl in _frm.Controls)
        {
          ctl.KeyDown += frm_KeyDown;
          ctl.KeyUp += frm_KeyUp;
        }
      }
    }
    
    public void ScanRead()
    {
      if(_isReading == true)
      {
        _scanner.ScanReadCancel();
        _isReading = false;
      }
      else
      {
        _scanner.ScanRead();
        _isReading = true;
      }
    }

    private void _frm_Load(object sender, EventArgs e)
    {
      _scanner.RegisterRecieveForm();
    }

    private void _frm_Activated(object sender, EventArgs e)
    {
      _scanner.RegisterRecieveForm();
    }

    private void frm_KeyDown(object sender, KeyEventArgs e)
    {
      if (_isKeyDown == true)
      {
        if (e.KeyCode == Keys.F22)
        {
          _scanner.ScanRead();
        }
        _isKeyDown = false;
      }		
    }

    private void frm_KeyUp(object sender, KeyEventArgs e)
    {
      if (!_isKeyDown)
      {
        if (e.KeyCode == Keys.F22)
        {
          _scanner.ScanReadCancel();
        }
        _isKeyDown = true;
      }
    }

    public bool Init()
    {
      if (_scanner.ScanInit() != 0)
      {
        MessageBox.Show("Не удалось инициализировать сканер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        return false;
      }

      _scanner.SetDefaultOption();
      _scanner.UseDefaultSound(true, null);
      _scanner.UseResumeMsg(true);

      return true;
    }


    public void Close()
    {
      if(_frm != null)
      {
        _frm.KeyDown -= frm_KeyDown;
        _frm.KeyDown -= frm_KeyUp;
      }
      _scanner.ScanClose();
      _scanner = null;
    }
  }
}
