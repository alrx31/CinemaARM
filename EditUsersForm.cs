using cinemaARM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinemaARM
{
    public partial class EditUsersForm : Form
    {
        private string _userLogin;

        public EditUsersForm(string userLogin)
        {
            InitializeComponent();
            _userLogin = userLogin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void update()
        {
            var users = getAllUsers();

            initialUsers(users);
        }

        public List<Person> getAllUsers()
        {
            var json = File.ReadAllText(ENV.DataFolder + "users.json");

            var users = JsonSerializer.Deserialize<List<Person>>(json);

            return users;
        }

        public void initialUsers(List<Person> users)
        {

            flowLayoutPanel1.Controls.Clear();

            foreach (var f in users)
            {
                var panel = new Panel();
                panel.Size = new Size(800, 300);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Padding = new Padding(10);


                var label = new Label();
                label.Text = "Имя: " + f.Name;
                label.Font = new Font("Arial", 16, FontStyle.Bold);
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panel.Controls.Add(label);

                var label2 = new Label();
                label2.Text = "Фамилия: " + f.Surname;
                label2.Location = new Point(10, 40);
                label2.AutoSize = true;
                panel.Controls.Add(label2);

                var label1 = new Label();
                label1.Text = "Логин: " + f.Login;
                label1.Location = new Point(10, 70);
                label1.AutoSize = true;
                panel.Controls.Add(label1);

                var label3 = new Label();
                label3.Text = f.IsAdmin ? "Админ" : "Не админ";
                label3.Location = new Point(10, 100);
                label3.AutoSize = true;
                panel.Controls.Add(label3);


                panel.Click += (sender, e) =>
                {
                    if (f.Login == _userLogin)
                    {
                        return;
                    }

                    var editForm = new EditOneUserForm(f.Login);
                    editForm.ShowDialog();
                    update();
                };


                panel.MaximumSize = new Size(800, 500);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void App_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var regForm = new RegisterForm();
            regForm.ShowDialog();
            update();
        }

        private void EditUsersForm_Load(object sender, EventArgs e)
        {
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
