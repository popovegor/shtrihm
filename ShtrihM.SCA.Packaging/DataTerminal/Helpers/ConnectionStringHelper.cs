using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  public static class ConnectionStringHelper
  {
    public static void From(string cs, out string server, out string db, out string port, out string user, out string pwd)
    {
      var reg = @"Data Source=(?<server>[^,]+),?(?<port>\d*);Initial Catalog=(?<database>.+);Integrated Security=False;User Id=(?<user>.+);Password=(?<pwd>.+)";
      var m = Regex.Match(cs, reg);
      server = m.Groups["server"].Value;
      db = m.Groups["database"].Value;
      port = m.Groups["port"].Value;
      user = m.Groups["user"].Value;
      pwd = m.Groups["pwd"].Value;
    }

    public static string To(string server, string db, string port, string user, string pwd)
    {
      return string.Format("Data Source={0}{1};Initial Catalog={2};Integrated Security=False;User Id={3};Password={4}"
        , server
        , string.IsNullOrEmpty(port) ? string.Empty : string.Format(",{0}", port)
        , db
        , user
        , pwd);
    }
  }
}
