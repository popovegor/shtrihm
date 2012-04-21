using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public static class ConversionHelper
  {
    public static string ToString(object val)
    {
      try
      {
        return val == null || val == DBNull.Value ? string.Empty : val.ToString();
      }
      catch (Exception)
      {
        return string.Empty;
      }
    }
  }
}
