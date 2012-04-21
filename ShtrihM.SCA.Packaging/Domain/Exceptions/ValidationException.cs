using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SCA.Packaging.Domain.Entities;

namespace SCA.Packaging.Domain.Exceptions
{
  public class ValidationException : UserNotificationException
  {
    public IEntity Entity { get; private set; }

    public ValidationException(IEntity e, string message) : base(message)
    {
      
    }
  }
}
