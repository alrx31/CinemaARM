using cinemaARM.Models;

namespace cinemaARM
{
    public partial class App : Form
    {
        private int _ruleLevel;
        private Person person;

        public App()
        {
            InitializeComponent();
            this.Text = ENV.CinimaName;
        }

        private void App_Load(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(ref _ruleLevel);
            loginForm.Login(ref _ruleLevel, ref person);
            if (_ruleLevel == 0)
            {
                this.Close();
            }
        }
    }
}
