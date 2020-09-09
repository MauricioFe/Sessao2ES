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
    public class EstadiosDAL : IEstadiosDAL
    {
        private readonly string _conn;
        SqlConnection conn;
        public EstadiosDAL(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(_conn);
        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        //public void Add(Estadios estadios)
        //{
        //    cmd = new SqlCommand($"insert into estadios values ( {estadios.Cod_camp},  '{estadios.Dsc_camp}',  {estadios.Ano}, '{estadios.Tipo}', '{estadios.Data_ini}', '{estadios.Data_fim}', {estadios.Def_tipo} )", conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}

        public IEnumerable<Estadios> GetAll()
        {
            List<Estadios> estadiosList = new List<Estadios>();
            cmd = new SqlCommand("select * from estadios", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Estadios estadios = new Estadios();
                estadios.Cod_est = Convert.ToInt32(item[0]);
                estadios.Nom_est = item[1].ToString();
                estadios.Uf_Estadio = item[3].ToString();
                estadios.Capacidade = Convert.ToInt32(item[2]);
                estadiosList.Add(estadios);
            }
            conn.Close();

            return estadiosList;
        }

        //public void Remove(int codCampeonato)
        //{
        //    cmd = new SqlCommand($"Delete from Estadios where cod_camp ={codCampeonato}");
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}

        //public void Update(Estadios estadios, int codCampeonato)
        //{
        //    cmd = new SqlCommand($"Update estadios set dsc_camp = '{estadios.Dsc_camp}',  ano = {estadios.Ano}, tipo ='{estadios.Tipo}', data_ini = '{estadios.Data_ini}', data_fim = '{estadios.Data_fim}', def_tipo = {estadios.Def_tipo}  where cod_camp ={codCampeonato}");
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}
