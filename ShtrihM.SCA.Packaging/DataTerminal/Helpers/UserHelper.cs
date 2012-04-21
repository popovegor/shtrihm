using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.DataTerminal.Entities;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using ShtrihM.SCA.Packaging.DataTerminal.Repositories;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public static class UserHelper
  {
    private static Dictionary<long, string> Users { get; set; }

    public static void InitUsers(bool reload)
    {
      var act = new Action(() =>
      {
        if (Users == null || reload == true)
        {
          Users = new Dictionary<long, string>();
          Users = Database.GetUsers();
        }
      });
      FormHelper.HandleAction(act);
    }

    public static string GetUserRoleName(UserRole role)
    {
      switch (role)
      {
        case UserRole.Admin:
          return "Администратор";

        case UserRole.ShiftBoss:
          return "Мастер смены";

        case UserRole.Storekeeper:
          return "Кладовщик";

        case UserRole.None:
          return string.Empty; //is not authenticated
      }
      throw new InternalException(new NotImplementedException());
    }

    internal static string GetUserName(long userid)
    {
      try
      {
        if (userid > 0)
        {
          InitUsers(false);
          return Users[userid];
        }
      }
      catch (Exception e)
      {
        LogHelper.Dump(e);
      }
      return userid.ToString();
    }
  }
}
