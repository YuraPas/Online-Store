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
 //  public interface iDisposable
//{
  //  
   //  public void Dispose()
    //    {
    //        throw new NotImplementedException();

    public class userDAL : OnlineStoreEntities
    {
        readonly IMapper mapper;
        public userDAL()
        {
            var config = new MapperConfiguration(c => c.AddProfiles(typeof(userDAL)));
            mapper = config.CreateMapper();
        }
       
        public void SetDiscountForUser(int Id,int productId,int discount)
        {

            using (OnlineStoreEntities db = new OnlineStoreEntities())
            {

                discountDTO add = new discountDTO
                {
                    id = Id,
                    product_id = productId,
                    discount1 = discount
                };
                db.discounts.Add(mapper.Map<discount>(add));
                db.SaveChanges();
            }

        }

        public List<userDTO> GetAllUsers()
        {
            List<userDTO> users = new List<userDTO>();

            using (OnlineStoreEntities db = new OnlineStoreEntities())
            {
                users = mapper.Map<List<userDTO>>(db.user_id.ToList());
                return users;
            }
        }
         
        public userDTO GetUserByID(int Id)
        {
            using (OnlineStoreEntities db = new OnlineStoreEntities())
            {
                user_id target = db.user_id
                    .Where(u => u.id == Id)
                    .FirstOrDefault();

                return mapper.Map<userDTO>(target);
            }
        }

   
        public void AddUser(userDTO user)
        {

            using (var db = new OnlineStoreEntities())
            {
                user_id target = mapper.Map<user_id>(user);
                db.user_id.Add(target);
                db.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (OnlineStoreEntities db = new OnlineStoreEntities())
            {
                //db.user_id.Attach(user);
                // db.user_id.Remove(user);   
                user_id target = db.user_id
                    .Where(u => u.id == id)
                    .FirstOrDefault();
                db.Entry(target).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public int UpdateUser(userDTO user)
        {
            using (OnlineStoreEntities db = new OnlineStoreEntities())
            {
                user_id target =db.user_id
                    .Where(u => u.id == user.id)
                    .FirstOrDefault();
                //target = mapper.Map<user_id>(user);
                target.user_name = user.user_name;
                target.first_Name = user.first_Name;
                target.last_Name = user.last_Name;
                target.address = user.address;

                db.SaveChanges();
                return target.id;

            }
        }
    }
}

