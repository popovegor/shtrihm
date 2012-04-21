using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShtrihM.SCA.Packaging.Domain.Utils
{
  public class LogWriter : ILogWriter
  {
    private readonly log4net.ILog log = log4net.LogManager.GetLogger("logger");
    
    public LogWriter()
    {
      log4net.Config.XmlConfigurator.Configure();
    }
    
    public void Write(string msg)
    {
      log.Info(msg);
    }

    #region ILogWriter Members


    public void Write(Exception e)
    {
      log.Error(e.Message, e);
    }

    ~LogWriter()
    {
      try
      {
        log4net.LogManager.Shutdown();
      }
      catch(Exception)
      {
        //TODO:catches but does nothing
      }
    }

    #endregion
  }
}
