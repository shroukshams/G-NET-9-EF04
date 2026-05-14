using G_NET_9_EF04.enums;
using G_NET_9_EF04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace G_NET_9_EF04
{
    internal class Functions
    {
        public void AddCustomer()
        {

            Console.WriteLine("Add New Customer----");


            using (var context = new ApplicationDbContext())
            {
                var customers = new Customer();
                Console.WriteLine("FullName:  ");

                customers.FullName = Console.ReadLine();
                Console.WriteLine("PhoneNumber  :   ");
                customers.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Email  :   ");
                customers.Email = Console.ReadLine();
                Console.WriteLine("DateOfBirth  :   ");
                customers.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Address  :   ");
                customers.Address = Console.ReadLine();

                Console.WriteLine("NationalityId  :   ");
                customers.NationalityId = Convert.ToInt32(Console.ReadLine());
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


        }

        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////

        public void OpenAccountForCustomer()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.WriteLine("\n--- Open New Account for Customer ---");
                int accountNumber, branchCode, customerId;
                string ownershipRole, accountType;

                Console.Write("Account Number: ");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                if (string.IsNullOrWhiteSpace(Convert.ToString(accountNumber))) { Console.WriteLine("Account Number cannot be empty."); return; }

                Console.Write("Account Type (e.g., Savings, Checking): ");
                accountType = Console.ReadLine();

                Console.Write("Branch Code: ");
                branchCode = Convert.ToInt32(Console.ReadLine());
                var branch = context.Branches.FirstOrDefault(b => b.Code == branchCode);
                //if (branch == null) { Console.WriteLine("Branch not found."); return; }

                Console.Write("Customer ID: ");
                customerId = Convert.ToInt32(Console.ReadLine());
                var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
                //if (customer == null) { Console.WriteLine("Customer not found."); return; }

                Console.Write("Ownership Role (Primary/CoHolder): ");
                ownershipRole = Console.ReadLine();
                if (!("Primary".Equals(ownershipRole, StringComparison.OrdinalIgnoreCase) || "CoHolder".Equals(ownershipRole, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Invalid Ownership Role. Must be Primary or CoHolder.");
                    return;
                }

                var account = new Account
                {
                    // AccountNumber = accountNumber,
                    Balance = 0.00m, // New accounts start with 0 balance
                    AccountType = accountType,
                    OpenDate = DateTime.Now,
                    BranchId = branchCode
                };

                context.Accounts.Add(account);

                var customerAccount = new AccountCustomer
                {
                    CustomerId = customerId,
                    AccountId = accountNumber,
                    OwnershipType = ownershipRole,
                    OwnerStartDate = DateTime.Now,
                    AccountStuatus = "Active"
                };

                context.CustomerAccounts.Add(customerAccount);
                context.SaveChanges();
                Console.WriteLine($"Account {accountNumber} opened for customer {customer.FullName} successfully!");
            }
        }

        ///////////////
        public void UpdateAccountStatus()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.WriteLine("\n--- Update Account Status ---");
                int accountId, customerId;

                Console.Write("Account ID (integer): ");
                if (!int.TryParse(Console.ReadLine(), out accountId)) { Console.WriteLine("Invalid Account ID."); return; }

                Console.Write("Customer ID (integer): ");
                if (!int.TryParse(Console.ReadLine(), out customerId)) { Console.WriteLine("Invalid Customer ID."); return; }

                var accountCustomer = context.CustomerAccounts
                    .FirstOrDefault(ca => ca.AccountId == accountId && ca.CustomerId == customerId);

                if (accountCustomer == null)
                {
                    Console.WriteLine("Customer-Account relationship not found.");
                    return;
                }
                Console.WriteLine($"Current status for Account {accountId} (Customer {customerId}): {accountCustomer.AccountStuatus}");
                Console.Write("Enter new status (e.g., Active, Inactive, Closed): ");
                string newStatus = Console.ReadLine();

                accountCustomer.AccountStuatus = newStatus;
                context.SaveChanges();
                Console.WriteLine("Account status updated successfully!");
            }
        }
        public void RemoveAccountFromCustomer()
        {
            using (var context = new ApplicationDbContext())
            {
                Console.WriteLine("\n--- Remove Account from Customer ---");
                int accountId, customerId;

                Console.Write("Account ID (integer): ");
                if (!int.TryParse(Console.ReadLine(), out accountId)) { Console.WriteLine("Invalid Account ID."); return; }

                Console.Write("Customer ID (integer): ");
                if (!int.TryParse(Console.ReadLine(), out customerId)) { Console.WriteLine("Invalid Customer ID."); return; }

                var accountCustomer = context.CustomerAccounts
                    .FirstOrDefault(ca => ca.AccountId == accountId && ca.CustomerId == customerId);

                if (accountCustomer == null)
                {
                    Console.WriteLine("Customer-Account relationship not found.");
                    return;
                }

                context.CustomerAccounts.Remove(accountCustomer);
                context.SaveChanges();
                Console.WriteLine("Account removed from customer successfully!");
            }

        }




    }
}
    



























