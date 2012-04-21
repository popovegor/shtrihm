using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace ShtrihM.SCA.Packaging.DataTerminal.Test
{
  [TestFixture]
  public class DatabaseHelperTestFixture
  {
    [TestCase("2011-11-04T11:01:55.000")]
    public void can_execute_scalar_query(string dbDatetime)
    {
      //arrange
      var cmd = new SqlCommand(string.Format("select cast('{0}' as datetime)", dbDatetime));
      var expected = DateTime.Parse(dbDatetime);
      
      //act
      var actual = DatabaseHelper.ExecuteScalar<DateTime>(cmd);
      
      //assert
      Assert.AreEqual(expected, actual);
    }
    
    [TestCase("select 1 as Col, 2 as Col1 union select 2 as Col, 4 as Col1")]
    public void can_execute_dataset_query(string sql)
    {
      //arrange
      var cmd = new SqlCommand(sql);
      DataSet expected = new DataSet();
      var dt = expected.Tables.Add("test");
      dt.Columns.Add("Col", typeof(int));
      dt.Columns.Add("Col1", typeof(int));
      dt.Rows.Add(1, 2);
      dt.Rows.Add(2,4);

      //act
      var actual = DatabaseHelper.ExecuteDataSet(new SqlCommand(sql));

      //assert
      Assert.AreEqual(expected.Tables.Count, actual.Tables.Count);
      Assert.AreEqual(0, actual.Tables[0].Columns.IndexOf("Col"));
      Assert.AreEqual(1, actual.Tables[0].Columns.IndexOf("Col1"));
      Assert.AreEqual(4, (int)actual.Tables[0].Rows[1]["Col1"]);
      
    }
  }
}
