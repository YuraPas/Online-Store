using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    public class productDTO
    {
        public int product_id1 { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public decimal price { get; set; }
        public int serial_number { get; set; }
        public string category { get; set; }
    }
}
