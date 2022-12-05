namespace atm
{

    public class Customers


    {
        public event EventHandler? PinChanged;
        public event EventHandler? BalancedChanged;
        public static List<Customers> PinBox = new List<Customers>();
        private int _pin;
        private decimal _balance;
        private string _name;
        public int Pin
        {
            get { return _pin; }
            set
            {
                //any pin change must be notified to the user 
                // attach a handler to send out alert
                if (value != _pin)
                {
                    _pin = value;
                    PinChanged?.Invoke(this, EventArgs.Empty);
                }
            }

        }

        public string Name { get; set; }
        public decimal Balance
        {
            get { return _balance; }

            set
            {
                //any change in balance must be notified to the user 
                if (value != _balance)
                {
                    _balance = value;
                    BalancedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }



        public Customers()
        {

        }
        public Customers(string name, decimal balance)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || balance == 0)
                    throw new ArgumentException("invalid details");

                _balance = balance;
                _name = name;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }

    public class EsteemedCustomer : Customers
    {

        public EsteemedCustomer(string name, decimal balance) : base(name, balance)
        {
            balance = balance;
        }
        public EsteemedCustomer()
        {

        }


        // private int pinNumber;

        public void CutomerDetails()
        {
        enter:


            try
            {
                Console.WriteLine("Please enter first name:");
                Name = Convert.ToString(Console.ReadLine());
                if (string.IsNullOrEmpty(Name))
                {
                    Console.WriteLine("your name is required");
                    goto enter;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto enter;
            }

        enterpin:

            Console.WriteLine("Please enter 4 digit pin:");
            string Pin = Console.ReadLine();


            if (Pin.Length == 4 && int.TryParse(Pin, out int pinNumber))
            {
                if (!PinBox.Contains(new Customers
                {
                    Name = Name,
                    Pin = pinNumber,
                }))
                {
                    Console.WriteLine("Pin not recognized");

                    Console.WriteLine("press enter to Register your Pin");
                    Console.ReadKey();
                    register();

                    //SelectLanguage();
                }
                else
                {
                    // login(pinNumber);
                    Console.WriteLine("\nLogin successful\n");
                    Console.WriteLine($"\nWelcome back....\n");
                }

                //return pinNumber;
            }
            else
            {
                Console.WriteLine("invalid input: try again");
                goto enterpin;
            }

            throw new NotImplementedException();
            //Console.WriteLine("Customer Id: {0}", Pin);
            //Console.WriteLine("First Name: {0}", Name);
        }


        public void register()
        {

            Console.WriteLine("Enter new 4 digit pin:");
        //Pin = Convert.ToInt32(Console.ReadLine());
        enterpin:
            string Pin;
            try
            {
                Pin = Console.ReadLine();
                if (Pin.Length == 4 && int.TryParse(Pin, out int pinNumber))
                {
                    Name = Console.ReadLine();
                    PinBox.Add(new Customers
                    {

                        Pin = pinNumber,
                    });


                    Console.WriteLine("registration Successful");
                    PinBox.ForEach(password =>
                    {
                        Console.WriteLine("entered {0}", password.Pin);
                    });
                    Console.WriteLine("press enter to login");
                    Console.ReadKey();
                    Console.Clear();
                    login(pinNumber);


                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto enterpin;
            }


        }
        public void login(int pinNumber)
        {
            Console.WriteLine("login with 4 digit pin:");
        loginpin:
            try
            {
                int pass = Convert.ToInt32(Console.ReadLine());
                if (pass == pinNumber)
                {
                    Console.WriteLine("login successful");
                    Console.WriteLine("\n Welcome Awesome Person \n press enter to carryout your transaction");
                    Console.ReadKey();
                    entryPoint();
                    SelectLanguage();
                }
                else
                {
                    Console.WriteLine("Pin mismatched");
                    goto loginpin;

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto loginpin;
            }
        }

        static void entryPoint()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Genesys ATM\n");
            Console.WriteLine("Choose your preferred language\n Horo Asusu i choro \nWählen Sie Ihre bevorzugte Sprache");
            Console.WriteLine("\nPress\\pia\\Drücken Sie \n\n1. English\n\n2. Igbo\n\n3. German\n");

        }
        public void SelectLanguage()
        {
        SelectLanguage:

            try
            {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        EnglishLanguage AtmEng = new EnglishLanguage();
                        EnglishLanguage.Withdrawal();
                        //Accountant account = new(AtmEng);
                        break;
                    case "2":
                        IgboLanguage AtmIgbo = new IgboLanguage();
                        break;
                    case "3":
                        //GermanLanguage AtmGerman = new GermanLanguage();
                        break;
                    default:
                        Console.WriteLine("\nINVALID INPUT");
                        goto SelectLanguage;
                }
                if (string.IsNullOrEmpty(action) && (action != "1" || action != "2" || action != "3"))
                {
                    //Console.WriteLine("invalid input");
                    goto SelectLanguage;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

    }



}
