using AkiraBot.Configuration;
using Discord;
using Discord.WebSocket;
using System.Linq;

namespace AkiraBot.Utilities
{
  public static class AkiraCommandUtility
  { 
    public static bool RoleSuperiorityCheck(this SocketGuildUser nSender, SocketGuildUser nTarget)
    { 
      SocketGuild guild = nTarget.Guild;

      if(nSender.GetHighestRolePosition() > nTarget.GetHighestRolePosition())
        return true;

      return false;
    }

    public static bool CheckUserIsStaff(this SocketGuildUser nSender)
    { 
      if(AkiraConfiguration.AkiraPerferStaffId)
        return nSender.Roles.Any(x => AkiraConfiguration.StaffMappings.Any(y => (ulong)y.ID == x.Id));

      else
        return nSender.Roles.Any(x => AkiraConfiguration.StaffMappings.Any(y => y.Name.ToLower() == x.Name.ToLower()));
    }

    private static int GetHighestRolePosition(this SocketGuildUser nUser)
    { 
      return nUser.Roles.OrderByDescending(x => x.Position).First().Position;
    }
  }
}
