namespace ATM
{
    public class Numbersgame
    {
        public static decimal Balance;

        static void Main(string[] args)
        {
            UserInterface();
        }
        public static void UserInterface()
        {
            bool menuSelect = true;
            
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("Please Select an Option to Continue...\n");

            while (menuSelect)
            {
                int input;
                
                Console.WriteLine("1: View Balance\r\n2. Withdraw Money\r\n3. Deposit Money\r\n4. Exit ATM");
                Console.Write("> ");
                
                bool success = int.TryParse(Console.ReadLine(), out input);

                if (success)
                    menuSelect = HandleMenu(input);
                else
                    Console.WriteLine("Invalid Input");
            }
        }
        public static bool HandleMenu(int input)
        {
            bool menuSelect = true;
            decimal result = 0.0M;
            decimal amount = 0.0M;

            switch (input)
            {
                case 1:
                    result = ViewBalance();
                    Console.WriteLine("\nYour balance is $" + result + "\n");
                    return menuSelect;
                case 2:
                    Console.WriteLine("How much would you like to Withdraw?");
                    amount = Convert.ToDecimal(Console.ReadLine());
                    result = Withdraw(amount);
                    Console.WriteLine("\nMoney has been withdrawn..");
                    Console.WriteLine("$" + result + "\n");
                    return menuSelect;
                case 3:
                    Console.WriteLine("\nHow much would you like to Deposit?");
                    amount = Convert.ToDecimal(Console.ReadLine());
                    result = Deposit(amount);
                    Console.WriteLine("Deposited");
                    Console.WriteLine("$" + result + "\n");
                    return menuSelect;
                case 4:
                    menuSelect = false;
                    return menuSelect;
                default:
                    return false;
            }
        }
        public static decimal ViewBalance()
        {
            return Balance;
        }
        public static decimal Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new Exception("Your amount is greater than the Balance");
            }
            else if (amount == 0)
            {
                throw new Exception("You can't subtract 0...");
            }
            else if (Balance == 0)
            {
                throw new Exception("Your Balance is zero, please deposit before withdrawing...");
            }
            else
            {
                Balance -= amount;
            }

            return Balance;
        }
        public static decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception("You can't deposit a negative amount of money");
            }
            else
            {
                Balance += amount;
            }

            return Balance;
        }
    }
}