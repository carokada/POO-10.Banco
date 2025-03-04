using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class SavingsAccount : Account
   {
      private decimal monthlyInterestRate; // deberia ser estatico por uml o particular a cada cuenta ?

      public SavingsAccount(int number, decimal balance, decimal monthlyInterestRate) : base(number, balance)
      {
         MonthlyInterestRate = monthlyInterestRate;
      }

      public decimal MonthlyInterestRate
      {
         get => monthlyInterestRate;
         set => monthlyInterestRate = value >= 0 ? value : throw new ArgumentException(" el monto de interes mensual no puede ser menor a cero.");
      }

      public void DepositMonthlyInterest()
      {
         Deposit(Balance * MonthlyInterestRate / 100);
      }

      public override string ToString()
      {
         return $" [savings account] {base.ToString()}";
      }
   }
}
