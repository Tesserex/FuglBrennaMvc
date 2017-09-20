using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Models {
    public class AddMemberModel {
        public int SubRealmId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BattleName { get; set; }
    }
}