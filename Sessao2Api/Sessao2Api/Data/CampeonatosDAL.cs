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
    public class CampeonatosDAL : ICampeonatosDAL
    {
        private readonly string _conn;
        SqlConnection conn;
        public CampeonatosDAL(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(_conn);
        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        public void Add(Campeonatos campeonatos)
        {
            cmd = new SqlCommand($"insert into campeonatos values ( {campeonatos.Cod_camp},  '{campeonatos.Dsc_camp}',  {campeonatos.Ano}, '{campeonatos.Tipo}', '{campeonatos.Data_ini.ToString("yyyy-MM-dd")}', '{campeonatos.Data_fim.ToString("yyyy-MM-dd")}', '{campeonatos.Def_tipo}')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public IEnumerable<Campeonatos> GetAll()
        {
            List<Campeonatos> campeonatosList = new List<Campeonatos>();
            cmd = new SqlCommand("select * from campeonatos", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Campeonatos campeonatos = new Campeonatos();
                campeonatos.Cod_camp = Convert.ToInt32(item[0]);
                campeonatos.Dsc_camp = item[1].ToString();
                campeonatos.Ano = Convert.ToInt32(item[2]);
                campeonatos.Tipo = item[3].ToString();
                campeonatos.Data_ini = Convert.ToDateTime(item[4]);
                campeonatos.Data_fim = Convert.ToDateTime(item[5]);
                campeonatos.Def_tipo = item[6].ToString();
                campeonatosList.Add(campeonatos);
            }
            conn.Close();

            return campeonatosList;
        }

        public void Remove(int codCampeonato)
        {
            cmd = new SqlCommand($"Delete from Campeonatos where cod_camp ={codCampeonato}", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(Campeonatos campeonatos, int codCampeonato)
        {
            cmd = new SqlCommand($"Update campeonatos set dsc_camp = '{campeonatos.Dsc_camp}',  ano = {campeonatos.Ano}, tipo ='{campeonatos.Tipo}', data_ini = '{campeonatos.Data_ini.ToString("yyyy-MM-dd")}', data_fim = '{campeonatos.Data_fim.ToString("yyyy-MM-dd")}', def_tipo = {campeonatos.Def_tipo}  where cod_camp ={codCampeonato}", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
