
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using ShtrihM.SCA.Packaging.DataTerminal.Helpers;
using System.Data;
using ShtrihM.SCA.Packaging.DataTerminal.Entities;

namespace ShtrihM.SCA.Packaging.DataTerminal.Repositories
{
  public static class Database
  {

    public static DataRow GetProduct(string code)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("GetFromProd"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@SSCCNumber ", code));
          var ds = DatabaseHelper.ExecuteDataSet(cmd);
          return ds.Tables[0].Rows[0];
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = string.Format("Не удалось получить информацию об изделии с номером {0}", code);
        throw new ExternalException(msg, e);
      }
    }

    public static Dictionary<long, string> GetUsers()
    {
      var users = new Dictionary<long, string>();
      using (var cmd = new System.Data.SqlClient.SqlCommand("getFIO"))
      {
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        try
        {
          var ds = DatabaseHelper.ExecuteDataSet(cmd);
          for (int i = 0; ds != null && ds.Tables.Count != 0 && i < ds.Tables[0].Rows.Count; i++)
          {
            DataRow row = ds.Tables[0].Rows[i];
            try
            {
              long id = (long)row["ID"];
              string fio = (string)row["FIO"];
              users.Add(id, fio);
            }
            catch (Exception inEx) { LogHelper.Dump(inEx); }
          }
        }
        catch (ExternalException)
        {
          throw;
        }
        catch (Exception e)
        {
          throw new ExternalException("Не удалось получить список пользователей.", e);
        }
      }
      return users;
    }

    internal static UserEntity Login(long id, string pwd)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("SotrAuth"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@UserID", id));
          cmd.Parameters.Add(new SqlParameter("@Password ", pwd));
          var roleId = DatabaseHelper.ExecuteScalar<long>(cmd);
          var role = (UserRole)roleId;
          if (role == UserRole.None)
          {
            throw new Exception("Role == None");
          }
          return new UserEntity()
          {
            FullName = string.Empty,
            Id = id,
            Role = role
          };
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = string.Format("Ошибка входа в систему пользователем с ID {0}", id);
        throw new ExternalException(msg, e);
      }
    }

    internal static void Logout(long id)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("SotrOut"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@UserID", id));
          DatabaseHelper.ExecuteNonQuery(cmd);
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = string.Format("Ошибка выхода из системы пользователем с ID {0}", id);
        throw new ExternalException(msg, e);
      }
    }

    internal static int PutToBin(long palletId, string code, string bin, long user)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("PutToStockBin"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@PalletID", palletId));
          cmd.Parameters.Add(new SqlParameter("@BinName ", bin));
          cmd.Parameters.Add(new SqlParameter("@UserID ", user));
          return DatabaseHelper.ExecuteScalar<int>(cmd);
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = string.Format("Ошибка приходования продукции с номером {0}", code);
        throw new ExternalException(msg, e);
      }
    }

    internal static DataRow GetForMove(string code, long user)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("GetForMove"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@SSCCNumber", code));
          //cmd.Parameters.Add(new SqlParameter("@UserID", user));
          var ds = DatabaseHelper.ExecuteDataSet(cmd);
          return ds.Tables[0].Rows[0];
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = string.Format("Не удалось получить информацию об изделии с номером {0} для выполнения операции перемещения.", code);
        throw new ExternalException(msg, e);
      }
    }

    internal static int MoveBin(long pallet, string bin, long user)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("MoveBin"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@PalletID", pallet));
          cmd.Parameters.Add(new SqlParameter("@BinName", bin));
          cmd.Parameters.Add(new SqlParameter("@UserID", user));
          return DatabaseHelper.ExecuteScalar<int>(cmd);
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = "Не удалось выполнить операцию перемещения.";
        throw new ExternalException(msg, e);
      }
    }


    internal static DataTable LoadPickingList(long list, long action, long user)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("LoadPickingList"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@PickingListID", list));
          cmd.Parameters.Add(new SqlParameter("@ActionID", action));
          cmd.Parameters.Add(new SqlParameter("@UserID", user));
          return DatabaseHelper.ExecuteDataSet(cmd).Tables[0];
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = string.Format("Ошибка операции с номером {0}", action);
        switch (action)
        {
          case 4:
            msg = "Не удалось загрузить задание на инвентаризацию.";
            break;
          case 3:
            msg = "Не удалось загрузить задание на отгрузку.";
            break;
        }
        throw new ExternalException(msg, e);
      }
    }

    internal static void EndOfPickingList(long list, int status, long user)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("EndOfPickingList"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@PickingListID", list));
          cmd.Parameters.Add(new SqlParameter("@Status", status));
          cmd.Parameters.Add(new SqlParameter("@UserID", user));
          DatabaseHelper.ExecuteNonQuery(cmd);
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = "Не удалось завершить задание.";
        throw new ExternalException(msg, e);
      }
    }

    internal static long? CheckPallet(long id, string num, long user)
    { 
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("CheckPallet"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@TaskListID", id));
          //cmd.Parameters.Add(new SqlParameter("@SSCCNumber ", num));
          cmd.Parameters.Add(new SqlParameter("@UserID", user));
          return DatabaseHelper.ExecuteScalar<long?>(cmd);
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = "Не удалось проверить паллету.";
        throw new ExternalException(msg, e);
      }
    }

    internal static bool CheckConnection(string cs)
    {
      try
      {
        using (var con = new System.Data.SqlClient.SqlConnection(cs))
        {
          if(con.State == ConnectionState.Closed)
          {
            con.Open();
          }
          return true;
        }
      }
      catch(Exception e)
      {
        throw new ExternalException("Не удалось соединиться с БД.", e);
      }
    }

    internal static void SetAction(long act, long user)
    {
      try
      {
        using (var cmd = new System.Data.SqlClient.SqlCommand("SetAction"))
        {
          cmd.CommandType = System.Data.CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@ActionID", act));
          cmd.Parameters.Add(new SqlParameter("@UserID", user));
          DatabaseHelper.ExecuteNonQuery(cmd);
        }
      }
      catch (ExternalException)
      {
        throw;
      }
      catch (Exception e)
      {
        var msg = "Не удалось зафиксировать действие в БД.";
        throw new ExternalException(msg, e);
      }
    }
  }
}
