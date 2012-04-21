using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Entities;
using ShtrihM.SCA.Packaging.Domain.Repositories;
using ShtrihM.SCA.Packaging.Domain.Constants;

namespace ShtrihM.SCA.Packaging.Test.Factories
{
  public static class RepositoriesFactory
  {
    internal class FakeProductRepository : IProductRepository
    {
      private Dictionary<string, ProductEntity> Products { get; set; }

      public FakeProductRepository(params ProductEntity[] products)
      {
        Products = new Dictionary<string, ProductEntity>();
        foreach (var p in products)
        {
          Products.Add(p.Number, p);
        }
      }

      #region IProductRepository Members

      public ProductEntity GetProduct(int userId, string code)
      {
        return Products.FirstOrDefault(p => p.Key == code).Value;
      }

      public void PlaceProduct(int userId, string number, string bin)
      {
        Products[number].Bin = bin;
        Products[number].UserId = userId;
        Products[number].Status = ProductStatus.Placed;
      }

      public void ReplaceProduct(int userId, string number, string newBin)
      {
        Products[number].UserId = userId;
        Products[number].Bin = newBin;
        Products[number].Status = ProductStatus.Placed;
      }

      public IEnumerable<ProductEntity> GetProducts(int userId, int orderNumber)
      {
        return Products.Values.Where(p => p.OrderNumber == orderNumber);
      }

      public void LoadProduct(int userId, string number)
      {
        Products[number].UserId = userId;
        Products[number].Status = ProductStatus.Loaded;
      }

      public void CompleteLoading(int userId, int orderNumber)
      {
        
      }

      public void CancelLoading(int userId, int orderNumber)
      {
        
      }

      #endregion
    }
  }
}
