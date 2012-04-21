using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;

namespace ShtrihM.SCA.Packaging.DataTerminal.Entities
{
  public class UserEntity
  {
    public UserEntity()
    {
      Role = UserRole.None;
      FullName = string.Empty;
      Id = 0;
    }

    public bool IsAuthenticated
    {
      get
      {
        return Role != UserRole.None;
      }
    }

    public long Id { get; set; }
    public string FullName { get; set; }
    public UserRole Role { get; set; }
    public string RoleName
    {
      get
      {
        return UserHelper.GetUserRoleName(Role);
      }
    }
  }
}
