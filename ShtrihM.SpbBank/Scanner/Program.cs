using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace ShtrihM.SpbBank.Scanner
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [MTAThread]
    static void Main()
    {
      AppDomain.CurrentDomain.UnhandledException
        += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
      Application.Run(new frmMain());
    }

    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      MessageBox.Show("Произошла непредвиденная ошибка в программе, пожалуйста, обратитесь к разработчикам данной программы", "Ошибка в программе", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
    }
  }
}