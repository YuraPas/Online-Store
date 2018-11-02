using AutoMapper;
using DTOModel;
using OnlineStoreApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Library1
{

    public class productDAL : OnlineStoreEntities
    {
        readonly IMapper mapper;
        public productDAL()
        {
            var config = new MapperConfiguration(c => c.AddProfiles(typeof(productDAL)));
            mapper = config.CreateMapper();
        }
    
        public List<productDTO> GetAllProducts()
        {
            List<productDTO> products = new List<productDTO>();

            using (OnlineStoreEntities db = new OnlineStoreEntities())
            {
                products = mapper.Map<List<productDTO>>(db.product_id.ToList());
            }
            return products;
        }

        public decimal SummOfGoodsSold()
        {
            decimal summ = 0;

            using (OnlineStoreEntities db = new OnlineStoreEntities())
            {
                List<orderDTO> orders = new List<orderDTO>();

                orders = mapper.Map<List<orderDTO>>(db.C_order_.ToList());
                DateTime now = DateTime.Now;

                foreach (orderDTO order in orders)
                {
                 //   if ((now - order.sell_time).TotalDays < 30)
                      if (now.Month  ==  order.sell_time.Month)

                    {
                        product_id prod = db.product_id
                        .Where(u => u.product_id1 == order.product_id)
                        .FirstOrDefault();
                        productDTO new_prod = mapper.Map<productDTO>(prod);

                        summ += new_prod.price;
                    }
                }//дали розбити .сума куплениї можна прото поточний місяць і з знижкою 3 параметри брати ід продукт ід і знижку і ставити там
            }
            return summ;

        }

    }
}

