using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SCA.Packaging.Domain.Exceptions
{
  public class EntityNotFoundException : UserNotificationException
  {
    public EntityNotFoundException(string msg)
      : base(msg)
    {
    }
  }
}
