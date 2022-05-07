using System.Collections.Generic;
using System.Data;

namespace INSS.Models
{
    public class DescontosInss : BaseModel
    {
        public DescontosInss(DataRow row) : base(row) 
        {
            Aliquotas = new List<Aliquota>();
        }

        public int Ano { get; set; }
        public decimal Teto { get; set; }
        public IList<Aliquota> Aliquotas { get; set; }
    }
}
