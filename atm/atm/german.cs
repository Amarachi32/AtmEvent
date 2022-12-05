using System.Text.RegularExpressions;

namespace atm
{
    internal partial class GermanLanguage : IatmOperations
    {
        private static double _accbal;
        public decimal AcctBal { get; set; }
        public GermanLanguage()
        {
            TakeAction();
            AcctBal = 1000;
        }
        public GermanLanguage(double amount)
        {
            _accbal = amount;


        }
        private static void TakeAction()
        {
        Action:
            Console.Clear();
            Console.WriteLine("\nWÄHLE EINE OPTION?  drücken\n\n1. abheben \n\n2. Hinterlegung \n\n3. Kontostand prüfen \n\n4. Transfer \n\n" +
                "\n 0 abbrechen");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Withdrawal();
                    break;
                case "2":
                    Deposit();
                    //Deposit();
                    break;
                case "3":
                    CheckBalance();
                    break;
                case "4":
                    Transfer();
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
    internal partial class GermanLanguage
    {
        static void CheckBalance()
        {
            Console.WriteLine($"Ihr Kontostand beträgt ${_accbal}.\nDrücken Sie\n\n1. Quittung drucken\n\n2. Um zum vorherigen Menü zurückzukehren" +
                $"\n\n3. Beenden\n");

            string nextSteps = Console.ReadLine();

            switch (nextSteps)
            {
                case "1":
                    Console.WriteLine($"\nBalance\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\nTime:{DateTime.Now}" +
                    $"\nAvailBal: ${_accbal}\n");
                    Console.WriteLine("Vielen Dank, dass Sie mit uns Bankgeschäfte tätigen");
                    break;
                case "2":
                    TakeAction();
                    break;
                case "3":
                    Console.WriteLine("\nDanke dir, bis bald");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("UNGÜLTIGE EINGABE.\nDrücken Sie eine beliebige Taste, um den Vorgang zu beenden");
                    break;
            }
        }
    }

    internal partial class GermanLanguage
    {
        static void Transfer()
        {
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nGeben Sie unten den Betrag ein:\n");
            string amount = Console.ReadLine();
            string acctNum;
            string bank;

            if (!rgx.IsMatch(amount) && double.TryParse(amount, out double amt))
            {
                if (_accbal < amt)
                {
                    Console.WriteLine("\nUnzureichende Mittel\n");
                    return;
                }
                else if (amt < 100)
                {
                    Console.WriteLine("Der Betrag muss bis zu 100 betragen");
                    return;
                }
                else
                {
                    _accbal -= amt;
                    Console.WriteLine("\nKontonummer eingeben\n");
                    acctNum = Console.ReadLine();

                    if (!rgx.IsMatch(acctNum) && acctNum.Length == 10)
                    {
                        Console.WriteLine("\nBank auswählen\n\n1. Zenith Bank\n2. Access Bank\n3. Wema Bank\n4. AchA Bank\n");
                        bank = Console.ReadLine();

                        if (bank == "1" || bank == "2" || bank == "3" || bank == "4")
                        {
                            Console.WriteLine("\nWarten Sie mal\n");
                            Thread.Sleep(1000);
                            Console.WriteLine("Transaktion Erfolgreich. Drücken Sie\n\n1. Quittung drucken\n\n2. Um zum vorherigen Menü zurückzukehren" +
                                "\n\n3. Pour finir\nBeenden\n");

                            string nextSteps = Console.ReadLine();

                            switch (nextSteps)
                            {
                                case "1":
                                    Console.WriteLine($"\nDebit\nAmt: ${amt}\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\n" +
                                        $"Time:{DateTime.Now}\nAvailBal: ${_accbal}\n");
                                    Console.WriteLine("Vielen Dank, dass Sie mit uns Bankgeschäfte tätigen");
                                    break;
                                case "2":
                                    TakeAction();
                                    break;
                                case "3":
                                    Console.WriteLine("\nDanke dir, bis bald");
                                    Environment.Exit(0);
                                    break;
                                default:
                                    Console.WriteLine("UNGÜLTIGE EINGABE.\nDrücken Sie eine beliebige Taste, um den Vorgang zu beenden");
                                    break;
                            }
                        }
                    }
                    else Console.WriteLine("\nDie Kontonummer muss eine 10-stellige Zahl sein");
                }
            }
            Console.WriteLine("\nungültige Menge\n");
        }
    }
    partial class GermanLanguage
    {
        static void Withdrawal()
        {
        enterAmount:
            Regex rgx = new Regex("[^0-9]");
            Console.WriteLine("\nGeben Sie unten den Betrag ein:\n");
            string amountString = Console.ReadLine();

            if (!rgx.IsMatch(amountString) && double.TryParse(amountString, out double amount))
            {
                if (amount > _accbal)
                {
                    Console.WriteLine("\nUnzureichende Mittel\n");
                    return;
                }
                else if (amount < 100)
                {
                    Console.WriteLine("Der Betrag muss bis zu 100 betragen");
                    return;
                }
                else
                {
                    _accbal -= amount;
                    Console.WriteLine("\nWarten Sie mal...\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("\nNimm dein Bargeld. Drücken Sie\n\n1. Quittung drucken\n\n2. Um zum vorherigen Menü zurückzukehren\n\n" +
                        "3. Beenden\n");

                    string nextSteps = Console.ReadLine();

                    switch (nextSteps)
                    {
                        case "1":
                            Console.WriteLine($"\nDebit\nAmt: ${amount}\nAcc: 002******890\nDesc:000GenesysTechHub/ATM/bezao\nTime:{DateTime.Now}" +
                            $"\nAvailBal: ${_accbal}\n");
                            Console.WriteLine("Vielen Dank, dass Sie mit uns Bankgeschäfte tätigen");
                            break;
                        case "2":
                            TakeAction();
                            break;
                        case "3":
                            Console.WriteLine("\nDanke dir, bis bald");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("UNGÜLTIGE EINGABE.\nDrücken Sie eine beliebige Taste, um den Vorgang zu beenden");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nungültige Menge\n");
                goto enterAmount;
            }
        }
    }
    //deposit

    internal partial class GermanLanguage
    {

        public static void Deposit()
        {
        deposit:
            Console.WriteLine("Geben Sie den Einzahlungsbetrag ein");
            try
            {
                double myDeposit = int.Parse(Console.ReadLine());
                if (myDeposit != null && myDeposit >= 1.0)
                {
                    _accbal += myDeposit;
                    Console.WriteLine("Einzahlung von {0} erfolgreich : insgesamt : {1}", myDeposit, _accbal);
                    Navigation();
                }
                else if (myDeposit <= 1)
                {
                    Console.WriteLine("muss größer als 0 sein");
                    Deposit();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("ungültige Menge");
                goto deposit;
            }

            //return _accbal;
        }

    }

}


