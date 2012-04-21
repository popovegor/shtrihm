using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SCA.Packaging.Domain.Exceptions
{
  public class RepositoryException : UserNotificationException
  {
    public RepositoryException(string msg, Exception inner) : base(msg, inner)
    {

    }
  }
}
