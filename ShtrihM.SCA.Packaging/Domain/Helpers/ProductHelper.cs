using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using System.Diagnostics;
using ShtrihM.SCA.Packaging.Localization;

namespace ShtrihM.SCA.Packaging.Domain.Helpers
{
  public static class ProductHelper
  {
    /// <summary>
    /// Parses the product code
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns></returns>
    /// <exception cref="ExternalException"/>
    public static ProductNumber ParseProductCode(string code)
    {
      return new ProductNumber(code);
    }
  
    public sealed class ProductNumber
    {
      public string Order { get; set; }
      public string Suborder { get; set; }
      public string Line { get; set; }
      public string Lot { get; set; }

      public override bool Equals(object obj)
      {
        if (obj == null || GetType() != obj.GetType())
        {
          return false;
        }

        var o = obj as ProductNumber;

        return this.Line.Equals(o.Line, StringComparison.InvariantCultureIgnoreCase)
          && this.Lot.Equals(o.Lot, StringComparison.InvariantCultureIgnoreCase)
          && this.Order.Equals(o.Order, StringComparison.InvariantCultureIgnoreCase)
          && this.Suborder.Equals(o.Suborder, StringComparison.InvariantCultureIgnoreCase);
      }

      // override object.GetHashCode
      public override int GetHashCode()
      {
        return base.GetHashCode();
      }

      internal ProductNumber()
      {
      }

      internal ProductNumber(string number)
      {
        if(string.IsNullOrEmpty(number))
        {
          var msg = Msgs.product_code_is_not_defined;
          throw new ExternalException(msg);
        }
        string regex = @"^(?<order>\d+)-(?<line>\d{2})(?<suborder>\d{1})(?<lot>\d{3})$";

        Regex re = new Regex(regex);
        var match = re.Match(number);
        if (match.Groups.Count != 5)
        {
          //Debug.WriteLine(string.Format("Cannot parse a code {0} using regex {1}", code, regex));
          var msg = string.Format(Msgs.product_code_0_is_invalid, number);
          throw new ExternalException(msg);
        }
        else
        {
          Order = match.Groups["order"].Value;
          Line = match.Groups["line"].Value;
          Suborder = match.Groups["suborder"].Value;
          Lot = match.Groups["lot"].Value;
        }
      }
    }
  }
}
