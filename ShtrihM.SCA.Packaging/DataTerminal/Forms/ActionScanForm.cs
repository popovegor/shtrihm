using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.DataTerminal.Repositories;
using ShtrihM.SCA.Packaging.DataTerminal.Models;

namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  public class ActionScanForm : BaseScanForm
  {
    public virtual long ActionStartId { get { throw new NotSupportedException(); } }
    public virtual long ActionFinishId { get { throw new NotSupportedException(); } }

    public ActionScanForm() : base()
    {
      
    }

    protected override void OnClose()
    {
      Database.SetAction(ActionStartId, LoginModel.User.Id);
    }

    protected override void OnOpen()
    {
      Database.SetAction(ActionFinishId, LoginModel.User.Id);
    }
  }
}
