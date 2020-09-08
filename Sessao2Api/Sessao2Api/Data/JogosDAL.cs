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
    public class JogosDAL : IJogosDAL
    {
        private readonly string _conn;
        SqlConnection conn;
        public JogosDAL(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(_conn);
        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        public void Add(Jogos jogos)
        {
            cmd = new SqlCommand($"insert into jogos values ( {jogos.Cod_camp},  {jogos.Cod_time1},  {jogos.Cod_time2}, {jogos.Cod_estadio}, '{jogos.Data}', {jogos.Resultado} )", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public IEnumerable<Jogos> GetAll()
        {
            List<Jogos> jogosList = new List<Jogos>();
            cmd = new SqlCommand("select * from jogos", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Jogos jogos = new Jogos();
                jogos.Cod_camp = Convert.ToInt32(item[0]);
                jogos.Cod_time1 = Convert.ToInt32(item[1]);
                jogos.Cod_time2 = Convert.ToInt32(item[2]);
                jogos.Cod_estadio = Convert.ToInt32(item[3]);
                jogos.Data = Convert.ToDateTime(item[4]);
                jogos.Resultado = Convert.ToInt32(item[5]);
                jogosList.Add(jogos);
            }
            conn.Close();

            return jogosList;
        }

        public void Remove(int codCampeonato, int codTime1, int codTime2)
        {
            cmd = new SqlCommand($"Delete from Jogos where cod_camp ={codCampeonato} and cod_time1 ={codTime1} and cod_time2 ={codTime2}", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(Jogos jogos, int codCampeonato, int codTime1, int codTime2)
        {
            cmd = new SqlCommand($"Update jogos set cod_camp = {jogos.Cod_camp},  cod_time1 = {jogos.Cod_time1},  cod_time2 = {jogos.Cod_time2}, cod_estadio = {jogos.Cod_estadio}, data = '{jogos.Data}', resultado = {jogos.Resultado}  where cod_camp ={codCampeonato} and cod_time1 ={codTime1} and cod_time2 ={codTime2} ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
