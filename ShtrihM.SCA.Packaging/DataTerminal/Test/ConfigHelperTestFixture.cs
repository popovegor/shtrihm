using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;

namespace ShtrihM.SCA.Packaging.DataTerminal.Test
{
  [TestFixture]
  public class ConfigHelperTestFixture
  { 
    [TestCase("db", @"Data Source=.\sqlexpress; Initial Catalog=sca;Integrated Security=true;user=webusr;password=webpass")]
    public void can_fetch_connection_string_from_app_settings(string key, string cs)
    {
      //arrange & act
      var constring = ConfigHelper.GetConnectionString(key);
      //assert
      Assert.AreEqual(cs,constring);
    }
  }
}
