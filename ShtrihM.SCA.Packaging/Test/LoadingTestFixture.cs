using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Ninject;
using ShtrihM.SCA.Packaging.Test.Factories;
using ShtrihM.SCA.Packaging.Domain.Constants;
using ShtrihM.SCA.Packaging.Presentation.Loading;
using System.Diagnostics;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Domain.Entities;

namespace ShtrihM.SCA.Packaging.Test
{
  [TestFixture]
  public class LoadingTestFixture
  {

    StandardKernel kernel;

    [SetUp]
    public void SetUp()
    {
      kernel = new StandardKernel(new PresentersFactory.LoadingNinjectModule());
    }

    [TearDown]
    public void TearDown()
    {
      if (kernel != null)
      {
        kernel.Dispose();
        kernel = null;
      }
    }

    [TestCase(1, 3, 0, ExpectedException= typeof(ExternalException), ExpectedMessage = "Задание на отгрузку № 1 выполнено или не готово к отгрузке.")]
    [TestCase(2, 4, 2)]
    [TestCase(3, 3, 0, ExpectedException= typeof(ExternalException), ExpectedMessage = "Задание на отгрузку № 3 выполнено или не готово к отгрузке.")]
    [TestCase(5, 0, 0, ExpectedException=typeof(ExternalException), ExpectedMessage = "Не найдено задание на отгрузку с № 5.")]
    public void can_scan_shipment_number_and_then_fill_product_list(int orderNumber, int prouctCount, int loadedCount)
    {
    
      Debug.WriteLine(orderNumber);
      
      //arrange
      var p = kernel.Get<LoadingPresenter>();

      //act
      p.SetOrderNumber(orderNumber);                                            

      //assert
      Assert.AreEqual(orderNumber, p.Model.OrderNumber);
      Assert.AreEqual(orderNumber, p.View.OrderNumber);
      Assert.AreEqual(prouctCount, p.View.TotalCount);
      Assert.AreEqual(loadedCount, p.View.LoadedCount);
      Assert.AreEqual(prouctCount, p.Model.Products.Count());
      foreach (var product in p.Model.Products.Values)
      {
        Assert.Contains(product.Status, new[] { ProductStatus.ForLoading, ProductStatus.Loaded });
      }
      foreach (var product in p.View.Products.Values)
      {
        Assert.Contains(product.Status, new[] { ProductStatus.ForLoading, ProductStatus.Loaded });
      }
    }

    [TestCase(2, "220189-010002", 2
      , ExpectedException = typeof(ExternalException), ExpectedMessage = "Продукция с кодом 220189-010002 уже отгружена.")]
    [TestCase(2, "220189-010001", 3)]
    [TestCase(2, "", 3
      , ExpectedException=typeof(ExternalException), ExpectedMessage="Не удалось определить код продукции.")]
    [TestCase(2, "220189-010010", 3
      , ExpectedException = typeof(ExternalException), ExpectedMessage = "Продукция c кодом 220189-010010 не предназначена для отгрузки.")]
    public void can_scan_product_number_then_load_product(int orderNumber, string number, int loadedCount)
    {
      Debug.WriteLine(string.Format("order: {0}, code : {1}", orderNumber, number));
      //arrange
      var p = kernel.Get<LoadingPresenter>();
      
      //act
      p.SetOrderNumber(orderNumber);
      p.LoadProduct(number);
      
      //assert
      Assert.AreEqual(kernel.Get<UserEntity>().Id, p.Model.User.Id);
      
      //an assert function to check a product
      var checkProduct = new Action<ProductEntity>(prod => {
        Assert.IsNotNull(prod);
        Assert.AreEqual(ProductStatus.Loaded, prod.Status);
        Assert.AreEqual(orderNumber, prod.OrderNumber);
        Assert.AreEqual(kernel.Get<UserEntity>().Id, prod.UserId);
      });
      //check this product in the model
      checkProduct(p.Model.Products[number]);
      //check this product in the view
      checkProduct(p.View.Products[number]);
      //check this product in the repository
      checkProduct(p.Repository.GetProduct(kernel.Get<UserEntity>().Id, number));
      //check the counters
      Assert.AreEqual(loadedCount, p.View.LoadedCount);
    }


    [TestCase(2, new[] {"220189-010004", "220189-010001"}, 4)]
    [TestCase(2, new[] { "220189-010004" }, 3
      , ExpectedException = typeof(ExternalException), ExpectedMessage = "Задание на отгрузку не может быть выполнено, так как продукция с кодом 220189-010001 все еще не отгружена.")]
    public void can_complete_loading(int orderNumber, string[] numbers, int loadedCount)
    {
      Debug.WriteLine(string.Format("order number: {0}", orderNumber));
      //arrange
      var p = kernel.Get<LoadingPresenter>();

      //act
      foreach(var n in numbers)
      {
        p.SetOrderNumber(orderNumber);
        p.LoadProduct(n);
      }
      
      p.Complete();
      
      //assert
      Assert.AreEqual(loadedCount, p.View.LoadedCount);
      Assert.AreEqual(loadedCount, p.Model.Products.Count);
      Assert.AreEqual(loadedCount, p.View.Products.Count);
      
      Assert.IsTrue(p.Repository.GetProducts(kernel.Get<UserEntity>().Id, orderNumber)
        .All(prod => prod.Status == ProductStatus.Loaded));
    }

    [TestCase(2, new[] { "220189-010004", "220189-010001" }, 4)]
    [TestCase(2, new[] { "220189-010004" }, 3)]
    public void can_cancel_loading(int orderNumber, string[] numbers, int loadedCount)
    {
      Debug.WriteLine(string.Format("order number: {0}", orderNumber));
      //arrange
      var p = kernel.Get<LoadingPresenter>();

      //act
      foreach (var n in numbers)
      {
        p.SetOrderNumber(orderNumber);
        p.LoadProduct(n);
      }

      p.Cancel();
      
      //assert
      var prods = p.Repository.GetProducts(kernel.Get<UserEntity>().Id, orderNumber);
      foreach(var n in numbers)
      {
        Assert.AreEqual(ProductStatus.Loaded, prods.First(prod => prod.Number == n).Status);
      }
    }
  }
}
