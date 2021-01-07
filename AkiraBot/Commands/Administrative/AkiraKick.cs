using AkiraBot.Configuration;
using AkiraBot.Models;
using AkiraBot.Utilities;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace AkiraBot.Commands.Administrative
{
  public class AkiraKick : ModuleBase<SocketCommandContext>
  {
    [Command("kick", RunMode = RunMode.Async)]
    public async Task Kick(SocketGuildUser nTarget, [Remainder] string reason = null)
    {
      SocketGuildUser sender = this.Context.Guild.GetUser(this.Context.User.Id);

      if (!(this.Context.Guild.GetUser(this.Context.User.Id).CheckUserIsStaff()))
        return;

      // If the user doesn't have a higher role than the target
      if (!this.Context.Guild.GetUser(this.Context.User.Id).RoleSuperiorityCheck(nTarget)) 
        return;

      AkiraPunishmentModel model = new AkiraPunishmentModel(sender, nTarget, AkiraPunishmentModel.PunishmentType.KICK, reason);

      if(AkiraConfiguration.SendKickedUsersMessage)
      {
        IDMChannel channel = await nTarget.GetOrCreateDMChannelAsync();
        string toSend = $"I'm sorry to inform you but you have been kicked from {this.Context.Guild.Name}{(string.IsNullOrEmpty(reason) ? "" : $" for: {reason}")}.";

        if(!string.IsNullOrEmpty(AkiraConfiguration.AkiraDiscordInviteLink))
          toSend += $"\nYou may rejoin the server with the following link: {AkiraConfiguration.AkiraDiscordInviteLink}"; 
      
        await channel.SendMessageAsync(toSend);        
      }

      await nTarget.KickAsync(reason);
    }
  }
}
