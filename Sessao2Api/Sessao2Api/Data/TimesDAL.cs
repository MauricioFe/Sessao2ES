using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Sessao2Api.Data
{
    public class TimesDAL : ITimesDAL
    {
        private readonly string _conn;
        SqlConnection conn;
        public TimesDAL(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(_conn);
        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;

        public IEnumerable<Times> GetAll()
        {
            List<Times> timesList = new List<Times>();
            cmd = new SqlCommand("select * from times", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Times times = new Times();
                times.Cod_time = Convert.ToInt32(item[0]);
                times.Nom_time = item[2].ToString();
                times.Uf_time = item[1].ToString();
                timesList.Add(times);
            }
            conn.Close();

            return timesList;
        }
    }
}
