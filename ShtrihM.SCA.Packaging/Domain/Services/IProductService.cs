using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCA.Packaging.Domain.Entities;
using SCA.Packaging.Domain.Repositories;

namespace SCA.Packaging.Domain.Services
{
  public interface IProductService
  {
    IProductRepository Repository {get;}
  
    /// <summary>
    /// returns a bin for the product code
    /// </summary>
    string GetBinByCode(string code);
    
    /// <summary>
    /// Places the product
    /// </summary>
    /// <param name="product">The product.</param>
    void PlaceProduct(ProductEntity product);
    
    /// <summary>
    /// returns a product by code
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    /// <exception cref="ExternalException" />
    ProductEntity GetProduct(string code);

    void ReplaceProduct(ProductEntity productEntity, string p);
  }
}
