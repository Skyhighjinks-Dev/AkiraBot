using AkiraBot.Interfaces;
using AkiraBot.Threading.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AkiraBot.Threading
{
  public static class AkiraThread
  {
    public static void Initialize()
    {
      List<IAkiraThread> threadList = new List<IAkiraThread>()
      { 
        new AkiraBanThread(),
        new AkiraMuteThread(),
        new AkiraEventThread()
      };

      List<Thread> toReturn = new List<Thread>();
      threadList.ForEach(x => toReturn.Add(new Thread(new ThreadStart(() => x.InitializeThread()))));
    }
  }
}
