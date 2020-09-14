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
            cmd = new SqlCommand($"insert into jogos values ( {jogos.Cod_camp},  {jogos.Cod_time1},  {jogos.Cod_time2}, {jogos.Cod_estadio}, '{jogos.Data.ToString("yyyy-MM-dd")}', {jogos.Resultado} )", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public IEnumerable<Jogos> GetAll()
        {
            List<Jogos> jogosList = new List<Jogos>();
            cmd = new SqlCommand("select j.cod_camp, j.cod_time1,j.cod_time2, j.cod_estadio, j.data, j.resultado, c.dsc_camp, t1.nom_time, t2.nom_time, e.nom_est from jogos as j inner join campeonatos c on c.cod_camp = j.cod_camp inner join times as t1 on j.cod_time1 = t1.cod_time inner join times AS t2 on j.cod_time2 = t2.cod_time inner join estadios as e on j.cod_estadio = e.cod_est", conn);
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
                jogos.Campeonatos = item[6].ToString();
                jogos.Time1 = item[7].ToString();
                jogos.Time2 = item[8].ToString();
                jogos.Estadio = item[9].ToString();
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
            cmd = new SqlCommand($"Update jogos set cod_camp = {jogos.Cod_camp},  cod_time1 = {jogos.Cod_time1},  cod_time2 = {jogos.Cod_time2}, cod_estadio = {jogos.Cod_estadio}, data = '{jogos.Data.ToString("yyyy-MM-dd")}', resultado = {jogos.Resultado}  where cod_camp ={codCampeonato} and cod_time1 ={codTime1} and cod_time2 ={codTime2} ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public bool ValidaJogo48H(int cod_time1, int cod_time2, DateTime data)
        {
            DateTime teste = data.AddDays(-2);
            cmd = new SqlCommand($"select * from jogos where cod_time1 = {cod_time1} and data Between '{teste.ToString("yyyy-MM-dd")}' and '{data.ToString("yyyy-MM-dd")}'", conn);
            conn.Open();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            int time1 = dt.Rows.Count;
            conn.Close();
            cmd = new SqlCommand($"select * from jogos where cod_time2 = { cod_time2 } and data Between '{teste.ToString("yyyy-MM-dd")}' and '{data.ToString("yyyy-MM-dd")}'", conn);
            conn.Open();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            int time2 = dt.Rows.Count;
            conn.Close();
            if (time1 == 0 && time2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ValidaJogoCampeonato(int cod_camp, int cod_time1, int cod_time2)
        {
            cmd = new SqlCommand($"select * from participacoes where cod_camp = {cod_camp} and cod_time = {cod_time1}", conn);
            conn.Open();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            int time1 = dt.Rows.Count;
            conn.Close();
            cmd = new SqlCommand($"select * from participacoes where cod_camp = {cod_camp} and cod_time = {cod_time2}", conn);
            conn.Open();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            int time2 = dt.Rows.Count;
            conn.Close();
            if (time1 > 0 && time2 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidaDataCampeonato(int cod_camp, DateTime date)
        {
            cmd = new SqlCommand($"select * from campeonatos where cod_camp = {cod_camp} and dat_ini <= '{date.ToString("yyyy-MM-dd")}' And dat_fim >=  '{date.ToString("yyyy-MM-dd")}'", conn);
            conn.Open();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            int count = dt.Rows.Count;
            conn.Close();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Jogos> GetJogosArte()
        {
            List<Jogos> jogosList = new List<Jogos>();
            cmd = new SqlCommand($"select j.cod_camp, j.cod_time1,j.cod_time2, j.cod_estadio, j.data, j.resultado, c.dsc_camp, t1.nom_time, t2.nom_time, e.nom_est from jogos as j inner join campeonatos c on c.cod_camp = j.cod_camp inner join times as t1 on j.cod_time1 = t1.cod_time inner join times AS t2 on j.cod_time2 = t2.cod_time inner join estadios as e on j.cod_estadio = e.cod_est where j.Data > '{DateTime.Now.ToString("yyyy-MM-dd")}'", conn);
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
                jogos.Resultado = Convert.ToInt32(item[5].ToString() == "" ? 0 : item[5]);
                jogos.Campeonatos = item[6].ToString();
                jogos.Time1 = item[7].ToString();
                jogos.Time2 = item[8].ToString();
                jogos.Estadio = item[9].ToString();
                jogosList.Add(jogos);
            }
            conn.Close();

            return jogosList;
        }
    }
}
