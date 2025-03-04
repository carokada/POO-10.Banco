using System;

namespace EntidadesCs
{
   public abstract class Account
   {
      public Customer Customer { get; set; }

      internal decimal DineroEnCuenta = 0;
      private int number;
      public decimal Balance { get => DineroEnCuenta; }
      public bool Enabled { get; private set; }

      public Account()
      {
         Enabled = true;
      }

      public Account(int number, decimal balance) : this()
      {
         Number = number;
         DineroEnCuenta = balance;
      }

      public int Number
      {
         get => number;
         set => number = value >= 0 ? value : throw new ArgumentException(" el numero no puede ser menor a cero.");
      }

      public void DarDeBaja()
      {
         Enabled = false;
      }

      public void Deposit(decimal ingreso)
      {
         CambiarBalance(ingreso);
      }

      public virtual void Withdraw(decimal egreso)
      {
         if (Balance < 0 || Balance < egreso)
         {
            throw new ArgumentException(" no hay fondos suficientes para realizar esta operacion.");
         }
         CambiarBalance(-egreso);
      }

      internal void CambiarBalance(decimal value)
      {
         DineroEnCuenta += value;
      }

      public override string ToString()
      {
         return $" numero de cuenta: {number} {(!Enabled ? "(Suspendida)" : "")} \t balance: {Balance}";
      }
   }
}
