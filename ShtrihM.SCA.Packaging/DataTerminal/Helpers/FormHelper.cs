using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using System.Windows.Forms;
using System.Drawing;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public static class FormHelper
  {
  
    public static void Invoke(this Control Control, Action Action)
    {
      Control.Invoke(Action);
    }

    public static void HandleAction(Action act)
    {
      try
      {
        if (act != null)
        {
          Cursor.Current =  Cursors.WaitCursor;
          act();
          Cursor.Current = Cursors.Default;
        }
      }
      catch (ExternalException extEx)
      {
        Cursor.Current = Cursors.Default;
        LogHelper.Dump(extEx.InnerException ?? extEx, extEx.Message);
        MessageBox.Show(extEx.Message, "Сообщение об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      catch (InternalException intEx)
      {
        Cursor.Current = Cursors.Default;
        LogHelper.Dump(intEx.InnerException ?? intEx, intEx.Message);
      }
      catch (Exception e)
      {
        Cursor.Current = Cursors.Default;
        LogHelper.Dump(e.InnerException ?? e, e.Message);
      }
    }


    public static void ValidateBin(string bin)
    {
      if (string.IsNullOrEmpty(bin) == true)
      {
        throw new ExternalException("Не указано место хранения.");
      }
    }

    public static void ValidateProductCode(string code)
    {
      if (string.IsNullOrEmpty(code) == true)
      {
        throw new ExternalException("Не указан номер продукции.");
      }
    }

    internal static void ClearTreeview(TreeView tv)
    {
      try
      {
        tv.SuspendLayout();
        for (var i = 0; i < tv.Nodes.Count; i++)
        {
          var subs = tv.Nodes[i].Nodes;
          for (var j = 0; j < subs.Count; j++)
          {
            subs[j].Text = string.Empty;
          }
        }
        tv.CollapseAll();
      }
      catch (Exception e)
      {
        LogHelper.Dump(e);
      }
      finally
      {
        tv.ResumeLayout();
      }
    }

    internal static void ShowInfo(string msg)
    {
      MessageBox.Show(msg, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
    }

    internal static DialogResult ShowPrompt(string msg)
    {
      return MessageBox.Show(msg, "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }

    internal static void ClearListView(ListView lst, bool removeRows)
    {
      try
      {
        lst.SuspendLayout();
        if (removeRows)
        {
          lst.Items.Clear();
        }
        else
        {
          for (var i = 0; i < lst.Items.Count; i++)
          {
            var subs = lst.Items[i].SubItems;
            for (var j = 0; j < subs.Count; j++)
            {
              subs[j].Text = string.Empty;
            }
          }
        }
      }
      catch (Exception e)
      {
        LogHelper.Dump(e);
      }
      finally
      {
        lst.ResumeLayout();
      }
    }

    public static void SelectListItem(ListView lst, int index)
    {
      if (lst.Items.Count > 0)
      {
        foreach (ListViewItem v in lst.Items)
        {
          if (v.Index == index)
          {
            v.Focused = true;
            v.Selected = true;
            lst.EnsureVisible(index);
            break;
          }
        }
      }
    }
    
    public static void GotFocus(Control ctl)
    {
      ctl.BackColor = Color.Yellow;
    }

    public static void LostFocus(Control ctl)
    {
      ctl.BackColor = Color.White;
    }
  }
}
