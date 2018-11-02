using AutoMapper;
using DTOModel;
using OnlineStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<userDTO, user_id>().ReverseMap();
            CreateMap<productDTO, product_id>().ReverseMap();
            CreateMap<orderDTO, C_order_>().ReverseMap();
            CreateMap<discountDTO, discount>().ReverseMap();


        }
    }
}
