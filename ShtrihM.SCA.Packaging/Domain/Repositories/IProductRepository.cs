using ShtrihM.SCA.Packaging.Domain.Entities;
using System.Collections.Generic;

namespace ShtrihM.SCA.Packaging.Domain.Repositories
{
  /// <summary>
  /// Product repository for CRUD operations
  /// </summary>
  public interface IProductRepository
  {
    IEnumerable<ProductEntity> GetProducts(int userId, int orderNumber);
    ProductEntity GetProduct(int userId, string code);
    void PlaceProduct(int userId, string number, string bin);
    void ReplaceProduct(int userId, string number, string newBin);
    void LoadProduct(int userId, string number);
    void CompleteLoading(int userId, int orderNumber);
    void CancelLoading(int userId, int orderNumber);
  }
}
