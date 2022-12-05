namespace atm
{
    class Alert
    {
        //static

        public static void AlertPinChanged(object? sender, EventArgs e)
        {
            //Customers customer = new Customers();
            Customers customer = (Customers)sender!;
            Console.WriteLine("{0}User  has changed his pin to {1} ", customer.Name, customer.Pin);
        }

        public static void AlertBalanceChanged(object? sender, EventArgs e)
        {
            //EnglishLanguage eng = (EnglishLanguage)sender!;
            //Customers customer = new Customers();
            Customers customer = (Customers)sender!;

            Console.WriteLine("User  balance has changed to {1} ", customer.Balance);


        }
    }


}
