using AkiraBot.Sql;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkiraBot.Models
{
  public class AkiraPunishmentModel
  {
    public enum PunishmentType
    { 
      KICK,
      BAN
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

      this.Log();
    }
    
    private void Log()
    { 
      // If this was successful it's sorted
      if(AkiraSql.LogPunishment(this))
        return;      
    }
  }
}
