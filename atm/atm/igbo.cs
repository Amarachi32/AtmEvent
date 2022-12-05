using System.Text.RegularExpressions;

namespace atm
{
    //base iterface inheritance
    internal partial class IgboLanguage : IatmOperations
    {
        //private string _name;
        //private string _accountNumber;
        private static double _accbal;
        public decimal AcctBal { get; set; }
        public IgboLanguage()
        {
            TakeAction();
            AcctBal = 1000;
        }
        public IgboLanguage(double amount)
        {
            _accbal = amount;


        }
        private static void TakeAction()
        {
        Action:
            Console.Clear();
            Console.WriteLine("\nKedu ihe i choro ime? pia\n\n1. ka i were ego \n\n2. ka itinye ego \n\n3. ka i mata ego ole i nwere \n\n4. ka iwepu ego \n\n5. ka i igbanwe pinu gi\n" +
                "\nPia 0 ka ikwusi");
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
                    Console.WriteLine("\n daalu rinne");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\ntinye nke di mma");
                    goto Action;

            }

        }

        public static void Navigation()
        {
        ToContinue:
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n. pia \n\n1. ime ihe ozo \n\n2. ka i horo asusu ozo\n\n" + "3. ka i puo\n");

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
                    Console.WriteLine("\nDaalu");
                    //Enviroment.FailFast("ggfd");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n o bughi ya.\nPinye key o bula ka ikwusi\n");
                    goto ToContinue;

            }

        }
    }

    //withd
    internal partial class IgboLanguage
    {
        public static void Withdrawal()
        {


        enterAmount:
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nPinye Ego ole o bu:\n");
            string amountString = Console.ReadLine();

            if (!rgx.IsMatch(amountString) && double.TryParse(amountString, out double amount))
            {
                if (amount > _accbal)
                {
                    Console.WriteLine("\n i nwere ego\n\n ga-tinye ego");
                    TakeAction();

                    //return;
                }
                else if (amount < 100)
                {
                    Console.WriteLine("O ga akari 100");
                    goto enterAmount;
                }
                else
                {
                    _accbal -= amount;
                    Console.WriteLine("\nBiko chere...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("Ego gi gara nke oma \n ihe i nweziri bu : {0}", _accbal);
                    Navigation();


                }
            }
            else
            {
                Console.WriteLine("\nO bughi ya\n");
                goto enterAmount;
            }

        }
    }
    //deposit
    internal partial class IgboLanguage
    {
        public static void Deposit()
        {
        deposit:
            Console.WriteLine("Ego ole ka i na-etinye");
            try
            {
                double myDeposit = int.Parse(Console.ReadLine());
                if (myDeposit != null && myDeposit >= 1.0)
                {
                    _accbal += myDeposit;
                    Console.WriteLine("ego gi bu  {0} gara nke oma :  total : {1}", myDeposit, _accbal);
                    Navigation();
                }
                else if (myDeposit <= 1)
                {
                    Console.WriteLine("Oga akari 0");
                    Deposit();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Obughi ya");
                goto deposit;
            }

            //return _accbal;
        }
    }
    //bal
    internal partial class IgboLanguage
    {
        public static void CheckBalance()
        {
            Console.WriteLine($"\nEgo Ole i nwere bu ${_accbal}.");
            Navigation();
        }
    }

    //transfer
    internal partial class IgboLanguage
    {
        public static void Transfer()
        {
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nTinye ego ole i choro iwepu:\n");
            string amount = Console.ReadLine();
            string acctNum;
            string bank;

            if (!rgx.IsMatch(amount) && double.TryParse(amount, out double amt))
            {
                if (_accbal < amt)
                {
                    Console.WriteLine("\n I nwere Ego\n");
                    return;
                }
                else if (amt < 100)
                {
                    Console.WriteLine("o zughi 100");
                    return;
                }
                else
                {
                    _accbal -= amt;
                    Console.WriteLine("\nTinye Ego\n");
                    acctNum = Console.ReadLine();

                    if (!rgx.IsMatch(acctNum) && acctNum.Length == 10)
                    {
                        Console.WriteLine("\nSelect bank\n\n1. Zenith Bank\n2. Access Bank\n3. Wema Bank\n4. gen Bank\n");
                        bank = Console.ReadLine();

                        if (bank == "1" || bank == "2" || bank == "3" || bank == "4")
                        {
                            Console.WriteLine("\n Biko Chere\n");
                            Thread.Sleep(1000);
                            Console.WriteLine("o gara nke oma Pia \n\n1.ka ime ihe ozo \n\n2. ka i horo asusu ozo \n\n3 ka i puo" +
                                "3. To end\n");

                        mbido:
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
                                    Console.WriteLine("\nDaluu");
                                    Environment.Exit(0);
                                    break;
                                default:
                                    Console.WriteLine("\nObughi ya.\n\n");
                                    //break;
                                    goto mbido;
                            }
                        }
                    }
                    else Console.WriteLine("\nOzughi nomba iri");
                }
            }
            Console.WriteLine("\nObughi ya\n");
        }
    }
    //changePin
    internal partial class IgboLanguage
    {
        public static void ChangePin()
        {

        }
    }
}
