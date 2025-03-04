using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Customer
   {
      private List<Account> cuentas;

      private string name;
      private int id;
      private DateTime birthday;
      public string Nationality { get; set; }

      public Customer()
      {
         cuentas = new List<Account>();

         Nationality = "Argentino";

         // Bank.AddCustomer(this);
      }

      public Customer(string name, int id) : this()
      {
         Name = name;
         Id = id;
      }

      public Customer(string name, int id, DateTime birthday) : this(name, id)
      {
         Birthday = birthday;
      }

      public string Name
      {
         get => name;
         set => name = value.Length > 3 ? value : throw new ArgumentException(" el nombre no puede tener menos de 4 caracteres.");
      }

      public int Id
      {
         get => id;
         set => id = value > 999999 ? value : throw new ArgumentException(" el numero de dni no es valido");
      }

      public DateTime Birthday
      {
         get => birthday;
         set => birthday = value < DateTime.Now ? value : throw new ArgumentException(" la fecha de nacimiento no puede ser mayor a la del sistema.");
      }

      public void AddAccount(Account cuenta)
      {
         if (cuenta == null)
            throw new ArgumentException(" la cuenta no puede estar vacia.");
         if (cuentas.Contains(cuenta))
            throw new ArgumentException($" la cuenta ya ha sido agregada a la lista.");
         cuenta.Customer = this;
         cuentas.Add(cuenta);
      }

      public void RemoveAccount(Account cuenta)
      {
         if (cuenta == null)
            throw new ArgumentException(" la cuenta no puede estar vacia.");
         if (!cuentas.Contains(cuenta))
            throw new ArgumentException($" la cuenta no ha sido agregada a la lista.");
         cuenta.Customer = null;
         cuentas.Remove(cuenta);
      }

      public List<Account> GetAccounts()
      {
         return cuentas;
      }

      public override string ToString()
      {
         return $" cuenta: {Name} \t dni: {Id}";
      }
   }
}
