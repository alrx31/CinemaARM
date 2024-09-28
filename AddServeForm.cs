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
        private string _filmName;

        public AddServeForm(string filmName)
        {
            InitializeComponent();
            _filmName = filmName;
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

            if (seatNumber < 1 || seatNumber > ENV.CountSeatsInCinema)
            {
                label3.Text = "Номер места должен быть от 1 до " + ENV.CountSeatsInCinema;
                label3.Visible = true;
                return;
            }

            var serve = new ServeModel
            {
                Name = name,
                SeatNumber = seatNumber
            };

            var json = File.ReadAllText(ENV.DataFolder + "films.json");

            var films = JsonSerializer.Deserialize<List<Film>>(json);

            var film = films.First(f => f.Name == _filmName);

            if (film == null)
            {
                MessageBox.Show("Фильм не найден");
                return;
            }

            if (film.Servos == null)
            {
                film.Servos = new List<ServeModel>();
            }

            if(film.Servos.Any(s => s.SeatNumber == seatNumber))
            {
                label3.Text = "Место уже занято";
                label3.Visible = true;
                return;
            }

            film.Servos.Add(serve);

            json = JsonSerializer.Serialize(films);

            File.WriteAllText(ENV.DataFolder + "films.json", json);

            MessageBox.Show("Место успешно добавлено");

            this.Close();
        }
    }
}
