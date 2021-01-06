using AkiraBot.Utilities;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkiraBot.Commands.Administrative
{
  public class KickCommand : ModuleBase<SocketCommandContext>
  {
    [Command("kick", RunMode = RunMode.Async)]
    public async Task Kick(SocketGuildUser nTarget, [Remainder] string reason = null)
    {
      if (!(this.Context.Guild.GetUser(this.Context.User.Id).CheckUserIsStaff()))
        return;

      // If the user doesn't have a higher role than the target
      if (!this.Context.Guild.GetUser(this.Context.User.Id).RoleSuperiorityCheck(nTarget)) 
        return;

    }
  }
}
