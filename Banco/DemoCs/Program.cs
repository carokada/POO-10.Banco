using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCs;

namespace DemoCs
{
   class Program
   {
      static void Main(string[] args)
      {
         string divisor = "----------------------------------------------------------";

         Console.WriteLine(divisor);
         Console.WriteLine(" creando cuentas...");
         SavingsAccount cuenta1 = new SavingsAccount(123456, 10000, 12);
         SavingsAccount cuenta2 = new SavingsAccount(123457, 20000, 15);
         CheckingAccount cuenta3 = new CheckingAccount(123458, 10000, 5000);
         CheckingAccount cuenta4 = new CheckingAccount(123459, 20000, 3000);
         try
         {
            SavingsAccount cuenta5 = new SavingsAccount(-12345, 1000, 15);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            SavingsAccount cuenta5 = new SavingsAccount(12345, 1000, -15);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n mostrando cuentas cargadas: ");
         Console.WriteLine(cuenta1);
         Console.WriteLine(cuenta2);
         Console.WriteLine(cuenta3);
         Console.WriteLine(cuenta4);

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" creando clientes...");
         Customer cliente1 = new Customer
         {
            Name = "Emilia Lopez",
            Id = 303366922,
            Birthday = new DateTime(1986, 6, 30)
         };
         Customer cliente2 = new Customer("Juan Perez", 33123123);
         Customer cliente3 = new Customer("Emilio Lopez", 35922436, new DateTime(1987, 05, 16));
         try
         {
            Customer cliente4 = new Customer("Juana Hidalgo", 31946258, new DateTime(2025, 05, 16));
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n mostrando clientes cargados: ");
         Console.WriteLine(cliente1);
         Console.WriteLine(cliente2);
         Console.WriteLine(cliente3);
         Console.WriteLine("\n agregando cuentas a clientes...");
         cliente1.AddAccount(cuenta1);
         cliente2.AddAccount(cuenta2);
         cliente3.AddAccount(cuenta3);
         cliente3.AddAccount(cuenta4);
         Console.WriteLine(" mostrando cuentas por cliente... \n");
         MostrarCuentasPorCliente(cliente1);
         MostrarCuentasPorCliente(cliente2);
         MostrarCuentasPorCliente(cliente3);

         Console.WriteLine(divisor);
         Console.WriteLine(" realizando transacciones en cuentas... ");
         cuenta1.Deposit(30000);
         cuenta1.DepositMonthlyInterest();
         cuenta2.Withdraw(6000);
         cuenta2.DepositMonthlyInterest();
         cuenta3.Deposit(12000);
         cuenta4.Withdraw(20000);
         cuenta4.DarDeBaja();
         Console.WriteLine(" mostrando cuentas por cliente... \n");
         MostrarCuentasPorCliente(cliente1);
         MostrarCuentasPorCliente(cliente2);
         MostrarCuentasPorCliente(cliente3);

         Console.WriteLine(divisor);
         Console.WriteLine(" pruebas de la clase utilitaria Bank... ");
         Bank.AddCustomer(cliente1);
         Bank.AddCustomer(cliente2);
         Bank.AddCustomer(cliente3);
         MostrarClientesEnBanco();
         BuscarClientes("Lopez");
         Console.WriteLine($"\n buscando cliente por dni: {Bank.GetCustomer(33123123)} \n");


         //Console.WriteLine("");
         //Console.WriteLine();
         Console.WriteLine(divisor);
         Console.WriteLine("\n presione una tecla para salir ");
         Console.ReadKey();
      }

      private static void MostrarCuentasPorCliente(Customer cliente)
      {
         Console.WriteLine($" cuentas de {cliente.Name}");
         foreach (var cuenta in cliente.GetAccounts())
            Console.WriteLine($"\t~ {cuenta}");
         Console.WriteLine();
      }

      private static void MostrarClientesEnBanco()
      {
         Console.WriteLine($" clientes:");
         foreach (var cliente in Bank.GetCustomers())
            Console.WriteLine($"\t~ {cliente}");
         Console.WriteLine();
      }

      private static void BuscarClientes(string busqueda)
      {
         Console.WriteLine($" clientes:");
         foreach (var cliente in Bank.GetCustomers(busqueda))
            Console.WriteLine($"\t~ {cliente}");
         Console.WriteLine();
      }
   }
}
