using System;
namespace ShtrihM.SCA.Packaging.Domain.Utils
{
  public interface ILogWriter
  {
    void Write(string msg);
    void Write(Exception e);
  }
}
