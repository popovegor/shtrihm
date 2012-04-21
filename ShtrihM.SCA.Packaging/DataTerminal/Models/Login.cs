using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.DataTerminal.Entities;

namespace ShtrihM.SCA.Packaging.DataTerminal.Models
{
  public static class LoginModel
  {
    public static UserEntity User { get; set; }
    
    public const int FakeId = 0;

    public static UserRole Role
    {
      get
      {
        return User != null ? User.Role : UserRole.None;
      }
    }

    public static bool IsAuthenticated
    {
      get
      {
        return User != null && User.IsAuthenticated && User.Id >= 0;
      }
    }
  }
}
