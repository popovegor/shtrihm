using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SCA.Packaging.Localization;

namespace SCA.Packaging.Domain.Exceptions
{
  public class ProductCodeFormatException : UserNotificationException
  {
    public ProductCodeFormatException(string code)
      : base(string.Format(Msgs.product_code_0_is_invalid, code))
    {

    }

  }
}
