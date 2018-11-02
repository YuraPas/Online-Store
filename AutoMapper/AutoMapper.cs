using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreApp;
using AutoMapper;
using DTOModel;
namespace DAL_Library.MappiMapperConfiguration
{
    public static class AutoMapperConfiguration : Profile
    {
        public static void Configure()
            
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<user_id, UserDto>();

            });
        }
    }
}
