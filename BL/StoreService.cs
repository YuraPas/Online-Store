using DAL_Library1;
using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class StoreService
    {
        protected userDAL userDal;

        public StoreService()    
        {
            userDal = new userDAL();
        }
    

        public List<userDTO> GetAllStudent()
        {
            return userDal.GetAllUsers();
        }
    }
}
