namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  partial class Message
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.lblText = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblText
      // 
      this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblText.Location = new System.Drawing.Point(0, 0);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(240, 119);
      this.lblText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // Message
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(240, 119);
      this.Controls.Add(this.lblText);
      this.MinimizeBox = false;
      this.Name = "Message";
      this.Text = "SCA: Сообщение";
      this.TopMost = true;
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblText;
  }
}