using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShtrihM.SCA.Packaging.Presentation.Replacement
{
  public interface IReplacementView
  {
    string ProductNumber { get; set; }
    string ProductBin { get; set; }
    string NewProductBin { get; set; }
  }
}
