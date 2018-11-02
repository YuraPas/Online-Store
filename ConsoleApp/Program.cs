
using DTOModel;
using OnlineStoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Роль Маркетолог – логується, попадає на стартову сторінку з можливістю перейти на сторінку своєї ролі за допомогою меню.
//Доступний перехід на сторінку з відображенням списку користувачів та суми куплених товарів протягом деякого часу (місяця).
//Може виконувати пошук та сортування.
//Може встановити знижку для користувача. Може розлогуватися. Реалізувати названий функціонал.


namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {


            var userInstance = new DAL_Library1.userDAL();
            var prodInstance = new DAL_Library1.productDAL();

            bool stop = false;

          
            while (!stop)
            {
                Console.WriteLine("Enter 1 to Get All Users" + "\t" + "Enter 2 to Update User");
                Console.WriteLine("Enter 3 to  Delete User" + "\t        " + "Enter 4 to Add User");
                Console.WriteLine("Enter 5 to Sum of Goods sold for a month" + "\t" + "Enter 6 to Get all products");
                Console.WriteLine("Enter 7 to Set discount for User");

                Console.WriteLine("Enter 0 to Exit");
                Console.WriteLine();
                try
                {
                    int Case = int.Parse(Console.ReadLine());

                
                

                Console.WriteLine();
                switch (Case)
                {
                    case 1:
                        List<userDTO> data = userInstance.GetAllUsers();
                        Program.PrintAllUsers(data);
                        break;

                    case 2:
                        Console.WriteLine("Enter id of user you want to update");

                        int Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter username,firstname and last name separated via comma");
                        string line = Console.ReadLine();
                        string[] credential = line.Split(',');

                        userDTO upd = new userDTO
                        {
                            id = Id,
                            user_name = credential[0],
                            first_Name = credential[1],
                            last_Name = credential[2],

                        };
                        int IDmodified = userInstance.UpdateUser(upd);
                        Console.WriteLine("Folowing user updated");
                        userDTO mod = userInstance.GetUserByID(IDmodified);
                        Program.PrintSingleUser(mod);
                        break;

                    case 3:
                        Console.WriteLine("Enter id of user you want to delete");

                        int Id1 = int.Parse(Console.ReadLine());
                        userInstance.DeleteUser(Id1);

                        break;

                    case 4:
                        Random rnd = new Random();

                        userDTO add = new userDTO
                        {
                            //id = rnd.Next(10, 50),
                            first_Name = "new first",
                            last_Name = "new Last",
                            address = "new address",
                            user_name = "new username",
                            password = "new123456",
                        };
                        userInstance.AddUser(add);
                       // Console.WriteLine("folowing user added:");
                        //instance.PrintSingleUser(add);

                        break;
                    case 5:
                        Console.WriteLine(prodInstance.SummOfGoodsSold());
                        break;

                    case 6:
                        List<productDTO> prodList = prodInstance.GetAllProducts();
                        Program.PrintAllProducts(prodList);
                        
                        
                        break;
                    case 7:
                        Console.WriteLine("Enter user id ");
                        int userId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter product id ");
                        int productId = int.Parse(Console.ReadLine());

                         Console.WriteLine("Enter the amount of discount ");
                         int discAmount = int.Parse(Console.ReadLine());
                         userInstance.SetDiscountForUser(userId, productId, discAmount);
                        break;
                    case 0:
                        stop = true;
                        break;
                }
            }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);

                }
            }

        }

        static void PrintSingleUser(userDTO user)
        {
            if (user.address == null)
            {
                user.address = "none";
                Console.WriteLine(user.id + "\t" + user.user_name + "\t" + user.first_Name + "\t" + user.last_Name + "\t" + user.address);
            }
            else
            {
                Console.WriteLine(user.id + "\t" + user.user_name + "\t" + user.first_Name + "\t" + user.last_Name + "\t" + user.address);
            }

        }

        static void PrintAllProducts(List<productDTO> users)
        {
            foreach (productDTO item in users)
            {

                Console.WriteLine(item.product_id1 + "\t" + item.price + "\t" + item.name + "\t" + item.details + "\t" + item.category);

            }

        }

        static void PrintAllUsers(List<userDTO> users) 
        {
            foreach (userDTO item in users)
            {
                if (item.address == null)
                {
                    item.address = "none";
                    Console.WriteLine(item.id + "\t" + item.user_name + "\t" + item.first_Name + "\t" + item.last_Name + "\t" + item.address);
                }
                else
                {
                    Console.WriteLine(item.id + "\t" + item.user_name + "\t" + item.first_Name + "\t" + item.last_Name + "\t" + item.address);
                }

            }

        }
    }
}

