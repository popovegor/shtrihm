using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Entities;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Localization;

namespace ShtrihM.SCA.Packaging.Presentation.Replacement
{
  public class ReplacementModel : BaseModel
  {
    public ReplacementModel(UserEntity user)
      : base(user)
    {
      Product = new ProductEntity();
    }

    public string NewBin { get; set; }
    public ProductEntity Product { get; set; }

    public override bool IsValid()
    {
      var valid = base.IsValid();
      if (string.IsNullOrEmpty(Product.Number.Trim()))
      {
        throw new ExternalException(Msgs.product_code_is_not_defined);
      }
      if (string.IsNullOrEmpty(Product.Bin.Trim()))
      {
        throw new ExternalException(Msgs.product_bin_is_not_defined);
      }
      if (string.IsNullOrEmpty(NewBin.Trim()))
      {
        throw new ExternalException(Msgs.new_product_bin_is_not_specified);
      }
      return valid;
    }

  }
}
