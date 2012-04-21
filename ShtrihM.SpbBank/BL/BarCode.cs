using System.Xml.Serialization;


namespace ShtrihM.SpbBank.BL
{
  [XmlRoot("bc")]
  public class BarCode
  {
    [XmlAttribute("brt")]
    public string BarCodeType { get; set; }

    [XmlAttribute("brd")]
    public string BarCodeData { get; set; }

    [XmlIgnore]
    public bool IsEmpty
    {
      get
      {
        return string.IsNullOrEmpty(BarCodeData) == true;
      }
    }
    
    public BarCode()
    {
    }
    
    public BarCode(string type, string code)
    {
      BarCodeData = code;
      BarCodeType = type;
    }
  }
}
