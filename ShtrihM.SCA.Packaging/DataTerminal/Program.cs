using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Models;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;

namespace ShtrihM.SCA.Packaging.DataTerminal
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [MTAThread]
    static void Main()
    {
      //LoginModel.User = new ShtrihM.SCA.Packaging.DataTerminal.Entities.UserEntity() 
      //  {Id = 1
      //   , Role = ShtrihM.SCA.Packaging.DataTerminal.Entities.UserRole.Storekeeper};
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
      MessageBox.Show("start app!");
      KioskHelper.Lock();
      Application.Run(new frmMain());
      KioskHelper.Unlock();
      //Application.Run(new frmPlacement());
      //Application.Run(new frmReplacement());
      //frmInventory.Application.Run(new frmLoading());
      //Application.Run(new frmInventory());
      //Application.Run(new frmAdmin());
      //Application.Run(new Message("text", "caption"));
    }

    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
    }
  }
}