using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Localization;
//using ShtrihM.SCA.Packaging.Domain.Services;
using ShtrihM.SCA.Packaging.Domain.Helpers;
using ShtrihM.SCA.Packaging.Domain.Repositories;
using ShtrihM.SCA.Packaging.Domain.Constants;
using ShtrihM.SCA.Packaging.Domain.Entities;

namespace ShtrihM.SCA.Packaging.Presentation.Replacement
{
  public class ReplacementPresenter
  {

    public ReplacementModel Model
    {
      get;
      private set;
    }

    /*public ShtrihM.SCA.Packaging.Domain.Services.IProductService Service
    {
      get; private set;
    }*/

    public IProductRepository Repository
    {
      get;
      private set;
    }

    public IReplacementView View
    {
      get;
      private set;
    }

    public ReplacementPresenter(/*IProductService s*/IProductRepository r, IReplacementView v, ReplacementModel m)
    {
      //Service = s;
      Repository = r;
      Model = m;
      View = v;
    }

    public void SetProductCode(string code)
    {
      if (string.IsNullOrEmpty(code))
      {
        throw new ExternalException(Msgs.product_code_is_not_defined);
      }
      //var p = Service.GetProduct(code);
      var p = Repository.GetProduct(Model.User.Id, code);
      if (p == null)
      {
        var msg = string.Format(Msgs.product_with_code_0_cannot_be_found, code);
        throw new ExternalException(msg);
      }
      if (string.IsNullOrEmpty(p.Bin))
      {
        var msg = string.Format(Msgs.product_with_code_0_cannot_be_found, code);
        throw new ExternalException(msg);
      }
      Model.Product.Number = View.ProductNumber = p.Number;
      Model.Product.Bin = View.ProductBin = p.Bin;
    }

    public void ReplaceProduct()
    {
      Model.NewBin = View.NewProductBin;
      if (Model.IsValid())
      {
        Repository.ReplaceProduct(Model.User.Id, Model.Product.Number, Model.NewBin);
        Model.Product = Repository.GetProduct(Model.User.Id, Model.Product.Number);
      }
    }
  }
}
