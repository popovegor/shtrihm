using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShtrihM.SCA.Packaging.Presentation.Placement
{
  public interface IPlacementView
  {
    //event Action NotFoundProductBin;
    //void RaiseNotFoundProductBin();
    string ProductCode { get; set; }
    string ProductBin { get; set; }
  }
}
