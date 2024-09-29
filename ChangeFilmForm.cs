using cinemaARM.Models;
using System.Text.Json;

namespace cinemaARM
{
    public partial class ChangeFilmForm : Form
    {
        private string _filmName;

        public ChangeFilmForm(string filmName)
        {
            InitializeComponent();
            _filmName = filmName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // delete film

            var json = File.ReadAllText(ENV.DataFolder + "films.json");
            var films = JsonSerializer.Deserialize<List<Film>>(json);

            var film = films.FirstOrDefault(f => f.Name == _filmName);

            if (film != null)
            {
                films.Remove(film);

                var newJson = JsonSerializer.Serialize(films);

                File.WriteAllText(ENV.DataFolder + "films.json", newJson);

                this.Close();
            }
            else
            {
                MessageBox.Show("Фильм не найден");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var json = File.ReadAllText(ENV.DataFolder + "films.json");

            var films = JsonSerializer.Deserialize<List<Film>>(json);

            var film = films.FirstOrDefault(f => f.Name == _filmName);

            if (film != null)
            {
                decimal earnMoney = film.Price * film.Servos.Count;

                film.Servos = new List<ServeModel>();

                var newJson = JsonSerializer.Serialize(films);

                File.WriteAllText(ENV.DataFolder + "films.json", newJson);

                MessageBox.Show("Записи удалены, зароботок: " + earnMoney);

                var json2 = File.ReadAllText(ENV.DataFolder + "money.json");

                var money = JsonSerializer.Deserialize<List<EarnFilm>>(json2);

                if (money.Any(m => m.FilmName == _filmName))
                {
                    var m = money.First(m => m.FilmName == _filmName);
                    m.EarnMoney += earnMoney;
                }
                else
                {
                    money.Add(new EarnFilm()
                    {
                        FilmName = _filmName,
                        EarnMoney = earnMoney
                    });
                }

                var newJson2 = JsonSerializer.Serialize(money);

                File.WriteAllText(ENV.DataFolder + "money.json", newJson2);

                this.Close();
            }
            else
            {
                MessageBox.Show("Фильм не найден");
            }
        }
    }
}
