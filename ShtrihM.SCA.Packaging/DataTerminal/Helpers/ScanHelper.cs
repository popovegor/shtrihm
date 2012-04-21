using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public static class ScanHelper
  {
    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void OnScanDataWrapperDelegate(int type, string data);

    [DllImport("MM3.KScanBarWrapper.dll")]
    private static extern bool ScanInit(OnScanDataWrapperDelegate callback);

    [DllImport("MM3.KScanBarWrapper.dll")]
    private static extern void ScanRead();

    [DllImport("MM3.KScanBarWrapper.dll")]
    private static extern void ScanClose();

    [DllImport("MM3.KScanBarWrapper.dll")]
    private static extern void ScanReadCancel();

    private static void OnScanDataWrapper(int type, string data)
    {
      //_scanning = false;
      SoundHelper.Beep();
      if (_callback != null)
      {
        //convert data from unicode to ascii
        if (string.IsNullOrEmpty(data) == false)
        {
          var b = Encoding.Unicode.GetBytes(data);
          var d = Encoding.ASCII.GetString(b, 0, b.Length);
          _callback(type, d);
        }
        else
        {
          _callback(type, string.Empty);
        }
      }
    }

    private static OnScanDataDelegate _callback; //called by the '_onScan'
    private static OnScanDataWrapperDelegate _onScan; //calls the '_callback'
    //private static bool _scanning = false;

    public delegate void OnScanDataDelegate(int type, string data);

    public static bool Init(OnScanDataDelegate callback)
    {
      try
      {
        //_scanning = false;
        _onScan = new OnScanDataWrapperDelegate(OnScanDataWrapper);
        _callback = callback;
        return ScanInit(_onScan);
      }
      catch (Exception e)
      {
        _onScan = null;
        _callback = null;
        throw new ExternalException("Не удалось инициализировать сканер.", e);
      }
    }

    public static void CancelRead()
    {
      try
      {
        //ScanReadCancel();
       //_scanning = false;
      }
      catch (Exception e)
      {
        throw new ExternalException("Не удалось отменить операци. сканирования.", e);
      }
    }

    public static void Read()
    {
      try
      {
        //CancelRead();
        ScanRead();
      }
      catch (Exception e)
      {
        throw new ExternalException("Не удалось включить сканер.", e);
      }
    }

    public static void Close()
    {
      try
      {
        //CancelRead();
        ScanClose();
      }
      catch (Exception e)
      {
        throw new ExternalException("Не удалось выключить сканер.", e);
      }
      finally
      {
        _onScan = null;
        _callback = null;
      }
    }
  }
}
