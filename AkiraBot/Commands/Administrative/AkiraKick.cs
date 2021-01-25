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
    /// <summary>
    /// Kicks a user from the discord guild
    /// </summary>
    /// <param name="nTarget">Object that represents the person being targetted for command</param>
    /// <param name="nReason">Reason for kicking - Default is null</param>
    /// <returns>Task</returns>
    [Command("kick", RunMode = RunMode.Async)]
    public async Task Kick(SocketGuildUser nTarget, [Remainder] string nReason = null)
    {
      SocketGuildUser sender = this.Context.Guild.GetUser(this.Context.User.Id);

      if (!(sender.CheckUserIsStaff()))
        return;

      // If the user doesn't have a higher role than the target
      if (!sender.RoleSuperiorityCheck(nTarget)) 
        return;

      AkiraPunishmentModel model = new AkiraPunishmentModel(sender, nTarget, AkiraPunishmentModel.PunishmentType.KICK, nReason);

      if(AkiraConfiguration.SendKickedUsersMessage)
      {
        IDMChannel channel = await nTarget.GetOrCreateDMChannelAsync();
        string toSend = $"I'm sorry to inform you but you have been kicked from {this.Context.Guild.Name}{(string.IsNullOrEmpty(nReason) ? "" : $" for: {nReason}")}.";

        if(!string.IsNullOrEmpty(AkiraConfiguration.AkiraDiscordInviteLink))
          toSend += $"\nYou may rejoin the server with the following link: {AkiraConfiguration.AkiraDiscordInviteLink}"; 
      
        await channel.SendMessageAsync(toSend);        
      }

      await nTarget.KickAsync(nReason);
    }
  }
}
