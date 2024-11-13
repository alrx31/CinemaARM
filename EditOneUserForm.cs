using cinemaARM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinemaARM
{
    public partial class EditOneUserForm : Form
    {
        private string _userLogin;

        public EditOneUserForm(string userLogin)
        {
            InitializeComponent();
            _userLogin = userLogin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // delete user
            var json = File.ReadAllText(ENV.DataFolder + "users.json");
            var users = JsonSerializer.Deserialize<List<Person>>(json);

            var user = users.FirstOrDefault(x => x.Login == _userLogin);

            var messageResult = MessageBox.Show("Вы уверены");
            if (messageResult != DialogResult.OK)
            {
                return;
            }

            users.Remove(user);

            File.WriteAllText(ENV.DataFolder + "users.json", JsonSerializer.Serialize(users));
            MessageBox.Show("User deleted");

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // change the is admin field
            var json = File.ReadAllText(ENV.DataFolder+"users.json");
            var users = JsonSerializer.Deserialize<List<Person>>(json);

            var user = users.FirstOrDefault(x => x.Login == _userLogin);

            var messageResult = MessageBox.Show("Вы уверены");
            if (messageResult != DialogResult.OK)
            {
                return;
            }

            user.IsAdmin = true;

            users.Remove(user);
            users.Add(user);

            File.WriteAllText(ENV.DataFolder + "users.json", JsonSerializer.Serialize(users));
            MessageBox.Show("User deleted");

            this.Close();
        }
    }
}
