using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ShtrihM.SCA.Packaging.Domain.Repositories;
using ShtrihM.SCA.Packaging.Presentation.Placement;
using ShtrihM.SCA.Packaging.Domain.Entities;
using ShtrihM.SCA.Packaging.Test.Factories;
using Ninject;
using System.Diagnostics;
using ShtrihM.SCA.Packaging.Domain.Constants;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Localization;

namespace ShtrihM.SCA.Packaging.Test
{
  [TestFixture]
  public class PlacementTestFixture
  {

    StandardKernel kernel;

    [SetUp]
    public void SetUp()
    {
      kernel = new StandardKernel(new PresentersFactory.PlacementNijectModule());
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

    [TestCase("220189-010002", , )]
    [TestCase(""
      , ExpectedException = typeof(ExternalException)
      , ExpectedMessage = "Не удалось определить код продукции.")]
    [TestCase("220189-010007"
      , ExpectedException = typeof(ExternalException)
      , ExpectedMessage = "Не удалось найти продукцию с кодом 220189-010007.")]
    public void can_scan_product_number(string prodNumber, string orderNumber, string specNumber, string customerName, string productName, int palletNumber, int palletQuantity, long palletId)
    {
      Debug.WriteLine(prodNumber);
      //arrange: SetUp()
      var p = kernel.Get<PlacementPresenter>();

      //act
      p.SetProductCode(prodNumber);

      //assert
      Assert.AreEqual(prodNumber, p.Model.ProdNumber);
      Assert.AreEqual(orderNumber, p.Model.OrderNumber);
      Assert.AreEqual(specNumber, p.Model.SpecNumber);
      Assert.AreEqual(customerName, p.Model.CustomerName); 
      Assert.AreEqual(productName, p.Model.ProductName); 
      Assert.AreEqual(palletQuantity, p.Model.PalletQuantity); 
      Assert.AreEqual(palletNumber, p.Model.PalletNumber);
    }

    //[TestCase("220189-010002", "ab34", false)]
    //[TestCase("220189-010001", "ab35", false)]
    //[TestCase("220189-010008", "", true)]
    //[TestCase("220189-010007", "", true, ExpectedException = typeof(EntityNotFoundException))]
    //[TestCase("", "", true, ExpectedException = typeof(ArgumentNullException))]
    //[TestCase(null, "", true, ExpectedException = typeof(ArgumentNullException))]
    //public void notify_when_bin_not_found(string code, string bin, bool notify)
    //{
    //  Debug.WriteLine(code);
    //  //arrange:
    //  var p = kernel.Get<IPlacementPresenter>();

    //  //act
    //  var onBinNotFound = false;
    //  p.View.NotFoundProductBin += () => onBinNotFound = notify;
    //  p.SetProductCode(code);

    //  //assert
    //  Assert.AreEqual(notify, onBinNotFound);
    //}

    [TestCase("220189-010001", "ab35")]
    [TestCase("", "", ExpectedException = typeof(ExternalException), ExpectedMessage = "Не удалось определить код продукции.")]
    public void auto_set_bin_after_scan_number_when_bin_exists(string number, string bin)
    {
      Debug.WriteLine(number);

      //arrange
      var p = kernel.Get<PlacementPresenter>();

      //act
      p.SetProductCode(number);

      //assert
      Assert.AreEqual(bin, p.Model.Product.Bin);
    }

    [TestCase("220189-010001", "ab35", ProductStatus.Placed)]
    [TestCase("fake code", "12", ProductStatus.None, ExpectedException = typeof(ExternalException), ExpectedMessage = "Не удалось найти продукцию с кодом fake code.")]
    [TestCase("220189-010001", "", ProductStatus.None, ExpectedException = typeof(ExternalException), ExpectedMessage = "Не указано место хранения продукции.")]
    public void can_place_product(string number, string bin, string status)
    {
      Debug.WriteLine(number);

      //arrange
      var p = kernel.Get<PlacementPresenter>();

      //act
      p.SetProductCode(number);
      p.View.ProductBin = bin;
      p.PlaceProduct();

      //assert
      var product = p.Repository.GetProduct(kernel.Get<UserEntity>().Id, number);
      Assert.IsNotNull(product);
      Assert.AreEqual(number, product.Number);
      Assert.AreEqual(bin, product.Bin);
      Assert.AreEqual(status, product.Status);
      Assert.AreEqual(kernel.Get<UserEntity>().Id, product.UserId);
    }
  }
}
