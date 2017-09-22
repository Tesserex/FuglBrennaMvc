using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Models
{
    public partial class Member
    {
        public string DisplayName
        {
            get
            {
                return !string.IsNullOrWhiteSpace(BattleName) ?
                    BattleName :
                    FirstName + " " + LastName;
            }
        }
    }
}