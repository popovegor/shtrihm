using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Repositories;
using ShtrihM.SCA.Packaging.Domain.Helpers;
//using ShtrihM.SCA.Packaging.Domain.Services;
using ShtrihM.SCA.Packaging.Domain.Entities;
using ShtrihM.SCA.Packaging.Localization;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Domain.Constants;

namespace ShtrihM.SCA.Packaging.Presentation.Placement
{
  public class PlacementPresenter
  {
    //public IProductService Service { get; private set; }
    public IProductRepository Repository {get; private set;}
    public IPlacementView View { get; private set; }
    public PlacementModel Model { get; private set; }

    public PlacementPresenter(/*IProductService s*/ IProductRepository r, IPlacementView v, PlacementModel m)
    {
      //Service = s;
      Repository = r;
      Model = m;
      View = v;
    }

    /// <summary>
    /// Sets the code.
    /// </summary>
    /// <param name="code">the code.</param>
    public void SetProductCode(string number)
    {
      //TODO: var pc = ProductHelper.ParseProductCode(productCode);
      if(string.IsNullOrEmpty(number))
      {
        throw new ExternalException(Msgs.product_code_is_not_defined);
      }
      //var bin = Service.GetBinByCode(Model.Product.Code);
      var product = Repository.GetProduct(Model.User.Id, number);
      if(product == null)
      {
        var msg = string.Format(Msgs.product_with_code_0_cannot_be_found, number);
        throw new ExternalException(msg);
      }
      View.ProductCode = Model.Product.Number = number;
      AutoSetProductBin(product.Bin);
    }
    
    private void AutoSetProductBin(string bin)
    {
      View.ProductBin = Model.Product.Bin = bin ?? string.Empty;
    }
    
    #region IPlacementPresenter Members

    public void PlaceProduct()
    {
      Model.Product.Bin = View.ProductBin;
      //Service.PlaceProduct(Model.Product);
      if (Model.IsValid())
      {
        Repository.PlaceProduct(Model.User.Id, Model.Product.Number, Model.Product.Bin);
        Model.Product = Repository.GetProduct(Model.User.Id, Model.Product.Number);
      }
    }

    #endregion
  }
}
