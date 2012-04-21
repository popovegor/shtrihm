using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ShtrihM.SCA.Packaging.Domain.Helpers;
using System.Diagnostics;
using ShtrihM.SCA.Packaging.Domain.Exceptions;

namespace ShtrihM.SCA.Packaging.Test.Domain
{
  [TestFixture]
  public class ProductHelperTestFixture
  {
    [Test]
    [TestCase("220189-010001", "220189", "01", "0", "001" )]
    [TestCase("220189-011002", "220189", "01", "1", "002")]
    [TestCase("220189-020005", "220189", "02", "0", "005")]
    [TestCase("220189-005", null, null, null, null, ExpectedException = typeof(ExternalException))]
    [TestCase("-010001", null, null, null, null, ExpectedException = typeof(ExternalException))]
    [TestCase("", null, null, null, null, ExpectedException = typeof(ExternalException))]
    [TestCase(null, null, null, null, null, ExpectedException = typeof(ExternalException))] 
    public void get_product_code_by_barcode(string code, string order, string line, string suborder, string lot) 
    {
      Debug.WriteLine(code);
      var pc = ProductHelper.ParseProductCode(code);
      Assert.AreEqual(order, pc.Order);
      Assert.AreEqual(line, pc.Line);
      Assert.AreEqual(suborder, pc.Suborder);
      Assert.AreEqual(lot, pc.Lot);
    }
  }
}
