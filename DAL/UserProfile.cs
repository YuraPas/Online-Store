using AutoMapper;
using DTOModel;
using OnlineStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace DAL_Library1
=======
namespace DAL
>>>>>>> fa22a9e5bffa87148bd559988dccdc9baee7aaf1
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
