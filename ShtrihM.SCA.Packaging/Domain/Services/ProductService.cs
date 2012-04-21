using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SCA.Packaging.Domain.Repositories;
using SCA.Packaging.Domain.Entities;
using SCA.Packaging.Domain.Constants;
using Ninject;
using SCA.Packaging.Domain.Utils;
using SCA.Packaging.Domain.Exceptions;
using SCA.Packaging.Localization;
using SCA.Packaging.Domain.Helpers;

namespace SCA.Packaging.Domain.Services
{
  public class ProductService : IProductService
  {
    public ProductService(IProductRepository repository)
    {
      Repository = repository;
    }

    public IProductRepository Repository
    {
      get;
      private set;
    }

    #region IProductService Members

    public string GetBinByCode(string code)
    {
      var product = GetProduct(code);
      return product != null ? product.Bin : string.Empty;
    }

    public void PlaceProduct(ProductEntity product)
    {
      if (product == null)
      {
        var msg = Msgs.product_does_not_exist;
        throw new Exceptions.ExternalException(msg);
      }
      if (product.Validate())
      {
        Repository.Update(product);
      }
    }
    
    public ProductEntity GetProduct(string code)
    {
      if(string.IsNullOrEmpty(code) == true)
      {
        var msg = Msgs.product_code_is_not_defined;
        throw new ExternalException(msg);
      }
      var p = Repository.Get(code);
      if(p == null)
      {
        var msg = string.Format(Msgs.product_with_code_0_cannot_be_found, code);
        throw new ExternalException(msg);
      }
      return p;
    }

    public void ReplaceProduct(ProductEntity product, string newBin)
    {
      if(product == null)
      {
        var msg = Msgs.product_does_not_exist;
        throw new ExternalException(msg);
      }
      if(string.IsNullOrEmpty(newBin))
      {
        var msg = Msgs.new_product_bin_is_not_specified;
        throw new ExternalException(msg);
      }
      if(product.Validate())
      {
        product.Bin = newBin;
        product.Status = ProductStatus.Placed;
        Repository.Replace(product);
      }
    }

    #endregion
  }
}
