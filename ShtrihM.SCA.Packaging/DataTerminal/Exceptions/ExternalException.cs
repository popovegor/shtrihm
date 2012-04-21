using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShtrihM.SCA.Packaging.DataTerminal.Exceptions
{
  /// <summary>
  /// Exceptions of this type that will be seen by the user
  /// </summary>
  public class ExternalException : Exception
  {
    public ExternalException(string msg, Exception nested)
      : base(msg, nested)
    {
    }

    public ExternalException(Exception nested)
      : this(string.Empty, nested)
    {

    }

    public ExternalException(string msg) : this(msg, null)
    {

    }
  }
}
