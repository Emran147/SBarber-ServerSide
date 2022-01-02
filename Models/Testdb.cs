using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServerSide.Models
{
    public class Testdb
    {
        static readonly string Constr = ConfigurationManager.ConnectionStrings["production"].ConnectionString;


        private static List<Reservation> ExcQ(string query)
        {
            SqlConnection con = new SqlConnection(Constr);

            SqlDataAdapter adptr = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adptr.Fill(ds);
            List<Reservation> ls = ds.Tables[0].AsEnumerable()
                .Select(use => new Reservation()
                {
                    RID = use.Field<int>("RID"),
                    Cname = use.Field<string>("Cname"),
                    Bname = use.Field<string>("Bname"),
                    ServiceName = use.Field<string>("ServiceName"),
                    RTime = use.Field<string>("RTime"),
                    Status = use.Field<string>("Status"),
                    Day = use.Field<int>("Day"),
                    CID = use.Field<int>("CID"),
                    BID = use.Field<int>("BID"),
                }).ToList();
            return ls;
        }

        internal static object GetResrvetions(Reservation resrv)
        {
            return ExcQ($"select RTime from Reservations where Reservations.BID={resrv.BID} and Reservations.Day={resrv.Day}");
        }
    }
}