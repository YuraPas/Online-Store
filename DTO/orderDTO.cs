using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
    //dto class for order table 
    public class orderDTO
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public int product_id { get; set; }
        public DateTime sell_time { get; set; }
    }
}
