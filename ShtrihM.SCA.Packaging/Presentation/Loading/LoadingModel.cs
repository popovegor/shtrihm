using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Entities;
using ShtrihM.SCA.Packaging.Localization;
using ShtrihM.SCA.Packaging.Domain.Constants;
using ShtrihM.SCA.Packaging.Domain.Exceptions;

namespace ShtrihM.SCA.Packaging.Presentation.Loading
{
  public class LoadingModel : BaseModel
  {
    public LoadingModel(UserEntity user)
      : base(user)
    {
      Products = new Dictionary<string, ProductEntity>();
    }

    public int OrderNumber { get; set; }
    public Dictionary<string, ProductEntity> Products { get; set; }

    public override bool IsValid()
    {
      var valid = base.IsValid();
      var prod = Products.Values.FirstOrDefault(p => p.Status != ProductStatus.Loaded);
      if(prod != null)
      {
        var msg = string.Format(Msgs.loading_cannot_be_completed_because_product_with_code_0_is_not_loaded_yet
          , prod.Number);
        throw new ExternalException(msg);
      }
      return valid;
    }
  }
}
