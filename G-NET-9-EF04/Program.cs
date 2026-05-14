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
                Functions funtion = new Functions();
                switch (option)
                {
                    case "1":
                   funtion.AddCustomer();

                        break;
                    case "2":
                        funtion.OpenAccountForCustomer();
                        break;
                    case "3":
                        funtion.UpdateAccountStatus();
                        break;
                    case "4":
                    funtion.RemoveAccountFromCustomer();
                        break;
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


       


        } }
  
    