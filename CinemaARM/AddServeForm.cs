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

        public AddServeForm(string filmName)
        {
            InitializeComponent();
            fileName = filmName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Serve(object sender, EventArgs e)
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

            var res = AddServe(seatNumber, name);
            
            if (!res) return;
            
            MessageBox.Show("Место успешно добавлено");

            this.Close();
        }

        public bool AddServe(
            int seatNumber, string name)
        {
            if (seatNumber < 1 || seatNumber > ENV.CountSeatsInCinema)
            {
                label3.Text = "Номер места должен быть от 1 до " + ENV.CountSeatsInCinema;
                label3.Visible = true;
                return false;
            }

            var serve = new ServeModel
            {
                Name = name,
                SeatNumber = seatNumber
            };

            var json = File.ReadAllText(ENV.DataFolder + "films.json");

            var films = JsonSerializer.Deserialize<List<Film>>(json);

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

            if(film.Servos.Any(s => s.SeatNumber == seatNumber))
            {
                label3.Text = "Место уже занято";
                label3.Visible = true;
                return false;
            }

            film.Servos.Add(serve);

            json = JsonSerializer.Serialize(films);

            File.WriteAllText(ENV.DataFolder + "films.json", json);

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

            var serve = new ServeModel
            {
                Name = name,
                SeatNumber = seatNumber
            };

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

            film.Servos.Remove(serve);

            films.Add(film);

            json = JsonSerializer.Serialize(films);

            File.WriteAllText(ENV.DataFolder + "films.json", json);

            return true;
        }
    }
}
