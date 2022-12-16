using System;

namespace ATM
{
    public class myCard
    {
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double balance;

        public myCard(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public string getNum()
        {
            return cardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setNum(string newCardNum)
        {
            cardNum = newCardNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }

        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose one of the options");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Your Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(myCard user)
            {
                Console.WriteLine("How much money would you like to deposit: ");
                double deposit = Convert.ToDouble(Console.ReadLine());
                user.setBalance(deposit + user.getBalance());
                Console.WriteLine("Thank you, your new balance is: " + user.getBalance());
            }

            void withdraw(myCard user)
            {
                Console.WriteLine("How much money would you like to withdraw: ");
                double withdrawl = Convert.ToDouble(Console.ReadLine());
                if (user.getBalance() < withdrawl)
                {
                    Console.WriteLine("Insufficient funds, you cannot make this withdrawl.");
                }
                else
                {
                    user.setBalance(user.getBalance() - withdrawl);
                    Console.WriteLine("Thank you, your withdrawl was successful.");
                }
            }

            void balance(myCard user)
            {
                Console.WriteLine("Your balance is: " + user.getBalance());
            }
            //Test users
            List<myCard> cards = new List<myCard>();
            cards.Add(new myCard("4539356385933237", 0183, "Henry", "Olpi", 400.99));
            cards.Add(new myCard("4532824692539192", 6362, "Phile", "Kae", 390.21));
            cards.Add(new myCard("4485694077612659", 6252, "Zaraki", "Kenpachi", 786.10));
            cards.Add(new myCard("4024007133742386", 0173, "Kyourac", "Lilp", 123.98));

            //Start
            Console.WriteLine("Welcome to SecureATM");
            Console.WriteLine("Please enter your credit card number: ");
            string creditCardNum = "";
            myCard user;

            while (true)
            {
                try
                {
                    creditCardNum = Console.ReadLine();
                    //Checks to see if the card details are correct.
                    user = cards.FirstOrDefault(a => a.cardNum == creditCardNum);
                        if (user != null) { break; }
                    else
                    {
                        Console.WriteLine("Card number is not recognised, please try again.");
                    }
                }
                catch { Console.WriteLine("Card number is not recognised, please try again."); }
            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = Convert.ToInt32(Console.ReadLine());
                    if (user.getPin() == userPin) { break; }
                    else
                    {
                        Console.WriteLine("Pin is incorrect, please try again.");
                    }
                }
                catch { Console.WriteLine("Pin is incorrect, please try again."); }
            }

            Console.WriteLine("Welcome " + user.getFirstName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(user); }
                else if (option == 2) { withdraw(user); }
                else if (option == 3) { balance(user); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Thank you, have a nice day :D");
        }
    }
}