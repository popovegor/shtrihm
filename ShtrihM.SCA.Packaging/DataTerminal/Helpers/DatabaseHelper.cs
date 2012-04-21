using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using System.Data;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  internal static class DatabaseHelper
  {

    public static void ExecuteNonQuery(SqlCommand cmd)
    {
      var act = new Func<int?>(() => new Nullable<int>(cmd.ExecuteNonQuery()));
      Execute<Nullable<int>>(cmd, act);
    }

    public static T ExecuteScalar<T>(SqlCommand cmd)
    {
      var act = new Func<T>(() =>
       {
         var val = cmd.ExecuteScalar();
         return val == null || val == DBNull.Value ? default(T) : (T)val;
       });
      return Execute<T>(cmd, act);
    }

    public static DataSet ExecuteDataSet(SqlCommand cmd)
    {
      var act = new Func<DataSet>(() =>
      {
        using (var adapter = new SqlDataAdapter(cmd))
        {
          DataSet ds = new DataSet();
          adapter.Fill(ds);
          return ds;
        }
      });
      return Execute<DataSet>(cmd, act);
    }

    private static T Execute<T>(SqlCommand cmd, Func<T> exec)
    {
      try
      {
        using (var con = new SqlConnection(ConfigHelper.GetConnectionString("db")))
        {
          if (con.State == System.Data.ConnectionState.Closed)
          {
            con.Open();
          }
          cmd.Connection = con;
          return exec();
        }
      }
      catch (SqlException sqlEx)
      {
        if (sqlEx.Number == 6 || sqlEx.Number == 17)
        {
          throw new ExternalException("Не удалось соединиться с БД.", sqlEx);
        }
        throw new ExternalException("Произошла ошибка БД.", sqlEx);
      }
      catch (Exception e)
      {
        var msg = string.Format("Не удалось выполнить запрос {0}.", cmd.CommandText);
        throw new InternalException(msg, e);
      }
    }

  }
}
