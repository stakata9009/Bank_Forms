namespace Bank_Forms
{
    public class Customer
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public int accNumber { get; set; }
        public int balance { get; set; }

        public static int accGenerator()
        {
            Random generate = new Random();
            int r = generate.Next(100000, 999999);
            return r;
        }
    }
}

