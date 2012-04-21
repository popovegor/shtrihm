using System;

using System.Collections.Generic;
using System.Text;

namespace BarCodeScanner.Common
{
  public class BarCode
  {
    public string BarCodeType { get; set; }

    public string BarCodeData { get; set; }

    public bool IsEmpty
    {
      get
      {
        return string.IsNullOrEmpty(BarCodeData) == true;
      }
    }
  }
}
