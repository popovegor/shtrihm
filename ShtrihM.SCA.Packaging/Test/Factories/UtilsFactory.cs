using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Utils;

namespace ShtrihM.SCA.Packaging.Test.Factories
{
  public class UtilsFactory
  {
    public class FakeLogWriter : ILogWriter
    {
      #region ILogWriter Members
      
      public List<string> Messages {get; private set;}
      
      public List<Exception> Exceptions {get; private set;}

      public FakeLogWriter()
      {
        Messages = new List<string>();
      }

      public void Write(string msg)
      {
         Messages.Add(msg);
      }

      public void Write(Exception e)
      {
        Exceptions.Add(e);
      }

      #endregion
    }

  }
}
