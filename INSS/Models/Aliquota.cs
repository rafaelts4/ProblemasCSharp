using System.Data;

namespace INSS.Models
{
    public class Aliquota : BaseModel
    {
        public Aliquota(DataRow row) : base(row) { }

        public int Ano { get; set; }
        public decimal Salario { get; set; }
        public decimal Desconto { get; set; }
    }
}
