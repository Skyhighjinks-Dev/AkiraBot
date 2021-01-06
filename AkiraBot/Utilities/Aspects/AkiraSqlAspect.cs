using AkiraBot.Sql;
using PostSharp.Aspects;
using System;

namespace AkiraBot.Utilities.Aspects
{
  [Serializable]
  public class AkiraSqlAspect : OnMethodBoundaryAspect
  {
    public override void OnEntry(MethodExecutionArgs args)
    {
      if(AkiraSql.SqlConn.State != System.Data.ConnectionState.Open)
        AkiraSql.SqlConn.Open();
    }

    public override void OnExit(MethodExecutionArgs args)
    {
      if(AkiraSql.SqlConn.State == System.Data.ConnectionState.Open)
        AkiraSql.SqlConn.Close();
    }

    public override void OnException(MethodExecutionArgs args)
    {
      this.OnExit(args);
    }
  }
}
