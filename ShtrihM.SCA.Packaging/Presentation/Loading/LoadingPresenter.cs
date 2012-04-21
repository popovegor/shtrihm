using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.Domain.Repositories;
using ShtrihM.SCA.Packaging.Domain.Exceptions;
using ShtrihM.SCA.Packaging.Localization;
using ShtrihM.SCA.Packaging.Domain.Constants;
using ShtrihM.SCA.Packaging.Domain.Entities;

namespace ShtrihM.SCA.Packaging.Presentation.Loading
{
  public class LoadingPresenter
  {

    public LoadingModel Model
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

    public ILoadingView View
    {
      get;
      private set;
    }

    public LoadingPresenter(/*IProductService s*/IProductRepository r, ILoadingView v, LoadingModel m)
    {
      //Service = s;
      Repository = r;
      Model = m;
      View = v;
      View.Products = new Dictionary<string, ProductEntity>();
    }

    public void SetOrderNumber(int orderNumber)
    {
      if (orderNumber <= 0)
      {
        var msg = Msgs.order_number_is_not_defined;
        throw new ExternalException(msg);
      }
      var products = Repository.GetProducts(Model.User.Id, orderNumber);
      if (products == null || products.Count() == 0)
      {
        var msg = string.Format(Msgs.loading_with_number_0_cannot_be_found, orderNumber);
        throw new ExternalException(msg);
      }
      //TODO: only 
      if (false == products.All(p => p.Status == ProductStatus.Loaded
        || p.Status == ProductStatus.ForLoading))
      {
        var msg = string.Format(Msgs.loading_with_number_0_is_completed_or_not_prepared, orderNumber);
        throw new ExternalException(msg);
      }
      Model.OrderNumber = orderNumber;
      View.OrderNumber = orderNumber;
      View.Products = new Dictionary<string, ProductEntity>();
      Model.Products = new Dictionary<string, ProductEntity>();
      foreach (var prod in products)
      {
        View.Products.Add(prod.Number, prod);
        Model.Products.Add(prod.Number, prod);
      }
      View.TotalCount = products.Count();
      View.LoadedCount = products.Count(p => p.Status == ProductStatus.Loaded);
    }

    public void LoadProduct(string productNumber)
    {
      if (string.IsNullOrEmpty(productNumber))
      {
        var msg = Msgs.product_code_is_not_defined;
        throw new ExternalException(msg);
      }
      ProductEntity prod;
      Model.Products.TryGetValue(productNumber, out prod);
      if (prod == null)
      {
        var msg = string.Format(Msgs.product_with_code_0_is_not_prepared_for_loading, productNumber);
        throw new ExternalException(msg);
      }
      if (prod.Status == ProductStatus.Loaded)
      {
        var msg = string.Format(Msgs.product_with_code_0_is_already_loaded, productNumber);
        throw new ExternalException(msg);
      }
      Repository.LoadProduct(Model.User.Id, productNumber);
      var p = Repository.GetProduct(Model.User.Id, productNumber);
      View.LoadedCount += 1;
    }

    public void Complete()
    {
      if(Model.IsValid())
      {
        Repository.CompleteLoading(Model.User.Id, Model.OrderNumber);
      }
    }

    public void Cancel()
    {
      Repository.CancelLoading(Model.User.Id, Model.OrderNumber);
    }
  }
}
