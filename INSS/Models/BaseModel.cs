using System.Data;
using System.Linq;

namespace INSS.Models
{
    public abstract class BaseModel
    {
        public BaseModel(DataRow row)
        {
            var props = GetType().GetProperties();
            foreach (DataColumn column in row.Table.Columns)
            {
                var prop = props.FirstOrDefault(p => p.Name == column.Caption);
                try
                {
                    prop?.SetValue(this, row[column.Caption]);
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
