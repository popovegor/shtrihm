using ShtrihM.SCA.Packaging.DataTerminal.Controls;
namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  partial class frmInventory
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
      System.Windows.Forms.Button btnLoad;
      this.btnAccept = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtOrder = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanOrder();
      this.lbl2 = new System.Windows.Forms.Label();
      this.lstData = new ShtrihM.SCA.Packaging.DataTerminal.Controls.PalletList();
      this.id = new System.Windows.Forms.ColumnHeader();
      this.clmNumber = new System.Windows.Forms.ColumnHeader();
      this.clmBin = new System.Windows.Forms.ColumnHeader();
      this.clmStatus = new System.Windows.Forms.ColumnHeader();
      this.lblCounter = new System.Windows.Forms.Label();
      btnLoad = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnLoad
      // 
      btnLoad.Location = new System.Drawing.Point(124, 4);
      btnLoad.Name = "btnLoad";
      btnLoad.Size = new System.Drawing.Size(112, 39);
      btnLoad.TabIndex = 1;
      btnLoad.Text = "Загрузить";
      btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // btnAccept
      // 
      this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAccept.Location = new System.Drawing.Point(125, 253);
      this.btnAccept.Name = "btnAccept";
      this.btnAccept.Size = new System.Drawing.Size(113, 38);
      this.btnAccept.TabIndex = 4;
      this.btnAccept.Text = "Выполнить";
      this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(3, 253);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(116, 38);
      this.btnCancel.TabIndex = 3;
      this.btnCancel.Text = "Отмена";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 230);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(185, 20);
      this.label1.Text = "Готово/всего:";
      // 
      // txtOrder
      // 
      this.txtOrder.Location = new System.Drawing.Point(4, 21);
      this.txtOrder.Name = "txtOrder";
      this.txtOrder.Size = new System.Drawing.Size(112, 25);
      this.txtOrder.TabIndex = 0;
      // 
      // lbl2
      // 
      this.lbl2.Location = new System.Drawing.Point(3, 3);
      this.lbl2.Name = "lbl2";
      this.lbl2.Size = new System.Drawing.Size(113, 18);
      this.lbl2.Text = "Номер задания";
      // 
      // lstData
      // 
      this.lstData.FullRowSelect = true;
      this.lstData.Location = new System.Drawing.Point(2, 48);
      this.lstData.Name = "lstData";
      this.lstData.Size = new System.Drawing.Size(234, 179);
      this.lstData.TabIndex = 2;
      this.lstData.View = System.Windows.Forms.View.Details;
      // 
      // id
      // 
      this.id.Text = "";
      this.id.Width = 0;
      // 
      // clmNumber
      // 
      this.clmNumber.Text = "№ заказа";
      this.clmNumber.Width = 79;
      // 
      // clmBin
      // 
      this.clmBin.Text = "BIN";
      this.clmBin.Width = 85;
      // 
      // clmStatus
      // 
      this.clmStatus.Text = "Статус";
      this.clmStatus.Width = 60;
      // 
      // lblCounter
      // 
      this.lblCounter.Location = new System.Drawing.Point(175, 230);
      this.lblCounter.Name = "lblCounter";
      this.lblCounter.Size = new System.Drawing.Size(62, 20);
      this.lblCounter.Text = "0/0";
      this.lblCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // frmInventory
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(240, 294);
      this.Controls.Add(this.lblCounter);
      this.Controls.Add(this.lstData);
      this.Controls.Add(btnLoad);
      this.Controls.Add(this.txtOrder);
      this.Controls.Add(this.lbl2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnAccept);
      this.Controls.Add(this.btnCancel);
      this.Name = "frmInventory";
      this.Text = "SCA: Инвентаризация";
      this.Load += new System.EventHandler(this.frmInventory_Load);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmInventory_Closing);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnAccept;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label1;
    private ScanOrder txtOrder;
    private System.Windows.Forms.Label lbl2;
    private PalletList lstData;
    private System.Windows.Forms.Label lblCounter;
    private System.Windows.Forms.ColumnHeader clmNumber;
    private System.Windows.Forms.ColumnHeader clmBin;
    private System.Windows.Forms.ColumnHeader clmStatus;
    private System.Windows.Forms.ColumnHeader id;
  }
}