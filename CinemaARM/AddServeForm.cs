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
    public partial class AddServeForm : Form
    {
        public string fileName;
        public string managerName;

        public AddServeForm(string filmName,string managerName)
        {
            InitializeComponent();
            fileName = filmName;
            this.managerName = managerName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Serve(object sender, EventArgs e)
        {
            // получение данных из формы
            var name = textBox1.Text;
            int seatNumber;

            // проверка ввода числовых данных
            if (name == "")
            {
                label3.Text = "Введите имя";
                label3.Visible = true;
                return;
            }

            try
            {
                seatNumber = int.Parse(textBox2.Text);
            }
            catch (Exception ex)
            {
                label3.Text = "Номер места должен быть числом";
                label3.Visible = true;
                return;
            }
            // добавление брони
            var res = AddServe(seatNumber, name);
            
            if (!res) return;
            
            MessageBox.Show("Место успешно добавлено");

            this.Close();
        }

        public bool AddServe(
            int seatNumber, string name)
        {
            // проверка ввода
            if (seatNumber < 1 || seatNumber > ENV.CountSeatsInCinema)
            {
                label3.Text = "Номер места должен быть от 1 до " + ENV.CountSeatsInCinema;
                label3.Visible = true;
                return false;
            }
            
            // создание брони
            var serve = new ServeModel
            {
                Name = name,
                SeatNumber = seatNumber
            };

            // получение данных о фильмах
            var json = File.ReadAllText(ENV.DataFolder + "films.json");

            var films = JsonSerializer.Deserialize<List<Film>>(json);

            // поиск нужного фильма
            var film = films.First(f => f.Name == fileName);

            if (film == null)
            {
                MessageBox.Show("Фильм не найден");
                return false;
            }

            if (film.Servos == null)
            {
                film.Servos = new List<ServeModel>();
            }
            
            // проверка на занятость места
            
            if(film.Servos.Any(s => s.SeatNumber == seatNumber))
            {
                label3.Text = "Место уже занято";
                label3.Visible = true;
                return false;
            }
            // добавление брони
            film.Servos.Add(serve);
            // сохранение изменений в файл
            json = JsonSerializer.Serialize(films);

            File.WriteAllText(ENV.DataFolder + "films.json", json);

            //Создание чека

            var jsonCheque = File.ReadAllText(ENV.DataFolder + "cheques.json");
            var cheques = JsonSerializer.Deserialize<List<Cheque>>(jsonCheque);

            if (cheques == null)
            {
                cheques = new List<Cheque>();
            }


            var cheque = new Cheque
            {
                ChequeId = cheques.Count,
                FilmName = film.Name,
                DateTIme = DateTime.Now.ToString(),
                Seat = seatNumber,
                Price = film.Price,
                ManagerName = managerName,
                CinemaName = ENV.CinimaName,
                IsReturned = false,
                Name = name
            };

            cheques.Add(cheque);

            jsonCheque = JsonSerializer.Serialize(cheques);

            File.WriteAllText(ENV.DataFolder + "cheques.json", jsonCheque);

            return true;
        }
        
        private void RemoveServe(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            int seatNumber;

            if (name == "")
            {
                label3.Text = "Введите имя";
                label3.Visible = true;
                return;
            }

            try
            {
                seatNumber = int.Parse(textBox2.Text);
            }
            catch (Exception ex)
            {
                label3.Text = "Номер места должен быть числом";
                label3.Visible = true;
                return;
            }

            var res = Remove_Serve(seatNumber, name);
            
            if (!res) return;

            MessageBox.Show("Бронь успешно снята");

            this.Close();
        }

        public bool Remove_Serve(
            int seatNumber, string name)
        {
            if (seatNumber < 1 || seatNumber > ENV.CountSeatsInCinema)
            {
                label3.Text = "Номер места должен быть от 1 до " + ENV.CountSeatsInCinema;
                label3.Visible = true;
                return false;
            }

            var json = File.ReadAllText(ENV.DataFolder + "films.json");

            var films = JsonSerializer.Deserialize<List<Film>>(json);

            var film = films.First(f => f.Name == fileName);

            films.Remove(film);

            if (film == null)
            {
                MessageBox.Show("Фильм не найден");
                return false;
            }

            if (film.Servos == null)
            {
                film.Servos = new List<ServeModel>();
            }
            
            if(!film.Servos.Any(s => s.SeatNumber == seatNumber))
            {
                label3.Text = "Место еще не занято";
                label3.Visible = true;
                return false;
            }

            var serve = film.Servos.First(s => s.SeatNumber == seatNumber);

            film.Servos.Remove(serve);

            films.Add(film);

            json = JsonSerializer.Serialize(films);

            File.WriteAllText(ENV.DataFolder + "films.json", json);


            var jsonCheque = File.ReadAllText(ENV.DataFolder + "cheques.json");

            var cheques = JsonSerializer.Deserialize<List<Cheque>>(jsonCheque);

            var cheque = cheques.First(
                c => c.FilmName == film.Name && c.Seat == seatNumber && c.Name == name);

            cheques.Remove(cheque);
            cheque.IsReturned = true;

            cheques.Add(cheque);

            jsonCheque = JsonSerializer.Serialize(cheques);

            File.WriteAllText(ENV.DataFolder + "cheques.json", jsonCheque);

            return true;
        }
    }
}
