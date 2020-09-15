using Microsoft.Extensions.Configuration;
using Sessao2Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
            GetJogosDiferencaSalarialMaiorQue50();
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

        public IEnumerable<Jogos> GetJogosAtuarIntervaloMenorQue3Dias()
        {
            List<Jogos> jogosList = new List<Jogos>();
            cmd = new SqlCommand($"select jogos.cod_camp, SUM(jo.salario) as salario1, sum(jo2.salario) as salario2 from campeonatos inner join jogos on jogos.cod_camp = campeonatos.cod_camp inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 inner join jogadores as jo on jo.cod_time = t1.cod_time inner join jogadores as jo2 on jo2.cod_time = t2.cod_time Group by jogos.cod_camp, jogos.cod_time1, jogos.cod_time2 having(SUM(jo.salario) - SUM(jo2.salario)) > SUM(jo.salario) * 0.5 OR(SUM(jo2.salario) - SUM(jo.salario)) > SUM(jo.salario) * 0.5 OR (SUM(jo.salario) - SUM(jo2.salario)) > SUM(jo2.salario) * 0.5 OR(SUM(jo2.salario) - SUM(jo.salario)) > SUM(jo2.salario) * 0.5", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {

            }
            conn.Close();

            return jogosList;
        }

        public IEnumerable<Jogos> GetJogosDiferencaSalarialMaiorQue50()
        {

            List<Jogos> jogosList = new List<Jogos>();
            cmd = new SqlCommand($"select jogos.cod_camp, SUM(jo.salario) as salario1, sum(jo2.salario) as salario2 from campeonatos inner join jogos on jogos.cod_camp = campeonatos.cod_camp inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 inner join jogadores as jo on jo.cod_time = t1.cod_time inner join jogadores as jo2 on jo2.cod_time = t2.cod_time Group by jogos.cod_camp, jogos.cod_time1, jogos.cod_time2 having(SUM(jo.salario) - SUM(jo2.salario)) > SUM(jo.salario) * 0.5 OR(SUM(jo2.salario) - SUM(jo.salario)) > SUM(jo.salario) * 0.5 OR (SUM(jo.salario) - SUM(jo2.salario)) > SUM(jo2.salario) * 0.5 OR(SUM(jo2.salario) - SUM(jo.salario)) > SUM(jo2.salario) * 0.5 Go", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            int i = 0;
            foreach (DataRow item in dt.Rows)
            {
                var salario1 = Convert.ToDecimal(item["salario1"]);
                var salario2 = Convert.ToDecimal(item["salario2"]);
                var codCamp = Convert.ToInt32(item["cond_camp"]);
                decimal[] grupo1 = new decimal[dt.Rows.Count];
                decimal[] grupo2 = new decimal[dt.Rows.Count];
                decimal[] grupo3 = new decimal[dt.Rows.Count];
                decimal[] grupo4 = new decimal[dt.Rows.Count];
                decimal[] grupo5 = new decimal[dt.Rows.Count];
                switch (codCamp)
                {
                    case 1:
                        grupo1[i] = codCamp;
                        grupo1[i] = salario1;
                        grupo1[i] = salario2;
                        break;
                    case 2:
                        grupo2[i] = codCamp;
                        grupo2[i] = salario1;
                        grupo2[i] = salario2;
                        break;
                    case 3:
                        grupo3[i] = codCamp;
                        grupo3[i] = salario1;
                        grupo3[i] = salario2;
                        break;
                    case 4:
                        grupo4[i] = codCamp;
                        grupo4[i] = salario1;
                        grupo4[i] = salario2;
                        break;
                    case 5:
                        grupo4[i] = codCamp;
                        grupo4[i] = salario1;
                        grupo4[i] = salario2;
                        break;

                }
                i++;
                Console.WriteLine(grupo1);
                Console.WriteLine(grupo2);
                Console.WriteLine(grupo3);
                Console.WriteLine(grupo4);
                Console.WriteLine(grupo5);
            }
            conn.Close();

            return jogosList;
        }

        public IEnumerable<Jogos> GetJogosMenorFolhaSalarialVenceu()
        {
            List<Jogos> jogosList = new List<Jogos>();
            cmd = new SqlCommand("select jogos.resultado, jogos.data, campeonatos.dsc_camp ,t1.nom_time as time1, t2.nom_time as time2, SUM(jo.salario) as salario1, sum(jo2.salario) as salario2 from jogos " +
                "inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 inner join jogadores as jo on jo.cod_time = t1.cod_time " +
                "inner join jogadores as jo2 on jo2.cod_time = t2.cod_time inner join campeonatos on jogos.cod_camp = campeonatos.cod_camp group by jogos.cod_time1, jogos.cod_time2, " +
                "jogos.cod_camp, resultado, t1.nom_time, t2.nom_time, campeonatos.dsc_camp, jogos.data having resultado <> 0", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                var salario1 = Convert.ToDecimal(item["salario1"]);
                var salario2 = Convert.ToDecimal(item["salario2"]);
                var resultado = Convert.ToInt32(item["resultado"]);
                if (salario1 > salario2 && resultado == 2)
                {
                    Jogos jogos = new Jogos();
                    jogos.Campeonatos = item["dsc_camp"].ToString();
                    jogos.Data = Convert.ToDateTime(item["data"]);
                    jogos.Time1 = item["time1"].ToString();
                    jogos.Time2 = item["time2"].ToString();
                    jogosList.Add(jogos);
                }
            }
            conn.Close();

            return jogosList;
        }
    }
}
