using cinemaARM.Models;
using System.Text.Json;

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
            
            var res = Delete_User();
            
            if (!res) return;
            
            MessageBox.Show("User deleted");

            this.Close();
        }

        public bool Delete_User()
        {
            // получение всех пользователей
            var json = File.ReadAllText(ENV.DataFolder + "users.json");
            var users = JsonSerializer.Deserialize<List<Person>>(json);

            // поиск пользователя
            var user = users.FirstOrDefault(x => x.Login == _userLogin);

            var messageResult = MessageBox.Show("Вы уверены");
            // подтверждение удаления
            if (messageResult != DialogResult.OK)
            {
                return false;
            }

            // удаление пользователя
            users.Remove(user);
            // сохранение изменений в файл
            File.WriteAllText(ENV.DataFolder + "users.json", JsonSerializer.Serialize(users));

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // change the is admin field
            var res = Change_IsAdmin();
            
            if (!res) return;
            
            MessageBox.Show("User deleted");

            this.Close();
        }

        public bool Change_IsAdmin()
        {
            // получение всех пользователей
            var json = File.ReadAllText(ENV.DataFolder+"users.json");
            var users = JsonSerializer.Deserialize<List<Person>>(json);
            
            // поиск пользователя
            var user = users.FirstOrDefault(x => x.Login == _userLogin);
            
            var messageResult = MessageBox.Show("Вы уверены");
            // подтверждение изменения
            if (messageResult != DialogResult.OK)
            {
                return false;
            }

            // изменение поля isAdmin
            user.IsAdmin = true;

            // перезапись пользователя
            users.Remove(user);
            users.Add(user);

            // сохранение изменений в файл
            File.WriteAllText(ENV.DataFolder + "users.json", JsonSerializer.Serialize(users));

            return true;
        }
    }
}
