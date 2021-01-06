using AkiraBot.Startup;
using PostSharp.Aspects;
using System;

namespace AkiraBot.Utilities.Aspects
{
  [Serializable]
  public class AkiraMainAspect : OnMethodBoundaryAspect
  {
    public override void OnEntry(MethodExecutionArgs args)
    {
      AkiraStartup.StartUp();
    }
  }
}
