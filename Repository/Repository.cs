using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository : IRepository
    {
        public IEnumerable<string> MyValues { get; set; }

        public Repository()
        {
            MyValues = new List<string> { "Value1", "Value2", "Value3", "Value4" };
        }
    }
}
