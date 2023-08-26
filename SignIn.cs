using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Bank_Forms
{
    public partial class SignIn : Form
    {
        // We set a public variable from class Customer in order to get the Signed In object and pass it to the Main form
        public static Customer user;

        public SignIn()
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

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            // We set a few variables to take the input from the text box fields
            string uName = tb_uName.Text;
            string pWord = tb_pWord.Text;
            bool valid = false;

            // We read the json file
            string json = File.ReadAllText("customers.json");

            // We add everything from the json file into a list
            List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(json);

            // We start searching for a user name and password match inside the object List
            foreach (Customer customer in customers)
            {
                if (customer.userName == uName)
                {
                    if(customer.passWord == pWord)
                    {
                        // If a match is found we swap valid to true and set user to the actual object
                        valid = true;
                        user = customer;
                        break;
                    }
                }
            }

            // After the loop is done we have to check if a match was found so we can move to the Main form
            if (valid == false)
            {
                MessageBox.Show("Грешно потребителско име или парола.", "Грешка");
            }
            else if (valid == true)
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();
                this.Close();
            }
        }
    }
}
