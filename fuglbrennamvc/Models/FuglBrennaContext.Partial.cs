using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuglBrennaMvc.Models {
    public partial class FuglBrennaEntities {
        public static FuglBrennaEntities Create() {
            return new FuglBrennaEntities();
        }
    }
}