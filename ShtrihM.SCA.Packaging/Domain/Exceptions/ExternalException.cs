using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ShtrihM.SCA.Packaging.Domain.Exceptions
{
  public class ExternalException : Exception
  {
    public ExternalException(string msg, Exception inner)
      : base(msg, inner)
    {
      Debug.WriteLine(msg);
    }

    public ExternalException(string msg)
      : this(msg, null)
    {

    }

    public ExternalException()
      : this(null, null)
    {

    }
  }
}
