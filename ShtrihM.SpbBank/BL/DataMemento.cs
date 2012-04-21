using System;

using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace ShtrihM.SpbBank.BL
{
  public class DataMemento
  {

    [XmlRoot("row")]
    public class DataItem
    {

      public DataItem()
      { }

      public DataItem(string atm, string barcode)
      {
        Atm = atm;
        Barcode = barcode;
      }

      [XmlAttribute("atm")]
      public string Atm { get; set; }

      [XmlAttribute("barcode")]
      public string Barcode { get; set; }
    }

    public bool HasState
    {
      get
      {
        return File.Exists(StateFullPath) &&  (new FileInfo(StateFullPath)).Length > 0;
      }
    }
    
    public void RemoveState()
    {
      if(File.Exists(StateFullPath))
      {
        File.Delete(StateFullPath);
      }
    }

    private string StateFullPath
    {
      get
      {
        var path = Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
          , "ShtrihM");
        if (Directory.Exists(path) == false)
        {
          Directory.CreateDirectory(path);
        }
        return Path.Combine(path, "backup.xml");
      }
    }

    public List<DataItem> GetState()
    {
      List<DataItem> lst = new List<DataItem>();
      try
      {
        if (File.Exists(StateFullPath))
        {
          XmlSerializer ser = new XmlSerializer(lst.GetType());
          using (Stream stream = File.OpenRead(StateFullPath))
          {
            lst = (List<DataItem>)ser.Deserialize(stream);
          }
        }
      }
      catch (Exception)
      {
        MessageBox.Show(string.Format("Не удалось прочитать файл резервной копии данных {0}", StateFullPath)
          , "Ошибка чтения файла"
          , MessageBoxButtons.OK
          , MessageBoxIcon.Exclamation
          , MessageBoxDefaultButton.Button1);
      }
      return lst;
    }

    public void SetState(List<DataItem> data)
    {
      try
      {
        using (Stream stream = File.Create(StateFullPath))
        {
          XmlSerializer ser = new XmlSerializer(data.GetType());
          ser.Serialize(stream, data);
        }
      }
      catch (Exception)
      {
        MessageBox.Show(string.Format("Не удалось записать файл резервной копии данных {0}", StateFullPath)
          , "Ошибка записи файла"
          , MessageBoxButtons.OK
          , MessageBoxIcon.Exclamation
          , MessageBoxDefaultButton.Button1);
      }
    }
  }
}
