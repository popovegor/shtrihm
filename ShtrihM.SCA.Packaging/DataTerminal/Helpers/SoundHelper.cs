using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public class SoundHelper
  {
    private enum PlaySoundFlags
    {
      SND_ALIAS = 0x10000,
      SND_FILENAME = 0x20000,
      SND_RESOURCE = 0x40004,
      SND_SYNC = 0x0,
      SND_ASYNC = 0x1,
      SND_NODEFAULT = 0x2,
      SND_MEMORY = 0x4,
      SND_LOOP = 0x8,
      SND_NOSTOP = 0x10,
      SND_NOWAIT = 0x2000,
      SND_VALIDFLAGS = 0x17201F,
      SND_TYPE_MASK = 0x170007
    }

    [DllImport("CoreDll.dll")]
    private static extern int PlaySound(string szSound, IntPtr hMod, PlaySoundFlags flags);

    public static void Beep()
    {
      PlaySound("SystemExclamatic", IntPtr.Zero, PlaySoundFlags.SND_ALIAS);
    }

    internal static void Error()
    {
      PlaySound("SystemAsterisk", IntPtr.Zero, PlaySoundFlags.SND_ALIAS);
    }
  }
}
