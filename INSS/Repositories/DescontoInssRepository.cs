using INSS.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace INSS.Repositories
{
    public class DescontoInssRepository : BaseRepository
    {       
        public List<Aliquota> ObterAliquotas(int? ano = null)
        {
            var sql = "SELECT Ano, Salario, Desconto FROM Aliquota";
            if (ano != null)
                sql += $" WHERE Ano = {ano}";
            var tableAliquotas = new DataTable();
            using (var connection = ObterConexao())
            {
                using (var dataAdapter = new SqlDataAdapter(sql, connection))
                {
                    dataAdapter.Fill(tableAliquotas);
                }
            }
            var aliquotas = new List<Aliquota>();
            foreach (DataRow row in tableAliquotas.Rows)
            {
                aliquotas.Add(new Aliquota(row));
            }
            return aliquotas;
        }

        public DescontosInss ObterDescontoINSS(int ano)
        {
            var sql = $"SELECT Ano, Teto FROM TetoDesconto WHERE Ano = {ano}";
            var tableDescontos = new DataTable();
            using (var connection = ObterConexao())
            {
                using (var dataAdapter = new SqlDataAdapter(sql, connection))
                {
                    int linhasAfetadas = dataAdapter.Fill(tableDescontos);
                    if (linhasAfetadas <= 0)
                        return null;
                }
            }
            var descontos = new DescontosInss(tableDescontos.Rows.Cast<DataRow>().FirstOrDefault());
            descontos.Aliquotas = ObterAliquotas(ano);
            return descontos;
        }

        public decimal? ObterTaxaDesconto(int ano, decimal salario)
        {
            var descontosInssModel = ObterDescontoINSS(ano);
            return descontosInssModel.Aliquotas
                .Where(a => salario <= a.Salario)
                .OrderBy(a => a.Salario)
                .FirstOrDefault()?.Desconto;            
        }
    }
}