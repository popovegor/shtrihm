using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;

namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  public partial class Message : Form
  {
    public Message(string text, string caption)
    {
      InitializeComponent();
      lblText.Text = text;
      Text = caption;
      SoundHelper.Error();
      SoundHelper.Beep();
    }
  }
}