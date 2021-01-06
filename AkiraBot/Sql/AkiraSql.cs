using AkiraBot.Configuration;
using AkiraBot.Models;
using AkiraBot.Utilities.Aspects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkiraBot.Sql
{
  public static class AkiraSql
  {
    #region Enum

    public enum AkiraSqlScripts
    { 
      GetConfiguration
    }

    #endregion

    #region Public Properties

    public static SqlConnection SqlConn  { get; set; } = null;

    #endregion

    #region Private Properties

    private static string k_DefaultSqlFolderLoc = Environment.CurrentDirectory + @"..\..\..\..\Sql\Scripts\";

    #endregion

    #region Public Methods
    public static void Initialize()
    { 
      if(SqlConn != null)
        return;

      SqlConn = new SqlConnection(AkiraConfiguration.AkiraSqlConnStr);
    }

    // Need to do the automatic initialization of the SqlConnection -- Look at previous bot
    [AkiraSqlAspect]
    public static string GetConfigurationValue(string nConfigName)
    { 
      string cmdText = GetSqlScript(AkiraSqlScripts.GetConfiguration);

      try
      { 
        using(SqlCommand cmd = new SqlCommand(cmdText, SqlConn))
        { 
          cmd.Parameters.AddWithValue("confName", nConfigName);

          return (string)cmd.ExecuteScalar();
        }
      }
      catch (Exception ex)
      {
        return "Cannot find a value";
      }
    }

    public static bool LogPunishment(AkiraPunishmentModel nModel)
    { 
      return false;
    }

    #endregion

    #region Privatre Methods

    private static string GetSqlScript(AkiraSqlScripts nOption)
    {
      switch (nOption)
      {
        case AkiraSqlScripts.GetConfiguration:
          return File.ReadAllText(k_DefaultSqlFolderLoc + "GetConfig.sql"); // need to test
      }
      return "";
    }

    #endregion
  }
}
