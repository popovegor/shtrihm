using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Constants;
using ShtrihM.SCA.Packaging.Localization;

namespace ShtrihM.SCA.Packaging.Domain.Entities
{
  public class ProductEntity
  {
    public string Number { get; set; }
    public string Bin { get; set; }
    public string Status { get; set; }
    public int UserId { get; set;}
    public int OrderNumber { get; set;}

    public ProductEntity()
    {
      Status = ProductStatus.None;
    }
  }
}
