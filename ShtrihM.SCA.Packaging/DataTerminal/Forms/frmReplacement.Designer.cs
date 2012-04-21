using ShtrihM.SCA.Packaging.DataTerminal.Controls;
using System.Windows.Forms;
namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  partial class frmReplacement
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
      System.Windows.Forms.Button btnSearch;
      System.Windows.Forms.Label lbl1;
      System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem();
      this.txtNewBin = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanText();
      this.txtProdCode = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanSSCC();
      this.lbl2 = new System.Windows.Forms.Label();
      this.btnAccept = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lstData = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      btnSearch = new System.Windows.Forms.Button();
      lbl1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnSearch
      // 
      btnSearch.Location = new System.Drawing.Point(124, 4);
      btnSearch.Name = "btnSearch";
      btnSearch.Size = new System.Drawing.Size(112, 39);
      btnSearch.TabIndex = 1;
      btnSearch.Text = "Загрузить";
      btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
      // 
      // lbl1
      // 
      lbl1.Location = new System.Drawing.Point(4, 212);
      lbl1.Name = "lbl1";
      lbl1.Size = new System.Drawing.Size(113, 19);
      lbl1.Text = "Нов. место хран.";
      // 
      // txtNewBin
      // 
      this.txtNewBin.Location = new System.Drawing.Point(124, 210);
      this.txtNewBin.Name = "txtNewBin";
      this.txtNewBin.Size = new System.Drawing.Size(114, 25);
      this.txtNewBin.TabIndex = 3;
      // 
      // txtProdCode
      // 
      this.txtProdCode.Location = new System.Drawing.Point(4, 21);
      this.txtProdCode.Name = "txtProdCode";
      this.txtProdCode.Size = new System.Drawing.Size(112, 25);
      this.txtProdCode.TabIndex = 0;
      // 
      // lbl2
      // 
      this.lbl2.Location = new System.Drawing.Point(3, 3);
      this.lbl2.Name = "lbl2";
      this.lbl2.Size = new System.Drawing.Size(113, 18);
      this.lbl2.Text = "Код продукции";
      // 
      // btnAccept
      // 
      this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAccept.Location = new System.Drawing.Point(124, 253);
      this.btnAccept.Name = "btnAccept";
      this.btnAccept.Size = new System.Drawing.Size(113, 38);
      this.btnAccept.TabIndex = 5;
      this.btnAccept.Text = "Выполнить";
      this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click_1);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(3, 253);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(114, 38);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Закрыть";
      // 
      // lstData
      // 
      this.lstData.Columns.Add(this.columnHeader1);
      this.lstData.Columns.Add(this.columnHeader2);
      this.lstData.FullRowSelect = true;
      this.lstData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      listViewItem8.Text = "№ продукции";
      listViewItem8.SubItems.Add("");
      listViewItem9.Text = "№ склада";
      listViewItem9.SubItems.Add("");
      listViewItem10.Text = "Код изделия";
      listViewItem10.SubItems.Add("");
      listViewItem11.Text = "№ паллеты";
      listViewItem11.SubItems.Add("");
      listViewItem12.Text = "Всего паллет";
      listViewItem12.SubItems.Add("");
      listViewItem13.Text = "Описание изд.";
      listViewItem13.SubItems.Add("");
      listViewItem14.Text = "Покупатель";
      listViewItem14.SubItems.Add("");
      this.lstData.Items.Add(listViewItem8);
      this.lstData.Items.Add(listViewItem9);
      this.lstData.Items.Add(listViewItem10);
      this.lstData.Items.Add(listViewItem11);
      this.lstData.Items.Add(listViewItem12);
      this.lstData.Items.Add(listViewItem13);
      this.lstData.Items.Add(listViewItem14);
      this.lstData.Location = new System.Drawing.Point(2, 48);
      this.lstData.Name = "lstData";
      this.lstData.Size = new System.Drawing.Size(235, 158);
      this.lstData.TabIndex = 2;
      this.lstData.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Наименование";
      this.columnHeader1.Width = 104;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Значение";
      this.columnHeader2.Width = 123;
      // 
      // frmReplacement
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(240, 294);
      this.Controls.Add(this.lstData);
      this.Controls.Add(this.btnAccept);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(btnSearch);
      this.Controls.Add(this.txtNewBin);
      this.Controls.Add(lbl1);
      this.Controls.Add(this.txtProdCode);
      this.Controls.Add(this.lbl2);
      this.Name = "frmReplacement";
      this.Text = "SCA: Перемещение";
      this.ResumeLayout(false);

    }

    #endregion

    private ScanText txtNewBin;
    private ScanSSCC txtProdCode;
    private System.Windows.Forms.Label lbl2;
    private System.Windows.Forms.Button btnAccept;
    private System.Windows.Forms.Button btnCancel;
    private ListView lstData;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;



  }
}