using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerSide.Models
{
    public class Reservation
    {
        public int RID { get; set; }

        public string Cname { get; set; }

        public string Bname { get; set; }

        public string BSname { get; set; }

        public string ServiceName { get; set; }

        public string RTime { get; set; }

        public string Status { get; set; }

        public int Day { get; set; }
        public int CID { get; set; }
        public int BID { get; set; }

    }
}