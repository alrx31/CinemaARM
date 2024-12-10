using cinemaARM.Models;
using System.Text.Json;

namespace cinemaARM
{
    public partial class AddFilmForm : Form
    {
        public AddFilmForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // получение данных из формы
            var name = textBox1.Text;
            var description = textBox2.Text;
            var genre = textBox3.Text;
            var director = textBox4.Text;
            var country = textBox5.Text;
            var showDate = dateTimePicker1.Value;

            int year;
            decimal price;
            decimal rating;
            int minAge;

            // проверка ввода числовых данных
            try
            {
                year = int.Parse(textBox6.Text);
                price = decimal.Parse(textBox7.Text);
                rating = decimal.Parse(textBox8.Text);
                minAge = int.Parse(textBox9.Text);
            }
            catch (Exception ex)
            {
                label10.Text = "Ошибка ввода числовых данных";
                label10.Visible = true;
                return;
            }
            // добавление фильма
            var res = AddFilm(name, description, genre, director, country, showDate, year, price, rating, minAge);

            if (res) MessageBox.Show("Фильм добавлен");
            else return;

            this.Close();
        }

        public bool AddFilm(
            string name, string description, string genre, string director, string country, DateTime showDate
            ,int year, decimal price, decimal rating, int minAge)
        {
            // проверка ввода
            if (name == "" || description == "" || genre == "" || director == "" || country == "")
            {
                label10.Text = "Не все поля заполнены";
                label10.Visible = true;
                return false;
            }

            if (year < 1900 || year > 2025)
            {
                label10.Text = "Год должен быть в диапазоне от 1900 до 2025";
                label10.Visible = true;
                return false;
            }

            if (price < 0)
            {
                label10.Text = "Цена не может быть отрицательной";
                label10.Visible = true;
                return false;
            }

            if (rating < 0 || rating > 10)
            {
                label10.Text = "Рейтинг должен быть в диапазоне от 0 до 10";
                label10.Visible = true;
                return false;
            }

            if (minAge < 0 || minAge > 18)
            {
                label10.Text = "Возрастное ограничение должно быть в диапазоне от 0 до 18";
                label10.Visible = true;
                return false;
            }

            if(showDate < DateTime.UtcNow)
            {
                label10.Text = "Неверное время показа";
                label10.Visible = true;
            }

            //  получение всех фильмов
            var json = File.ReadAllText(ENV.DataFolder + "films.json");
            var films = JsonSerializer.Deserialize<List<Film>>(json);
            
            // добавление нового фильма
            var film = new Film()
            {
                Id = films.Count + 1,
                Name = name,
                Description = description,
                Genre = genre,
                Director = director,
                Country = country,
                Year = year,
                Price = price,
                Rating = rating,
                MinAge = minAge,
                Servos = new List<ServeModel>(),
                ShowDate = showDate
            };

            films.Add(film);

            // запись в файл
            var newJson = JsonSerializer.Serialize(films);

            File.WriteAllText(ENV.DataFolder + "films.json", newJson);

            return true;
        }
    }
}
