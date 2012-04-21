using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Presentation.Placement;
using NUnit.Framework;
using ShtrihM.SCA.Packaging.Presentation.Replacement;
using ShtrihM.SCA.Packaging.Presentation.Loading;
using ShtrihM.SCA.Packaging.Domain.Entities;

namespace ShtrihM.SCA.Packaging.Test.Factories
{
  internal static class ViewsFactory
  {
  
    internal class StubLoadingView : ILoadingView
    {
      #region ILoadingView Members

      public Dictionary<string, ProductEntity> Products
      {
        get;set;
      }

      public int OrderNumber {get; set;}

      public int TotalCount {get; set;}

      public int LoadedCount { get; set; }

      #endregion
    }
  
    internal class StubPlacementView : IPlacementView
    {

      #region IPlacementView Members

      public string ProductBin { get; set; }

      public string ProductCode { get; set; }

      #endregion
    }

    internal class StubReplacementView : IReplacementView
    {
      #region IReplacementView Members

      public string ProductNumber
      {
        get;
        set;
      }

      public string ProductBin
      {
        get;
        set;
      }

      public string NewProductBin
      {
        get;
        set;
      }

      #endregion
    }
  }
}
