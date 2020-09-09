using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        //public void Add(Times times)
        //{
        //    cmd = new SqlCommand($"insert into times values ( {times.Cod_camp},  '{times.Dsc_camp}',  {times.Ano}, '{times.Tipo}', '{times.Data_ini}', '{times.Data_fim}', {times.Def_tipo} )", conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}

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
                times.Nom_time = item[1].ToString();
                times.Uf_time = item[2].ToString();
                timesList.Add(times);
            }
            conn.Close();

            return timesList;
        }

        //public void Remove(int codCampeonato)
        //{
        //    cmd = new SqlCommand($"Delete from Times where cod_camp ={codCampeonato}");
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}

        //public void Update(Times times, int codCampeonato)
        //{
        //    cmd = new SqlCommand($"Update times set dsc_camp = '{times.Dsc_camp}',  ano = {times.Ano}, tipo ='{times.Tipo}', data_ini = '{times.Data_ini}', data_fim = '{times.Data_fim}', def_tipo = {times.Def_tipo}  where cod_camp ={codCampeonato}");
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}
