using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SCA.Packaging.Localization;

namespace SCA.Packaging.Domain.Exceptions
{
  public class ProductCodeNullException : UserNotificationException
  {
    public ProductCodeNullException(string msg)
      : base(msg)
    {

    }
  }
}
