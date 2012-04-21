using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Entities;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Localization;

namespace ShtrihM.SCA.Packaging.Presentation.Placement
{
  public sealed class PlacementModel : BaseModel
  {
    public PlacementModel(UserEntity user)
      : base(user)
    {
    }

    public string ProdNumber { get; set; }
    public string Bin { get; set; }

    //public ProductEntity Product { get; set; }

    public override bool IsValid()
    {
      bool valid = base.IsValid();

      if (string.IsNullOrEmpty(Number.Trim()))
      {
        throw new ExternalException(Msgs.product_code_is_not_defined);
      }
      if (string.IsNullOrEmpty(Bin.Trim()))
      {
        throw new ExternalException(Msgs.product_bin_is_not_defined);
      }
      return valid;
    }

  }
}
