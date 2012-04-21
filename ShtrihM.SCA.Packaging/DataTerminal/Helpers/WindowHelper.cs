using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public static class WindowHelper
  {
    public static void HideTaskbar()
    {
      int h = FindWindow("HHTaskBar", "");
      ShowWindow(h, SW_HIDE);
    }

    public static void ShowTaskbar()
    {
      int h = FindWindow("HHTaskBar", "");
      ShowWindow(h, SW_SHOW);
    }

    private const int SW_HIDE = 0x0000;
    private const int SW_SHOW = 0x0001;

    [DllImport("coredll.dll", CharSet = CharSet.Auto)]
    private static extern int FindWindow(string lpClassName, string lpWindowName);

    [DllImport("coredll.dll", CharSet = CharSet.Auto)]
    private static extern bool ShowWindow(int hwnd, int nCmdShow);
  }
}
