using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShtrihM.SCA.Packaging.DataTerminal.Exceptions
{
  /// <summary>
  /// Exceptions of this type is only for programming internal errors
  /// </summary>
  public class InternalException : Exception
  {
    public InternalException(string msg, Exception nested)
      : base(msg, nested)
    {
    }

    public InternalException(Exception nested)
      : this(string.Empty, nested)
    {

    }
  }
}
