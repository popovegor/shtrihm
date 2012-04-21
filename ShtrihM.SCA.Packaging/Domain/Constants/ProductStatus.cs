using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShtrihM.SCA.Packaging.Domain.Constants
{
  public struct ProductStatus
  {
    public const string None = "";
    public const string InProgress = "0";
    public const string NotPlaced = "1";
    public const string Placed = "2";
    public const string ForLoading = "3";
    public const string Loaded = "4";
    public const string Unloaded = "5";
    public const string InventoryOK = "88";
    public const string NotFound = "99";

  }
}
