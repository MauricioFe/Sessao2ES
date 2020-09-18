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
            GetTabelaCampeonatos();
        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        public void Add(Campeonatos campeonatos)
        {
            cmd = new SqlCommand($"insert into campeonatos values ( {campeonatos.Cod_camp},  '{campeonatos.Descricao}',  {campeonatos.Ano}, '{campeonatos.Tipo}', '{campeonatos.DataInicio}', '{campeonatos.DataFim}', '{campeonatos.Def_tipo}')", conn);
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
                campeonatos.Descricao = item[1].ToString();
                campeonatos.Ano = Convert.ToInt32(item[2]);
                campeonatos.Tipo = item[3].ToString();
                campeonatos.DataInicio = item[4].ToString();
                campeonatos.DataFim = item[5].ToString();
                campeonatos.Def_tipo = item[6].ToString();
                campeonatosList.Add(campeonatos);
            }
            conn.Close();

            return campeonatosList;
        }

        public bool Remove(int codCampeonato)
        {
            try
            {
                cmd = new SqlCommand($"Delete from Campeonatos where cod_camp ={codCampeonato}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public void Update(Campeonatos campeonatos, int codCampeonato)
        {
            cmd = new SqlCommand($"Update campeonatos set dsc_camp = '{campeonatos.Descricao}',  ano = {campeonatos.Ano}, tipo ='{campeonatos.Tipo}', dat_ini = '{campeonatos.DataInicio}', dat_fim = '{campeonatos.DataFim}', def_tipo = '{campeonatos.Def_tipo}'  where cod_camp ={codCampeonato}", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool ValidaEdicaoData(int codCamp, int Ano, string dataInicio, string dataFim)
        {
            cmd = new SqlCommand($"select * from campeonatos inner join jogos on jogos.cod_camp = campeonatos.cod_camp where campeonatos.cod_camp = {codCamp} and jogos.data not between '{dataInicio}' and '{dataFim}' and DATEPART(YEAR,jogos.data) = {Ano}", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
            return dt.Rows.Count > 0;
        }

        public IEnumerable<Tabela> GetTabelaCampeonatos()
        {
            List<Tabela> tabelaList = new List<Tabela>();
            List<Jogos> jogosList = new List<Jogos>();
            var codCamp = 0;
            var codTime = 0;
            int vitoria = 0;
            int empate = 0;
            int derrota = 0;
            foreach (var item in GetAll())
            {
                codCamp = item.Cod_camp;
                cmd = new SqlCommand("select * From times", conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();
                foreach (DataRow linha in dt.Rows)
                {
                    codTime = Convert.ToInt32(linha[0]);
                    cmd = new SqlCommand($"select jogos.cod_camp, jogos.cod_time1, jogos.cod_time2, jogos.resultado from jogos inner join times as t1 on t1.cod_time = jogos.cod_time1 inner join times as t2 on t2.cod_time = jogos.cod_time2 where jogos.cod_camp = {codCamp} and (jogos.cod_time1 = {codTime} or jogos.cod_time2 = {codTime})", conn);
                    adapter = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    conn.Open();
                    adapter.Fill(dt);
                    conn.Close();
                    foreach (DataRow linhaResultado in dt.Rows)
                    {
                        if (Convert.ToInt32(linhaResultado["resultado"]) == 0)
                        {
                            empate++;
                        }
                        else if (Convert.ToInt32(linhaResultado["resultado"]) == 1 && Convert.ToInt32(linhaResultado["cod_time1"]) == codTime)
                        {
                            vitoria++;
                        }
                        else if (Convert.ToInt32(linhaResultado["resultado"]) == 2 && Convert.ToInt32(linhaResultado["cod_time2"]) == codTime)
                        {
                            vitoria++;
                        }
                        else if (Convert.ToInt32(linhaResultado["resultado"]) == 2 && Convert.ToInt32(linhaResultado["cod_time1"]) == codTime)
                        {
                            derrota++;
                        }
                        else if (Convert.ToInt32(linhaResultado["resultado"]) == 1 && Convert.ToInt32(linhaResultado["cod_time2"]) == codTime)
                        {
                            derrota++;
                        }
                    }
                }
            }
            return tabelaList;

        }
    }
}
