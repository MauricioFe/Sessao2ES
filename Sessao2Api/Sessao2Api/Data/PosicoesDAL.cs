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
    public class PosicoesDAL : IPosicoesDAL
    {
        private readonly string _conn;
        SqlConnection conn;
        public PosicoesDAL(IConfiguration config)
        {
            _conn = config.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(_conn);
        }

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapter;
        //public void Add(Posicoes posicoes)
        //{
        //    cmd = new SqlCommand($"insert into posicoes values ( {posicoes.Cod_camp},  '{posicoes.Dsc_camp}',  {posicoes.Ano}, '{posicoes.Tipo}', '{posicoes.Data_ini}', '{posicoes.Data_fim}', {posicoes.Def_tipo} )", conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}

        public IEnumerable<Posicoes> GetAll()
        {
            List<Posicoes> posicoesList = new List<Posicoes>();
            cmd = new SqlCommand("select * from posicoes", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Posicoes posicoes = new Posicoes();
                posicoes.Cod_pos = Convert.ToInt32(item[0]);
                posicoes.Dsc_pos = item[1].ToString();
                posicoesList.Add(posicoes);
            }
            conn.Close();

            return posicoesList;
        }
      

        //public void Remove(int codCampeonato)
        //{
        //    cmd = new SqlCommand($"Delete from Posicoes where cod_camp ={codCampeonato}");
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}

        //public void Update(Posicoes posicoes, int codCampeonato)
        //{
        //    cmd = new SqlCommand($"Update posicoes set dsc_camp = '{posicoes.Dsc_camp}',  ano = {posicoes.Ano}, tipo ='{posicoes.Tipo}', data_ini = '{posicoes.Data_ini}', data_fim = '{posicoes.Data_fim}', def_tipo = {posicoes.Def_tipo}  where cod_camp ={codCampeonato}");
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
    }
}
