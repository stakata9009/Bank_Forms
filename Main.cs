using System.Text.Json;

namespace Bank_Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // We fill in the form data using the user data from the Sign In form.
            label1.Text = SignIn.user.fName + " " + SignIn.user.lName;
            label4.Text = Convert.ToString(SignIn.user.accNumber);
            tb_balance.Text = Convert.ToString(SignIn.user.balance);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Сигурни ли сте, че искате да излезете от профила си?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                this.Close();
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            // We read the json file
            string json = File.ReadAllText("customers.json");

            // We add everything from the json file into a list
            List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(json);

            // We prepare empty objects for the giver and taker 
            Customer taker = null;
            Customer giver = null;

            // We set a variable that will follow if we have found a valid taker account number or not
            bool validNumber = false;

            // We make this loop to get the signed in user (giver) data from the List
            foreach (Customer customer in customers)
            {
                if (SignIn.user.accNumber == customer.accNumber)
                {
                    giver = customer;
                    break;
                }
            }

            // We make this loop to check if the user has entered a valid taker acc number and if so, to take it from the List
            foreach (Customer customer in customers)
            {
                if (tb_accNum.Text == Convert.ToString(customer.accNumber)) 
                {
                    taker = customer;
                    validNumber = true;
                    break;
                }
            }

            // In case a match from the previous loop is not found we fire a message to tell the user the number is likely wrong
            if (!validNumber) 
            {
                MessageBox.Show("Въведен е грешен номер на сметка.", "Грешка");
            }

            // If a math was found we proceed to doing the cheks, regarding the user's balance.
            if (taker != null)
            {
                if (string.IsNullOrEmpty(tb_sum.Text) || giver.balance < Convert.ToInt32(tb_sum.Text) || giver.balance == 0 || tb_sum.Text == "0")
                {
                    MessageBox.Show("Нямате достатъчно средства.", "Грешка");
                }
                else 
                {
                    int amount = Convert.ToInt32(tb_sum.Text);
                    giver.balance -= amount;
                    taker.balance += amount;

                    // We Serialize and prepare the updated customers List for saving
                    string updateJson = JsonSerializer.Serialize(customers);

                    // We write the updated info to the json file
                    File.WriteAllText("customers.json", updateJson);

                    MessageBox.Show("Средствата са изпратени успешно на " + taker.fName + " " + taker.lName, "Готово!");

                    tb_balance.Text = Convert.ToString(giver.balance);
                }
            }
        }
    }
}
