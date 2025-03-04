using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public static class Bank
   {
      private static List<Customer> customers = new List<Customer>();

      public static int CustomerCounter { get; private set; }

      public static void AddCustomer(Customer customer)
      {
         if (customer == null)
            throw new ArgumentException(" la customer no puede estar vacia.");
         if (customers.Contains(customer))
            throw new ArgumentException($" la customer ya ha sido agregada a la lista.");
         customers.Add(customer);
      }

      public static void RemoveCustomer(Customer customer)
      {
         if (customer == null)
            throw new ArgumentException(" la customer no puede estar vacia.");
         if (!customers.Contains(customer))
            throw new ArgumentException($" la customer ya ha sido agregada a la lista.");
         customers.Remove(customer);
      }

      public static List<Customer> GetCustomers()
      {
         return customers;
      }

      public static List<Customer> GetCustomers(string name)
      {
         List<Customer> customerSearch = new List<Customer>();

         foreach (var customer in customers)
         {
            if (customer.Name.Contains(name))
               customerSearch.Add(customer);
         }
         return customerSearch;
      }

      public static Customer GetCustomer(int id)
      {
         foreach (var customer in customers)
         {
            if (customer.Id == id)
               return customer;
         }
         Console.WriteLine(" no se encontraron coincidencias.");
         return null;
      }
   }
}
