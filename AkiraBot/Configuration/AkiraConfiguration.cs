using AkiraBot.Utilities;
using AkiraBot.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AkiraBot.Configuration
{
  public static class AkiraConfiguration
  {
    public static string AkiraSqlConnStr;
    public static bool AkiraPerferStaffId;
    public static List<AkiraStaffRole> StaffMappings;

    public static void Initialize()
    { 
      string akiraDbConnStr = AkiraConversion.ConvertFromBase64(ConfigurationManager.ConnectionStrings["AkiraDb"].ConnectionString);
      AkiraSqlConnStr = string.IsNullOrEmpty(akiraDbConnStr) ? string.Empty : akiraDbConnStr;

      AkiraPerferStaffId = ConfigurationManager.AppSettings["PerferIdOverNames"].ToLower() == "true";

      InitializeStaffMapping();
    }

    private static void InitializeStaffMapping()
    {
      StaffMappings = new List<AkiraStaffRole>();
      string confStr = string.IsNullOrEmpty(ConfigurationManager.AppSettings["AkiraStaffMapping"]) ? string.Empty : ConfigurationManager.AppSettings["AkiraStaffMapping"];

      string[] roleCluster = confStr.Split(';');

      foreach(string roleInfo in roleCluster)
      { 
        if(string.IsNullOrEmpty(roleInfo))
          continue;

        try
        { 
          if(!(roleInfo.Contains(':') && roleInfo.Contains('\\')))
          { 
            throw new Exception("Invalid Configuration of Staff Mapping");
          }

          //founder:744300508952526949\kick,ban;

          string roleName = roleInfo.Split(':')[0];
          long roleId = long.Parse(roleInfo.Split(':')[1].Split('\\')[0]);
          string[] rolePermissions = roleInfo.Split('\\')[1].Split(',');


          AkiraStaffRole role = new AkiraStaffRole(roleName, roleId, rolePermissions);

          StaffMappings.Add(role);
        }
        catch(Exception ex)
        { 
          throw new Exception(ex.Message);
        }
      }
    }
  }
}
