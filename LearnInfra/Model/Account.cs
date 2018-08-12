using System;
using System.Threading;

namespace LearnInfra.Model
{
	public class Account
	{
		private int balance;
		private object caztonLock = new object();
		private Random random = new Random();

		public Account(int initialBalance) => balance = initialBalance;

		private int Withdraw(int amount)
		{
			if (balance < 0)
			{
				throw new Exception("Not enough balance");
			}

			Monitor.Enter(caztonLock);
			try
			{
				if (balance >= amount)
				{
					Console.WriteLine($"Amount withdrawn {amount}.");
					balance -= amount;
					return balance;
				}
			}
			finally
			{
				Monitor.Exit(caztonLock);
			}
			return 0;
		}

		public void WithdrawRandomly()
		{
			for (int i = 0; i < 20; i++)
			{
				var balance = Withdraw(random.Next(2000, 5000));
				if (balance > 0)
				{
					Console.WriteLine($"Balance Left {balance}.");
				}
				else
				{
					Console.WriteLine($"Balance is {balance}.");
				}
			}
		}
	}
}