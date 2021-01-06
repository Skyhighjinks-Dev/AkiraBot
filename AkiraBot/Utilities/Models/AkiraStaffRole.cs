using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkiraBot.Utilities.Models
{
  public class AkiraStaffRole
  {
    public string Name { get; set; }
    public long ID { get; set; }
    public string[] Permissions { get; set; }

    public AkiraStaffRole(string nName, long nID, string[] nPermissions)
    { 
      this.Name = nName;
      this.ID = nID;
      this.Permissions = nPermissions;
    }
  }
}
