namespace Bank_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_singin_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signIn= new SignIn();
            signIn.ShowDialog();
            this.Close();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
            this.Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}