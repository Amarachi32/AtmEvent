using System.IO;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace atm
{
    //base iterface inheritance
    internal partial class EnglishLanguage : IatmOperations
    {
        private readonly Customers customer;
        public EnglishLanguage(Customers customer)
        {
            this.customer = customer;
            customer.BalancedChanged += Alert.AlertBalanceChanged;
        }

        private static decimal _balance;
        public static decimal Balance
        { get; set; }
        public EnglishLanguage()
        {
            TakeAction();
            Balance = 1000;
        }
       public EnglishLanguage(decimal amount)
        {
            Balance = amount;

        }
        public static void TakeAction()
        {
        Action:
            Console.Clear();//also down
            Console.WriteLine("\nWhat would you like to do? Press\n\n1. For withdrawal\n\n2. For Deposit\n\n3. To check Balance\n\n4. To Transfer\n\n5. To change Pin\n" +
                "\nPress 0 to cancel");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Withdrawal();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    CheckBalance();
                    break;
                case "4":
                    Transfer();
                    break;
                case "5":
                    ChangePin();
                    break;
                case "0":
                    Console.WriteLine("\nSee you some other time");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nINVALID OPTION");
                    goto Action;

            }

        }

        public static void Navigation()
        {
        ToContinue:
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n. Press\n\n1. continue transaction \n\n2. To chose another Language\n\n" + "3. To logout\n");

            string nextSteps = Console.ReadLine();

            switch (nextSteps)
            {
                case "1":
                    TakeAction();
                    break;
                case "2":
                    EsteemedCustomer LangEnter = new();
                    LangEnter.SelectLanguage();
                    break;
                case "3":
                    EsteemedCustomer reEnter = new();
                    reEnter.CutomerDetails();
                    break;
                case "4":
                    Console.WriteLine("\nThank you. See you");
                    //Enviroment.FailFast("ggfd");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nINVALID INPUT.\nPress any key to end operation\n");
                    goto ToContinue;

            }

        }
    }

    //withd
    internal partial class EnglishLanguage
    {
        public static void Withdrawal()
        {
            enterAmount:
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nEnter amount below:\n");
            string amountString = Console.ReadLine();

            if (!rgx.IsMatch(amountString) && decimal.TryParse(amountString, out decimal amount))
            {
                if (amount > Balance)
                {
                    Console.WriteLine("\nInsufficient funds\n\n Deposit first");
                    TakeAction();

                    //return;
                }
                else if (amount < 100) 
                {
                    Console.WriteLine("Amount must be up t0 100");
                    goto enterAmount;
                }
                else
                {
                   
                    Balance -= amount;
                    Console.WriteLine("\nPlease wait...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("Withdrwal successful \n your available balance is: {0}", Balance);
                    Navigation();


                }
            }
            else
            {
                Console.WriteLine("\nInvalid amount\n");
                goto enterAmount;
            }

        }
    }
    //deposit
    internal partial class EnglishLanguage
    {
        public static void Deposit()
        {
        deposit:
            Console.WriteLine("enter amount to deposit");
            try
            {
                decimal myDeposit = int.Parse(Console.ReadLine());
                if (myDeposit != null && myDeposit >= 1)
                {
                    Balance += myDeposit;
                    Console.WriteLine("Deposit of {0} is successful :  total : {1}", myDeposit, Balance);
                    Navigation();
                }
                else if (myDeposit <= 1)
                {
                    Console.WriteLine("must be greater than 0 digit");
                    Deposit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid amount");
                goto deposit;
            }

            //return _accbal;
        }
    }
    //bal
    internal partial class EnglishLanguage
    {
        public static void CheckBalance()
        {
            Console.WriteLine($"\nYour account balance is ${Balance}.");
            Navigation();
        }
    }

    //transfer
    internal partial class EnglishLanguage
    {
        public static void Transfer()
        {
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nEnter amount below:\n");
            string amount = Console.ReadLine();
            string acctNum;
            string bank;

            if (!rgx.IsMatch(amount) && decimal.TryParse(amount, out decimal amt))
            {
                if (Balance < amt)
                {
                    Console.WriteLine("\nInsufficient funds\n");
                    return;
                }
                else if (amt < 100)
                {
                    Console.WriteLine("Amount must be up tp 100");
                    return;
                }
                else
                {
                    Balance -= amt;
                    Console.WriteLine("\nEnter account number\n");
                    acctNum = Console.ReadLine();

                    if (!rgx.IsMatch(acctNum) && acctNum.Length == 10)
                    {
                        Console.WriteLine("\nSelect bank\n\n1. Zenith Bank\n2. Access Bank\n3. Wema Bank\n4. AchA Bank\n");
                        bank = Console.ReadLine();

                        if (bank == "1" || bank == "2" || bank == "3" || bank == "4")
                        {
                            Console.WriteLine("\nPlease wait\n");
                            Thread.Sleep(1000);
                            Console.WriteLine("Transaction successful. Press\n\n1. To print receipt\n\n2. To return to previous menu\n\n" +
                                "3. To end\n");
                            Navigation();

                        }
                    }
                    else Console.WriteLine("\nAccount number must be a 10-digit number");
                }
            }
            Console.WriteLine("\nInvalid amount\n");
        }
    }
    //changePin
    internal partial class EnglishLanguage
    {
        //subscriber
        public static void ChangePin()
        {

            foreach (Customers customer in Customers.PinBox)
                customer.PinChanged += Alert.AlertPinChanged;

            Console.WriteLine("enter your Old Pin");
            int oldPin = Convert.ToInt32(Console.ReadLine());

            var IndexToEdit = Customers.PinBox.FindIndex(pass => pass.Pin == oldPin);
            Console.WriteLine("enter your new Pin");
            Customers.PinBox[IndexToEdit].Pin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} has been edited", IndexToEdit);

        }
    }
}


