using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShtrihM.SCA.Packaging.DataTerminal.Controls
{
  public interface IScanControl
  {
    void OnScan(int type, string data);
  }
}
