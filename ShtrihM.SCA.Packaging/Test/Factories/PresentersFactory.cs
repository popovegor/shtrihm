using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using ShtrihM.SCA.Packaging.Presentation.Placement;
using ShtrihM.SCA.Packaging.Domain.Entities;
using ShtrihM.SCA.Packaging.Domain.Repositories;
using Ninject;
using ShtrihM.SCA.Packaging.Domain.Utils;
//using ShtrihM.SCA.Packaging.Domain.Services;
using ShtrihM.SCA.Packaging.Presentation.Replacement;
using ShtrihM.SCA.Packaging.Domain.Constants;
using ShtrihM.SCA.Packaging.Presentation.Loading;

namespace ShtrihM.SCA.Packaging.Test.Factories
{
  internal static class PresentersFactory
  {
    internal class BaseNinjectModule : NinjectModule
    {
      public override void Load()
      {
        Bind<UserEntity>().ToConstant(new UserEntity() { Id = 1, Name = "name", Password = "pwd" }).InSingletonScope();
        Bind<ILogWriter>().To<UtilsFactory.FakeLogWriter>();
        Bind<IProductRepository>().To<RepositoriesFactory.FakeProductRepository>()
          .WithConstructorArgument("products", new[] { 
              new ProductEntity() {
                Number = "220189-010003", OrderNumber = 1, Status = ProductStatus.None, Bin = "ab36"}
            , new ProductEntity() { 
                Number = "220189-010008", OrderNumber = 1, Status = ProductStatus.None, Bin = ""}
            , new ProductEntity() { 
                Number = "220189-010009", OrderNumber = 1, Status = ProductStatus.None, Bin = ""}
            , new ProductEntity() { 
                Number = "220189-010002", OrderNumber = 2, Status = ProductStatus.Loaded, Bin = "ab34"}
            , new ProductEntity() { 
                Number = "220189-010001", OrderNumber = 2, Status = ProductStatus.ForLoading, Bin = "ab35"}
            , new ProductEntity() { 
                Number = "220189-010005", OrderNumber = 2, Status = ProductStatus.Loaded, Bin = "ab38"}
            , new ProductEntity() { 
                Number = "220189-010004", OrderNumber = 2, Status = ProductStatus.ForLoading, Bin = "ab39"}
            , new ProductEntity() { 
                Number = "220189-010010", OrderNumber = 3, Status = ProductStatus.Placed, Bin = "ab35" }
            , new ProductEntity() { 
                Number = "220189-010011", OrderNumber = 3, Status = ProductStatus.ForLoading, Bin = "ab36" }
            , new ProductEntity() { 
                Number = "220189-010012", OrderNumber = 3, Status = ProductStatus.NotPlaced, Bin = "" } });
      }
    }

    internal class ReplacementNinjectModule : BaseNinjectModule
    {
      public override void Load()
      {
        base.Load();
        Bind<IReplacementView>().To<ViewsFactory.StubReplacementView>();
        Bind<ReplacementModel>().ToSelf();
        Bind<ReplacementPresenter>().ToSelf();
      }
    }

    internal class PlacementNijectModule : BaseNinjectModule
    {
      public override void Load()
      {
        base.Load();
        Bind<IPlacementView>().To<ViewsFactory.StubPlacementView>();
        Bind<PlacementModel>().ToSelf();
        Bind<PlacementPresenter>().ToSelf();
      }
    }

    internal class LoadingNinjectModule : BaseNinjectModule
    {
      public override void Load()
      {
        base.Load();
        Bind<ILoadingView>().To<ViewsFactory.StubLoadingView>();
        Bind<LoadingModel>().ToSelf();
        Bind<LoadingPresenter>().ToSelf();
      }
    }
  }
}
