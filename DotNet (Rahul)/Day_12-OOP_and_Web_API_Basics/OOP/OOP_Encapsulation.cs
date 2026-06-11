using System;

namespace Day_12_OOP_and_Web_API_Basics
{
    internal class OOP_Encapsulation
    {
        public class Bank
        {
            public string Name { get; set; }
            private int _amount { get; set; }
            public int Deposit
            {
                get { return _amount; }
                set
                {
                    if (value > 1000) _amount = value;
                    else
                        Console.WriteLine("Must deposit greater then 1000 amount.");
                }
            }
            public int WithDraw
            {
                get { return _amount; }
                set
                {
                    if (value > 100)
                        _amount -= value;
                    else
                        Console.WriteLine("Must withdrawable amount is greater then 100.");
                }
            }
            public string DisplayDeposit()
            {
                return $"After deposite your total amount is {Deposit}";
            }
            public string AllDetails()
            {
                return $"Your total amout is {_amount} and your bank account name is {Name}";
            }

        }

        public static void run()
        {
            Bank newAccount = new Bank();
            newAccount.Name = "Rajvir";
            newAccount.Deposit = 10000;
            
            Console.WriteLine(newAccount.DisplayDeposit());
            newAccount.WithDraw = 10;
            Console.WriteLine(newAccount.AllDetails());
        }
    }
}
