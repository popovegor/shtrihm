using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public class LogHelper
  {
    public static void Dump(Exception e)
    {
      var log = new LogHelper();
      log.Write(e);
    }

    public static void Dump(Exception e, string msg)
    {
      var log = new LogHelper();
      log.Write(e, msg);
    }

    private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LogHelper));

    private LogHelper()
    {
      var act = new Action(() =>
      {
        try
        {
          log4net.Config.XmlConfigurator.Configure(new FileInfo(ConfigHelper.GetConfigPath()));
        }
        catch (Exception ex)
        {
          throw new ExternalException("Не удалось инициализировать систему логирования.", ex);
        }
      });
      FormHelper.HandleAction(act);
    }

    public void Write(string msg)
    {
      log.Info(msg);
    }

    #region ILogWriter Members

    public void Write(Exception e, string msg)
    {
      log.Info(msg, e);
    }

    public void Write(Exception e)
    {
      log.Info(e.Message, e);
    }

    ~LogHelper()
    {
      try
      {
        log4net.LogManager.Shutdown();
      }
      catch (Exception)
      {
        //TODO:catches but does nothing
      }
    }

    #endregion
  }
}
