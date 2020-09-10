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
    public class JogadoresDAL : IJogadoresDAL
    {
        private readonly string _conn;
        SqlConnection conn;
        public JogadoresDAL(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(_conn);

        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        public void Add(Jogadores jogadores)
        {
            cmd = new SqlCommand($"insert into jogadores values ( {jogadores.Cod_jog},  '{jogadores.DataNascimento}',  {jogadores.Salario.ToString().Replace(",", ".")}, {jogadores.Posicao}, '{jogadores.Nome}', {jogadores.Time} )", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public IEnumerable<Jogadores> GetAll()
        {
            List<Jogadores> jogadoresList = new List<Jogadores>();
            cmd = new SqlCommand("select j.cod_jog, j.dat_nasc, j.salario, j.cod_pos, j.nom_jog, j.cod_time, t.nom_time, p.dsc_pos from Jogadores as j inner join Times as t on t.cod_time = j.cod_time inner join posicoes as p on p.cod_pos = j.cod_pos", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Jogadores jogadores = new Jogadores();
                jogadores.Cod_jog = Convert.ToInt32(item[0]);
                jogadores.DataNascimento = item[1].ToString();
                jogadores.Salario = Convert.ToDecimal(item[2]);
                jogadores.Posicao = Convert.ToInt32(item[3]);
                jogadores.Nome = item[4].ToString();
                jogadores.Time = Convert.ToInt32(item[5]);
                jogadores.TimeStr = item[6].ToString();
                jogadores.PosicaoStr = item[7].ToString();
                jogadoresList.Add(jogadores);
            }
            conn.Close();

            return jogadoresList;
        }

        public bool Remove(int codJogadores)
        {
            try
            {
                cmd = new SqlCommand($"Delete from Jogadores where cod_Jog ={codJogadores}", conn);
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

        public void Update(Jogadores jogadores, int codJogadores)
        {
            cmd = new SqlCommand($"Update jogadores set dat_nasc = '{jogadores.DataNascimento}',  salario = {jogadores.Salario.ToString().Replace(",", ".")}, cod_pos = {jogadores.Posicao}, nom_jog = '{jogadores.Nome}', cod_time ={jogadores.Time}  where  cod_Jog ={codJogadores} ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
