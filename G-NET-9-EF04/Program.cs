using G_NET_9_EF04;
using G_NET_9_EF04.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Identity.Client;
using System.Net;
using System.Threading.Tasks.Dataflow;
using G_NET_9_EF04.enums;


namespace G_NET_9_EF04
{
    internal class Program
    {


        static void Main(string[] args)
        {
            bool runing = true;
            while (runing)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("Welcome to the Bank Management System");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Add a new Customer");
                Console.WriteLine("2. Open a new Account for a Customer");
                Console.WriteLine("3.UpdatE Account status (active/inactive)");
                Console.WriteLine("4.Remove An Account from a Customer");
                Console.WriteLine("5. Display all Customers and their Accounts");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=====================================");
                Console.Write("Please select an option: ");


                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                       AddCustomer();

                        break;
                    case "2":
                    //.openAccount();
                    case "3":
                        //pdateAccountStatus();
                        break;
                    case "4":
                    // RemoveAccoting();
                    case "5":
                     

                        break;
                    case "0":
                        runing = false;
                        Console.WriteLine("Exiting the application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }








            }
        }


        static void AddCustomer()
        {

            Console.WriteLine("Add New Customer----");


                using (var context = new ApplicationDbContext())
            {
                var customers = new Customer();
                Console.WriteLine("FullName:  ");

                customers.FullName = Console.ReadLine();
                Console.WriteLine("PhoneNumber  :   ");
                customers.PhoneNumber =Console.ReadLine();
                Console.WriteLine("Email  :   ");
                customers.Email= Console.ReadLine();
                Console.WriteLine("DateOfBirth  :   ");
                customers.DateOfBirth=Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Address  :   ");
                customers.Address= Console.ReadLine();

                Console.WriteLine("NationalityId  :   ");
                customers.NationalityId=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("CustomerType  :Iidividual/Business  ");
                if (Enum.TryParse(Console.ReadLine(), out CustomerType customerType))
                {
                    customers.CustomerType = customerType.ToString();
                }
                else
                {
                    Console.WriteLine("Invalid Customer Type. Please enter 'Individual' or 'Business'.");
                    return;
                }
                customers.CustomerType = Console.ReadLine();
                context.Customers.Add(customers);
                context.SaveChanges();
 
            }


        } }
  
    }
