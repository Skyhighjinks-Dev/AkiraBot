using AkiraBot.Configuration;
using AkiraBot.Models;
using AkiraBot.Utilities;
using Discord;
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
      SocketGuildUser sender = this.Context.Guild.GetUser(this.Context.User.Id);

      if(!(sender.CheckUserIsStaff()))
        return;

      if(!sender.RoleSuperiorityCheck(nTarget))
        return;

      AkiraPunishmentModel model = new AkiraPunishmentModel(sender, nTarget, AkiraPunishmentModel.PunishmentType.BAN, reason);

      if (AkiraConfiguration.SendKickedUsersMessage)
      {
        IDMChannel channel = await nTarget.GetOrCreateDMChannelAsync();
        string toSend = $"I'm sorry to inform you but you have been banned from {this.Context.Guild.Name}{(string.IsNullOrEmpty(reason) ? "" : $" for: {nReason}")}.";

        if (!string.IsNullOrEmpty(AkiraConfiguration.AkiraDiscordInviteLink))
          toSend += $"\nYou may rejoin the server with the following link: {AkiraConfiguration.AkiraDiscordInviteLink} if unbanned.";

        await channel.SendMessageAsync(toSend);
      }

      await this.Context.Guild.AddBanAsync(nTarget, reason: reason);
    }
  }
}
