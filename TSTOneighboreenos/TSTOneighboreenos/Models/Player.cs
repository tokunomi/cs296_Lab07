using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSTOneighboreenos.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string TSTOhandle { get; set; }  // Name player is using on TSTO
        public int Level { get; set; }  // TSTO level
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public char MidInit { get; set; }  // Middle initial (optional)
        public string Email { get; set; }
        public string SpringfieldPath { get; set; }  // Path to Springfield screenshot
        public Boolean Active { get; set; }  // Is player active?
        public Boolean AddMe { get; set; }  // Looking for new neighbors?

        public virtual ICollection<Friend> Friends { get; set; }  // Bridge leading to Neighbors entity/table
    }
}