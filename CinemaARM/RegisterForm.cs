﻿using cinemaARM.Models;
using System.Text.Json;

namespace cinemaARM
{
    public partial class RegisterForm : Form
    {


        public RegisterForm()
        {
            InitializeComponent();
        }

        private void Register_event(object sender, EventArgs e)
        {
            // получение данных из формы
            var name = textBox1.Text;
            var surname = textBox2.Text;
            var login = textBox3.Text;
            var password = textBox4.Text;
            var isAdmin = checkBox1.Checked;
            var ReapetPassword = textBox5.Text;

            // проверка ввода
            if(name == "" || surname == "" || login == "" || password == "" || ReapetPassword == "")
            {
                label6.Text = "Заполните все поля";
                label6.Visible = true;
                return;
            }

            // проверка совпадения паролей
            if (password != ReapetPassword)
            {
                label6.Text = "Пароли не совпадают";
                label6.Visible = true;
                return;
            }



            // чтение всех пользователей
            var json = File.ReadAllText(ENV.DataFolder + "users.json");
            var users = JsonSerializer.Deserialize<List<Person>>(json);

            // проверка существования пользователя
            if (users.Any(x => x.Login == login))
            {
                label6.Text = "Пользователь с таким логином уже существует";
                label6.Visible = true;
                return;
            }
            // создание пользователя 
            var user = new Person
            {
                Id = users.Count + 1,
                Name = name,
                Surname = surname,
                Login = login,
                Password = ENV.getHash(password),
                IsAdmin = isAdmin
            };

            users.Add(user);

            // сохранение изменений в файл
            json = JsonSerializer.Serialize(users);

            File.WriteAllText(ENV.DataFolder + "users.json", json);

            MessageBox.Show("Пользователь успешно зарегистрирован");

            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
