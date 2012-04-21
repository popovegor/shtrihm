using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Entities;

namespace ShtrihM.SCA.Packaging.Presentation.Loading
{
  public interface ILoadingView
  {
    Dictionary<string, ProductEntity> Products { get; set; }
    int OrderNumber { get; set; }
    int TotalCount { get; set;}
    int LoadedCount { get; set;}
  }
}
