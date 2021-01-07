using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkiraBot.Commands.Administrative
{
  public class AkiraBan : ModuleBase<SocketCommandContext>
  {
    [Command("ban", RunMode = RunMode.Async)]
    public async Task Ban(SocketGuildUser nTarget, [Remainder] string reason = null)
    { 
      
    }
  }
}
