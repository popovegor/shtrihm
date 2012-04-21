using ShtrihM.SCA.Packaging.DataTerminal.Controls;
using System.Windows.Forms;
namespace ShtrihM.SCA.Packaging.DataTerminal.Forms
{
  partial class frmPlacement
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
      System.Windows.Forms.Label lbl1;
      System.Windows.Forms.Button btnSearch;
      System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnAccept = new System.Windows.Forms.Button();
      this.lbl2 = new System.Windows.Forms.Label();
      this.txtBin = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanText();
      this.txtProdCode = new ShtrihM.SCA.Packaging.DataTerminal.Controls.ScanSSCC();
      this.lstData = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      lbl1 = new System.Windows.Forms.Label();
      btnSearch = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lbl1
      // 
      lbl1.Location = new System.Drawing.Point(4, 210);
      lbl1.Name = "lbl1";
      lbl1.Size = new System.Drawing.Size(131, 20);
      lbl1.Text = "Место хранения";
      // 
      // btnSearch
      // 
      btnSearch.Location = new System.Drawing.Point(121, 5);
      btnSearch.Name = "btnSearch";
      btnSearch.Size = new System.Drawing.Size(116, 40);
      btnSearch.TabIndex = 1;
      btnSearch.Text = "Загрузить";
      btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(3, 255);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(112, 38);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Закрыть";
      // 
      // btnAccept
      // 
      this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAccept.Location = new System.Drawing.Point(120, 255);
      this.btnAccept.Name = "btnAccept";
      this.btnAccept.Size = new System.Drawing.Size(118, 38);
      this.btnAccept.TabIndex = 5;
      this.btnAccept.Text = "Выполнить";
      this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
      // 
      // lbl2
      // 
      this.lbl2.Location = new System.Drawing.Point(4, 5);
      this.lbl2.Name = "lbl2";
      this.lbl2.Size = new System.Drawing.Size(131, 20);
      this.lbl2.Text = "Код продукции";
      // 
      // txtBin
      // 
      this.txtBin.Location = new System.Drawing.Point(120, 207);
      this.txtBin.Name = "txtBin";
      this.txtBin.Size = new System.Drawing.Size(117, 25);
      this.txtBin.TabIndex = 3;
      // 
      // txtProdCode
      // 
      this.txtProdCode.Location = new System.Drawing.Point(5, 23);
      this.txtProdCode.Name = "txtProdCode";
      this.txtProdCode.Size = new System.Drawing.Size(110, 25);
      this.txtProdCode.TabIndex = 0;
      // 
      // lstData
      // 
      this.lstData.Columns.Add(this.columnHeader1);
      this.lstData.Columns.Add(this.columnHeader2);
      this.lstData.FullRowSelect = true;
      this.lstData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      listViewItem7.Text = "№ продукции";
      listViewItem7.SubItems.Add("");
      listViewItem8.Text = "Код изделия";
      listViewItem8.SubItems.Add("");
      listViewItem9.Text = "№ паллеты";
      listViewItem9.SubItems.Add("");
      listViewItem10.Text = "Всего паллет";
      listViewItem10.SubItems.Add("");
      listViewItem11.Text = "Описание изд.";
      listViewItem11.SubItems.Add("");
      listViewItem12.Text = "Покупатель";
      listViewItem12.SubItems.Add("");
      this.lstData.Items.Add(listViewItem7);
      this.lstData.Items.Add(listViewItem8);
      this.lstData.Items.Add(listViewItem9);
      this.lstData.Items.Add(listViewItem10);
      this.lstData.Items.Add(listViewItem11);
      this.lstData.Items.Add(listViewItem12);
      this.lstData.Location = new System.Drawing.Point(2, 50);
      this.lstData.Name = "lstData";
      this.lstData.Size = new System.Drawing.Size(235, 154);
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
      // frmPlacement
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(240, 294);
      this.Controls.Add(this.lstData);
      this.Controls.Add(btnSearch);
      this.Controls.Add(this.txtBin);
      this.Controls.Add(lbl1);
      this.Controls.Add(this.txtProdCode);
      this.Controls.Add(this.lbl2);
      this.Controls.Add(this.btnAccept);
      this.Controls.Add(this.btnCancel);
      this.Name = "frmPlacement";
      this.Text = "SCA: Приходование";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnAccept;
    private System.Windows.Forms.Label lbl2;
    private ScanSSCC txtProdCode;
    private ScanText txtBin;
    private ListView lstData;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
  }
}