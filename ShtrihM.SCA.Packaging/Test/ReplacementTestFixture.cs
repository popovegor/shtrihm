using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Ninject;
using ShtrihM.SCA.Packaging.Test.Factories;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Presentation.Replacement;
using System.Diagnostics;
using ShtrihM.SCA.Packaging.Domain.Constants;
using ShtrihM.SCA.Packaging.Domain.Entities;

namespace ShtrihM.SCA.Packaging.Test
{
  [TestFixture]
  public class ReplacementTestFixture
  {

    StandardKernel kernel;

    [SetUp]
    public void SetUp()
    {
      kernel = new StandardKernel(new PresentersFactory.ReplacementNinjectModule());
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

    [TestCase("220189-010002", "ab34")]
    [TestCase("220189-010008", "", ExpectedException = typeof(ExternalException), ExpectedMessage="Не удалось найти продукцию с кодом 220189-010008.")]
    [TestCase("", "", ExpectedException = typeof(ExternalException),ExpectedMessage="Не удалось определить код продукции.") ]
    [TestCase("fake product code", "", ExpectedException = typeof(ExternalException), ExpectedMessage="Не удалось найти продукцию с кодом fake product code.")]
    public void can_scan_product_number_with_existing_product_bin(string number, string bin)
    {
      Debug.WriteLine(number == "" ? "Empty" : number ?? "Empty");
      //arrange
      var p = kernel.Get<ReplacementPresenter>();
      
      //act
      p.SetProductCode(number);
      
      //assert
      Assert.AreEqual(number, p.Model.Product.Number);
      Assert.AreEqual(number, p.View.ProductNumber);
      Assert.AreEqual(bin, p.Model.Product.Bin);
      Assert.AreEqual(bin, p.View.ProductBin);
    }

    [TestCase("220189-010002", "ab37")]
    [TestCase("220189-010002", "", ExpectedException = typeof(ExternalException), ExpectedMessage = "Не указано новое место хранения продукции.")]
    public void can_replace_product(string number, string newBin)
    {
      Debug.WriteLine(number == "" ? "Empty" : number ?? "Empty");
      //arrange
      var p = kernel.Get<ReplacementPresenter>();

      //act
      p.SetProductCode(number);
      p.View.NewProductBin = newBin;
      p.ReplaceProduct();
      
      //assert
      var product = p.Repository.GetProduct(kernel.Get<UserEntity>().Id, number);
      Assert.AreEqual(number, product.Number);
      Assert.AreEqual(newBin, product.Bin);
      Assert.AreEqual(newBin, p.Model.NewBin);
      Assert.AreEqual(newBin, p.View.NewProductBin);
      Assert.AreEqual(ProductStatus.Placed, product.Status);
      Assert.AreEqual(kernel.Get<UserEntity>().Id, product.UserId);
    }
    
  }
}
