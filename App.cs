using cinemaARM.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace cinemaARM
{
    public partial class App : Form
    {
        private int _ruleLevel;
        private Person person;

        public App()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Text = ENV.CinimaName;
        }

        private void App_Load(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(ref _ruleLevel);
            /*loginForm.Login(ref _ruleLevel, ref person);
            if (_ruleLevel == 0)
            {
                this.Close();
            }*/
            _ruleLevel = 2;
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void update()
        {
            var films = getAllMovies();

            initialFilms(films);
        }



        public List<Film> getAllMovies()
        {
            var json = File.ReadAllText(ENV.DataFolder + "films.json");

            var films = JsonSerializer.Deserialize<List<Film>>(json);

            return films;
        }


        public void initialFilms(List<Film> films)
        {

            flowLayoutPanel1.Controls.Clear();

            foreach (var f in films)
            {
                var panel = new Panel();
                panel.Size = new Size(800, 300);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Padding = new Padding(10);


                var label = new Label();
                label.Text = f.Name;
                label.Font = new Font("Arial", 16, FontStyle.Bold);
                label.Location = new Point(10, 10);
                label.AutoSize = true;
                panel.Controls.Add(label);

                var label2 = new Label();
                label2.Text = f.Description;
                label2.AutoSize = true;
                label2.Location = new Point(10, 30);
                panel.Controls.Add(label2);

                var label3 = new Label();
                label3.Text = f.Genre;
                label3.AutoSize = true;
                label3.Location = new Point(10, 50);
                panel.Controls.Add(label3);

                var label4 = new Label();
                label4.Text = f.Director;
                label4.AutoSize = true;
                label4.Location = new Point(10, 70);
                panel.Controls.Add(label4);

                var label5 = new Label();
                label5.Text = f.Country;
                label5.AutoSize = true;
                label5.Location = new Point(10, 90);
                panel.Controls.Add(label5);
                var label6 = new Label();

                label6.Text = f.Year.ToString();
                label6.Location = new Point(10, 110);
                label6.AutoSize = true;
                panel.Controls.Add(label6);

                var label7 = new Label();
                label7.Text = "Цена: " + f.Price.ToString();
                label7.Location = new Point(10, 140);
                label7.AutoSize = true;
                panel.Controls.Add(label7);

                var label8 = new Label();
                label8.Text = "Рейтинг: " + f.Rating.ToString();
                label8.Location = new Point(10, 160);
                label8.AutoSize = true;
                panel.Controls.Add(label8);

                var label9 = new Label();
                label9.Text = "Возраст: " + f.MinAge.ToString();
                label9.Location = new Point(10, 180);
                label9.AutoSize = true;
                panel.Controls.Add(label9);

                var label10 = new Label();
                label10.Text = "Записей: " + f.Servos.Count.ToString();
                label10.Location = new Point(10, 200);
                label10.AutoSize = true;
                panel.Controls.Add(label10);

                if (f.Servos.Count == ENV.CountSeatsInCinema)
                {
                    var label11 = new Label();
                    label11.Text = "Все места заняты";
                    label11.Location = new Point(10, 220);
                    label11.AutoSize = true;
                    label11.Font = new Font("Arial", 14, FontStyle.Bold);
                    label11.ForeColor = Color.Red;
                    panel.Controls.Add(label11);
                }
                else
                {
                    var label11 = new Label();
                    label11.Text = "Свободно мест: " + (ENV.CountSeatsInCinema - f.Servos.Count).ToString();
                    label11.Location = new Point(10, 220);
                    label11.AutoSize = true;
                    panel.Controls.Add(label11);
                }




                
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
    }
}
