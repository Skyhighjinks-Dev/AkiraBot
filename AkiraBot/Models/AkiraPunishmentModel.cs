using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkiraBot.Models
{
  public class AkiraPunishmentModel
  {
    public enum PunishmentType
    { 
      KICK
    }

    public SocketGuildUser Sender;
    public SocketGuildUser Target;

    public PunishmentType Punishment;
    public string Reason;

    public DateTime PunishmentDate;
    // Used for Temp bans/mutes
    public DateTime? RevertTime;

    public AkiraPunishmentModel(SocketGuildUser nSender, SocketGuildUser nTarget, PunishmentType nPunishment, string nReason, DateTime? nRevertTime = null)
    { 
      this.Sender = nSender;
      this.Target = nTarget;

      this.Punishment = nPunishment;
      this.Reason = nReason;

      this.PunishmentDate = DateTime.Now;
      
      if(nRevertTime.HasValue)
        this.RevertTime = nRevertTime.Value;

      Log();
    }
    
    private void Log()
    { 
      bool isSuccess = false;

      
    }
  }
}
