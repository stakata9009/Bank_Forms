using System.Text.Json;

namespace Bank_Forms
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Сигурни ли сте, че искате да се върнете назад?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                this.Close();
            }
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this == ActiveForm)
            {
                DialogResult exit = MessageBox.Show("Сигурни ли сте, че искате да затворите програмата?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (exit == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            // Checking if a field is empty
            if (string.IsNullOrEmpty(tb_fname.Text) || string.IsNullOrEmpty(tb_lname.Text) || string.IsNullOrEmpty(tb_username.Text) || string.IsNullOrEmpty(tb_password.Text) || string.IsNullOrEmpty(tb_password2.Text))
            {
                MessageBox.Show("Има празно поле", "Грешка");
            }
            // Checking if both password fields match
            else if (tb_password.Text != tb_password2.Text) 
            {
                MessageBox.Show("Паролите не съвпадат.", "Грешка.");
            }
            // If both previous checks are good we start doing some work
            else 
            {
                // We read the json file
                string json = File.ReadAllText("customers.json");

                // We add everything from the json file into a list
                List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(json);

                string checkUsername = tb_username.Text;
                bool nameExists = false;

                // Before we make the registration we have to check if the username already exists in the json file
                foreach (Customer customer in customers)
                {
                    if (customer.userName == checkUsername)
                    {
                        nameExists = true;
                        MessageBox.Show("Потребителското име вече е заето", "Грешка");
                        break;
                    }
                }

                if (nameExists == false)
                {
                    // We create the new customer object.
                    Customer newCustomer = new Customer
                    {
                        fName = tb_fname.Text,
                        lName = tb_lname.Text,
                        userName = tb_username.Text,
                        passWord = tb_password.Text,
                        accNumber = Customer.accGenerator(),
                        balance = 0
                    };

                    // We add the new object to the list with the other obbjects from the json file
                    customers.Add(newCustomer);

                    // We put all the data (the old data plus the new object we created previously) to the json file
                    string updateJson = JsonSerializer.Serialize(customers);

                    // We write the info to the json file
                    File.WriteAllText("customers.json", updateJson);

                    MessageBox.Show("Поздравления! Вие се регистрирахте успешно в платформата.", "Готово!");

                    // We switch to the Sign In form
                    this.Hide();
                    SignIn signIn = new SignIn();
                    signIn.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
