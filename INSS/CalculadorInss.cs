using INSS.Repositories;
using System;
using System.Linq;

namespace INSS
{
    public class CalculadorInss : ICalculadorInss
    {
        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            var descontoInssRepository = new DescontoInssRepository();
            var descontosInssModel = descontoInssRepository.ObterDescontoINSS(data.Year);
            var taxaDesconto = descontosInssModel.Aliquotas
                .Where(a => salario <= a.Salario)
                .OrderBy(a => a.Salario)
                .FirstOrDefault()?.Desconto;
            if (taxaDesconto == null)
                return descontosInssModel.Teto;
            return salario * taxaDesconto.Value / 100;
        }
    }
}
