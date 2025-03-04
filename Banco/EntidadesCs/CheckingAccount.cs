using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class CheckingAccount : Account
   {
      public decimal OverdraftAmount { get; set; }

      public CheckingAccount(int numero, decimal balance, decimal overdraftAmount) : base(numero, balance)
      {
         OverdraftAmount = overdraftAmount;
      }

      public override void Withdraw(decimal egreso)
      {
         if (DineroEnCuenta - egreso <= -OverdraftAmount)
            throw new ArgumentException(" no hay fondos suficientes para realizar esta operacion.");
         CambiarBalance(-egreso);
      }

      public override string ToString()
      {
         return $" [checking account] {base.ToString()}";
      }
   }
}
