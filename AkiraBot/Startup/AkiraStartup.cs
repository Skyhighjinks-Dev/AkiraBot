using AkiraBot.Configuration;
using AkiraBot.Sql;
using System;

namespace AkiraBot.Startup
{
  public class AkiraStartup
  {
    public static void StartUp()
    {
      AkiraConfiguration.Initialize();
      AkiraSql.Initialize();
    }
  }
}
