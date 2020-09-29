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
            GetJogosAtuarIntervaloMenorQue3Dias();
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

        public IEnumerable<List<Jogos>> GetJogosAtuarIntervaloMenorQue3Dias()
        {
            List<Jogos> jogosList = new List<Jogos>();
            List<Jogos> jogosList3Dias1 = new List<Jogos>();
            List<Jogos> jogosList3Dias2 = new List<Jogos>();
            List<Jogos> jogosList3Dias3 = new List<Jogos>();
            List<Jogos> jogosList3Dias4 = new List<Jogos>();
            List<Jogos> jogosList3Dias5 = new List<Jogos>();
            List<List<Jogos>> jogosPorCampeonatoList = new List<List<Jogos>>();
            cmd = new SqlCommand($"select jogos.cod_camp, jogos.cod_time1, jogos.cod_time2,data from jogos inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 ", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
            foreach (DataRow item in dt.Rows)
            {

                Jogos jogos = new Jogos();
                jogos.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                jogos.Cod_time1 = Convert.ToInt32(item["cod_time1"]);
                jogos.Cod_time2 = Convert.ToInt32(item["cod_time2"]);
                jogos.Data = Convert.ToDateTime(item["data"]);
                jogosList.Add(jogos);
            }
            foreach (var item in jogosList)
            {
                var data = Convert.ToDateTime(item.Data).AddDays(1);
                var time1 = Convert.ToInt32(item.Cod_time1);
                var time2 = Convert.ToInt32(item.Cod_time2);
                var cod_camp = Convert.ToInt32(item.Cod_camp);
                var data3 = data.AddDays(2);
                //time 1
                cmd = new SqlCommand($"select jogos.cod_camp, jogos.resultado, c.dsc_camp ,t1.nom_time as time1, t2.nom_time as time2, jogos.cod_time1, jogos.cod_time2, data from jogos inner join campeonatos as c on c.cod_camp = jogos.cod_camp inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 where jogos.cod_camp = {cod_camp} and (jogos.cod_time1 = {time1} or jogos.cod_time2 = {time1}) and data between '{data.ToString("yyyy-MM-dd")}' and '{data3.ToString("yyyy-MM-dd")}'", conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow jogoIntervaloMenor3 in dt.Rows)
                    {
                        switch (cod_camp)
                        {
                            case 1:
                                Jogos jogo3Dias1 = new Jogos();
                                jogo3Dias1.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias1.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias1.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias1.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias1.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias1.Campeonatos= jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias1.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias1.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias1.Add(jogo3Dias1);
                                break;
                            case 2:
                                Jogos jogo3Dias2 = new Jogos();
                                jogo3Dias2.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias2.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias2.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias2.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias2.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias2.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias2.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias2.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias2.Add(jogo3Dias2);
                                break;
                            case 3:
                                Jogos jogo3Dias3 = new Jogos();
                                jogo3Dias3.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias3.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias3.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias3.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias3.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias3.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias3.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias3.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias3.Add(jogo3Dias3);
                                break;
                            case 4:
                                Jogos jogo3Dias4 = new Jogos();
                                jogo3Dias4.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias4.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias4.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias4.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias4.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias4.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias4.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias4.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias4.Add(jogo3Dias4);
                                break;
                            case 5:
                                Jogos jogo3Dias5 = new Jogos();
                                jogo3Dias5.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias5.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias5.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias5.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias5.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias5.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias5.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias5.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias5.Add(jogo3Dias5);
                                break;
                        }

                    }
                }
                //time 2
                cmd = new SqlCommand($"select jogos.cod_camp, jogos.resultado, c.dsc_camp ,t1.nom_time as time1, t2.nom_time as time2, jogos.cod_time1, jogos.cod_time2, data from jogos inner join campeonatos as c on c.cod_camp = jogos.cod_camp inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 where jogos.cod_camp = {cod_camp} and (jogos.cod_time1 = {time2} or jogos.cod_time2 = {time2}) and data between '{data.ToString("yyyy-MM-dd")}' and '{data3.ToString("yyyy-MM-dd")}'", conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow jogoIntervaloMenor3 in dt.Rows)
                    {
                        switch (cod_camp)
                        {
                            case 1:
                                Jogos jogo3Dias1 = new Jogos();
                                jogo3Dias1.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias1.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias1.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias1.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias1.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias1.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias1.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias1.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias1.Add(jogo3Dias1);
                                break;
                            case 2:
                                Jogos jogo3Dias2 = new Jogos();
                                jogo3Dias2.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias2.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias2.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias2.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias2.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias2.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias2.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias2.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias2.Add(jogo3Dias2);
                                break;
                            case 3:
                                Jogos jogo3Dias3 = new Jogos();
                                jogo3Dias3.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias3.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias3.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias3.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias3.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias3.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias3.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias3.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias3.Add(jogo3Dias3);
                                break;
                            case 4:
                                Jogos jogo3Dias4 = new Jogos();
                                jogo3Dias4.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias4.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias4.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias4.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias4.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias4.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias4.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias4.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias4.Add(jogo3Dias4);
                                break;
                            case 5:
                                Jogos jogo3Dias5 = new Jogos();
                                jogo3Dias5.Cod_camp = Convert.ToInt32(jogoIntervaloMenor3["cod_camp"]);
                                jogo3Dias5.Cod_time1 = Convert.ToInt32(jogoIntervaloMenor3["cod_time1"]);
                                jogo3Dias5.Cod_time2 = Convert.ToInt32(jogoIntervaloMenor3["cod_time2"]);
                                jogo3Dias5.Time1 = jogoIntervaloMenor3["time1"].ToString();
                                jogo3Dias5.Time2 = jogoIntervaloMenor3["time2"].ToString();
                                jogo3Dias5.Campeonatos = jogoIntervaloMenor3["dsc_camp"].ToString();
                                jogo3Dias5.Resultado = Convert.ToInt32(jogoIntervaloMenor3["resultado"]);
                                jogo3Dias5.Data = Convert.ToDateTime(jogoIntervaloMenor3["Data"]);
                                jogosList3Dias5.Add(jogo3Dias5);
                                break;
                        }
                    }
                }
            }
            jogosPorCampeonatoList.Add(jogosList3Dias1);
            jogosPorCampeonatoList.Add(jogosList3Dias2);
            jogosPorCampeonatoList.Add(jogosList3Dias3);
            jogosPorCampeonatoList.Add(jogosList3Dias4);
            jogosPorCampeonatoList.Add(jogosList3Dias5);
            return jogosPorCampeonatoList;
        }

        public IEnumerable<List<Jogos>> GetJogosDiferencaSalarialMaiorQue50()
        {

            List<Jogos> jogosList1 = new List<Jogos>();
            List<Jogos> jogosList2 = new List<Jogos>();
            List<Jogos> jogosList3 = new List<Jogos>();
            List<Jogos> jogosList4 = new List<Jogos>();
            List<Jogos> jogosList5 = new List<Jogos>();
            List<List<Jogos>> jogosPorCampeonatoList = new List<List<Jogos>>();
            cmd = new SqlCommand("select jogos.cod_camp, jogos.data, jogos.resultado, campeonatos.dsc_camp ,t1.nom_time as time1, t2.nom_time as time2, SUM(jo.salario) as salario1, sum(jo2.salario) as salario2 from campeonatos inner join jogos on jogos.cod_camp = campeonatos.cod_camp inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 inner join jogadores as jo on jo.cod_time = t1.cod_time inner join jogadores as jo2 on jo2.cod_time = t2.cod_time Group by jogos.cod_camp, jogos.cod_time1, jogos.cod_time2, jogos.data, campeonatos.dsc_camp, t1.nom_time, t2.nom_time, jogos.resultado having(SUM(jo.salario) - SUM(jo2.salario)) > SUM(jo.salario) * 0.5 OR(SUM(jo2.salario) - SUM(jo.salario)) > SUM(jo.salario) * 0.5 OR (SUM(jo.salario) - SUM(jo2.salario)) > SUM(jo2.salario) * 0.5 OR(SUM(jo2.salario) - SUM(jo.salario)) > SUM(jo2.salario) * 0.5", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            int i = 0;
            foreach (DataRow item in dt.Rows)
            {
                var salario1 = Convert.ToDecimal(item["salario1"]);
                var salario2 = Convert.ToDecimal(item["salario2"]);
                var codCamp = Convert.ToInt32(item["cod_camp"]);

                switch (codCamp)
                {
                    case 1:
                        Jogos jogos = new Jogos();
                        jogos.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                        jogos.Campeonatos = item["dsc_camp"].ToString();
                        jogos.Data = DateTime.Parse(item["data"].ToString());
                        jogos.Time1 = item["time1"].ToString();
                        jogos.Time2 = item["time2"].ToString();
                        jogos.Resultado = Convert.ToInt32(item["resultado"]);
                        jogosList1.Add(jogos);
                        break;
                    case 2:
                        Jogos jogos2 = new Jogos();
                        jogos2.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                        jogos2.Campeonatos = item["dsc_camp"].ToString();
                        jogos2.Data = DateTime.Parse(item["data"].ToString());
                        jogos2.Time1 = item["time1"].ToString();
                        jogos2.Time2 = item["time2"].ToString();
                        jogos2.Resultado = Convert.ToInt32(item["resultado"]);
                        jogosList2.Add(jogos2);
                        break;
                    case 3:
                        Jogos jogos3 = new Jogos();
                        jogos3.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                        jogos3.Campeonatos = item["dsc_camp"].ToString();
                        jogos3.Data = DateTime.Parse(item["data"].ToString());
                        jogos3.Time1 = item["time1"].ToString();
                        jogos3.Time2 = item["time2"].ToString();
                        jogos3.Resultado = Convert.ToInt32(item["resultado"]);
                        jogosList3.Add(jogos3);
                        break;
                    case 4:
                        Jogos jogos4 = new Jogos();
                        jogos4.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                        jogos4.Campeonatos = item["dsc_camp"].ToString();
                        jogos4.Data = DateTime.Parse(item["data"].ToString());
                        jogos4.Time1 = item["time1"].ToString();
                        jogos4.Time2 = item["time2"].ToString();
                        jogos4.Resultado = Convert.ToInt32(item["resultado"]);
                        jogosList4.Add(jogos4);
                        break;
                    case 5:
                        Jogos jogos5 = new Jogos();
                        jogos5.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                        jogos5.Campeonatos = item["dsc_camp"].ToString();
                        jogos5.Data = DateTime.Parse(item["data"].ToString());
                        jogos5.Time1 = item["time1"].ToString();
                        jogos5.Time2 = item["time2"].ToString();
                        jogos5.Resultado = Convert.ToInt32(item["resultado"]);
                        jogosList5.Add(jogos5);
                        break;
                }
                i++;

            }
            conn.Close();
            jogosPorCampeonatoList.Add(jogosList1);
            jogosPorCampeonatoList.Add(jogosList2);
            jogosPorCampeonatoList.Add(jogosList3);
            jogosPorCampeonatoList.Add(jogosList4);
            jogosPorCampeonatoList.Add(jogosList5);

            return jogosPorCampeonatoList;
        }

        public IEnumerable<List<Jogos>> GetJogosMenorFolhaSalarialVenceu()
        {
            List<List<Jogos>> jogosList = new List<List<Jogos>>();
            List<Jogos> jogosList1 = new List<Jogos>();
            List<Jogos> jogosList2 = new List<Jogos>();
            List<Jogos> jogosList3 = new List<Jogos>();
            List<Jogos> jogosList4 = new List<Jogos>();
            List<Jogos> jogosList5 = new List<Jogos>();
            cmd = new SqlCommand("select jogos.cod_camp as cod_camp,jogos.cod_time1, jogos.cod_time2 ,jogos.resultado, jogos.data, campeonatos.dsc_camp ,t1.nom_time as time1, t2.nom_time as time2, SUM(jo.salario) as salario1, sum(jo2.salario) as salario2 from jogos " +
                "inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 inner join jogadores as jo on jo.cod_time = t1.cod_time " +
                "inner join jogadores as jo2 on jo2.cod_time = t2.cod_time inner join campeonatos on jogos.cod_camp = campeonatos.cod_camp group by jogos.cod_time1, jogos.cod_time2, " +
                "jogos.cod_camp, resultado, t1.nom_time, t2.nom_time, campeonatos.dsc_camp, jogos.data having resultado <> 0", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                var cod_camp = Convert.ToDecimal(item["cod_camp"]);
                var salario1 = Convert.ToDecimal(item["salario1"]);
                var salario2 = Convert.ToDecimal(item["salario2"]);
                var resultado = Convert.ToInt32(item["resultado"]);
                if (salario1 > salario2 && resultado == 2)
                {
                    switch (cod_camp)
                    {
                        case 1:
                            Jogos jogos1 = new Jogos();
                            jogos1.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                            jogos1.Cod_time1 = Convert.ToInt32(item["cod_time1"]);
                            jogos1.Cod_time2 = Convert.ToInt32(item["cod_time2"]);
                            jogos1.Campeonatos = item["dsc_camp"].ToString();
                            jogos1.Data = Convert.ToDateTime(item["data"]);
                            jogos1.Time1 = item["time1"].ToString();
                            jogos1.Time2 = item["time2"].ToString();
                            jogos1.Resultado = Convert.ToInt32(item["resultado"]);
                            jogosList1.Add(jogos1);
                            break;
                        case 2:
                            Jogos jogos2 = new Jogos();
                            jogos2.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                            jogos2.Cod_time1 = Convert.ToInt32(item["cod_time1"]);
                            jogos2.Cod_time2 = Convert.ToInt32(item["cod_time2"]);
                            jogos2.Campeonatos = item["dsc_camp"].ToString();
                            jogos2.Data = Convert.ToDateTime(item["data"]);
                            jogos2.Time1 = item["time1"].ToString();
                            jogos2.Time2 = item["time2"].ToString();
                            jogos2.Resultado = Convert.ToInt32(item["resultado"]);
                            jogosList2.Add(jogos2);
                            break;
                        case 3:
                            Jogos jogos3 = new Jogos();
                            jogos3.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                            jogos3.Cod_time1 = Convert.ToInt32(item["cod_time1"]);
                            jogos3.Cod_time2 = Convert.ToInt32(item["cod_time2"]);
                            jogos3.Campeonatos = item["dsc_camp"].ToString();
                            jogos3.Data = Convert.ToDateTime(item["data"]);
                            jogos3.Time1 = item["time1"].ToString();
                            jogos3.Time2 = item["time2"].ToString();
                            jogos3.Resultado = Convert.ToInt32(item["resultado"]);
                            jogosList3.Add(jogos3);
                            break;
                        case 4:
                            Jogos jogos4 = new Jogos();
                            jogos4.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                            jogos4.Cod_time1 = Convert.ToInt32(item["cod_time1"]);
                            jogos4.Cod_time2 = Convert.ToInt32(item["cod_time2"]);
                            jogos4.Campeonatos = item["dsc_camp"].ToString();
                            jogos4.Data = Convert.ToDateTime(item["data"]);
                            jogos4.Time1 = item["time1"].ToString();
                            jogos4.Time2 = item["time2"].ToString();
                            jogos4.Resultado = Convert.ToInt32(item["resultado"]);
                            jogosList3.Add(jogos4);
                            break;
                        case 5:
                            Jogos jogos5 = new Jogos();
                            jogos5.Cod_camp = Convert.ToInt32(item["cod_camp"]);
                            jogos5.Cod_time1 = Convert.ToInt32(item["cod_time1"]);
                            jogos5.Cod_time2 = Convert.ToInt32(item["cod_time2"]);
                            jogos5.Campeonatos = item["dsc_camp"].ToString();
                            jogos5.Data = Convert.ToDateTime(item["data"]);
                            jogos5.Time1 = item["time1"].ToString();
                            jogos5.Time2 = item["time2"].ToString();
                            jogos5.Resultado = Convert.ToInt32(item["resultado"]);
                            jogosList3.Add(jogos5);
                            break;
                    }

                }
            }
            conn.Close();

            jogosList.Add(jogosList1);
            jogosList.Add(jogosList2);
            jogosList.Add(jogosList3);
            jogosList.Add(jogosList4);
            jogosList.Add(jogosList5);
            return jogosList;
        }

        public IEnumerable<Jogos> GetTimeCampeonato(int codCamp, int codTime, int resultado)
        {
            List<Jogos> jogosList = new List<Jogos>();
            cmd = new SqlCommand($"select j.cod_camp, j.cod_time1,j.cod_time2, j.cod_estadio, j.data, j.resultado, c.dsc_camp, t1.nom_time, t2.nom_time, e.nom_est from jogos as j inner join campeonatos c on c.cod_camp = j.cod_camp inner join times as t1 on j.cod_time1 = t1.cod_time inner join times AS t2 on j.cod_time2 = t2.cod_time inner join estadios as e on j.cod_estadio = e.cod_est where (j.cod_time1 = {codTime} OR j.cod_time2 = {codTime}) AND j.cod_camp = {codCamp} and resultado = {resultado}", conn);
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
    }
}
