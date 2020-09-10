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
    public class HistoricosDAL : IHistoricosDAL
    {
        private readonly string _conn;
        SqlConnection conn;
        public HistoricosDAL(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(_conn);

        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        public void Add(Historicos historicos)
        {
            cmd = new SqlCommand($"insert into historicos values ( {historicos.Cod_jog},  '{historicos.Dat_ini.ToString("yyyy-MM-dd")}',  {historicos.Cod_time}, '{historicos.Dat_fim}')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public IEnumerable<Historicos> GetAll()
        {
            List<Historicos> historicosList = new List<Historicos>();
            cmd = new SqlCommand("select h.cod_jog, h.dat_ini, h.dat_fim, h.cod_time, t.nom_time, j.nom_jog from Historicos as h inner join times as t on t.cod_time = h.cod_time inner join jogadores as j on h.cod_jog = j.cod_jog", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Historicos historicos = new Historicos();
                historicos.Cod_jog = Convert.ToInt32(item[0]);
                historicos.Dat_ini = Convert.ToDateTime(item[1]);
                historicos.Dat_fim = Convert.ToDateTime(item[2].ToString() == "" ? "01/01/0001 00:00:00" : item[2]);
                historicos.Cod_time = Convert.ToInt32(item[3]);
                historicos.Time = item[4].ToString();
                historicos.Jogador = item[5].ToString();
                historicosList.Add(historicos);
            }
            conn.Close();

            return historicosList;
        }
    }
}
