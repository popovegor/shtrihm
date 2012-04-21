using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public static class KioskHelper
  {

    [DllImport("startlock.dll", CharSet = CharSet.Unicode)]
    private static extern void LockStartMenu();

    [DllImport("startlock.dll", CharSet = CharSet.Unicode)]
    private static extern void UnlockStartMenu();

    [DllImport("startlock.dll", CharSet = CharSet.Unicode)]
    private static extern void LockStartBar();

    [DllImport("startlock.dll", CharSet = CharSet.Unicode)]
    private static extern void UnlockStartBar();

    [DllImport("startlock.dll", CharSet = CharSet.Unicode)]
    private static extern bool Lockdown(string windowText);

    [DllImport("startlock.dll", CharSet = CharSet.Unicode)]
    private static extern bool Unlockdown();

    public static void Lock()
    {
      LockStartMenu();
      LockStartBar();
      //Lockdown(string.Empty);
    }

    public static void Unlock()
    {
      UnlockStartMenu();
      UnlockStartBar();
      //Unlockdown();
    }
    
    public static void SetFullScreen(string windowName)
    {
      Lockdown(windowName);
    }
    
    
    public static void BackNormalScreen()
    {
      Unlockdown();
    }
  }
}
