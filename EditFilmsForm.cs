using cinemaARM.Models;
using System.Text.Json;

namespace cinemaARM
{
    public partial class EditFilmsForm : Form
    {
        public EditFilmsForm()
        {
            InitializeComponent();
            update();
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

                panel.AutoSize = true;
                panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Padding = new Padding(10);
                panel.MaximumSize = new Size(800, 0);
                panel.MinimumSize = new Size(800, 300);

                var innerFlowPanel = new FlowLayoutPanel();
                innerFlowPanel.FlowDirection = FlowDirection.TopDown;
                innerFlowPanel.AutoSize = true;
                innerFlowPanel.WrapContents = false;
                innerFlowPanel.MaximumSize = new Size(780, 0);

                var label = new Label();
                label.Text = f.Name;
                label.Font = new Font("Arial", 16, FontStyle.Bold);
                label.AutoSize = true;
                label.MaximumSize = new Size(780, 0);
                innerFlowPanel.Controls.Add(label);

                var label111 = new Label();
                label111.Text = f.ShowDate.ToString("dd.MM.yyyy HH:mm");
                label111.Font = new Font("Arial", 16, FontStyle.Bold);
                label111.AutoSize = true;
                label111.MaximumSize = new Size(780, 0);
                innerFlowPanel.Controls.Add(label111);

                var label2 = new Label();
                label2.Text = f.Description;
                label2.AutoSize = true;
                label2.MaximumSize = new Size(780, 0);
                innerFlowPanel.Controls.Add(label2);

                var label3 = new Label();
                label3.Text = f.Genre;
                label3.AutoSize = true;
                label3.MaximumSize = new Size(780, 0);
                innerFlowPanel.Controls.Add(label3);

                var label4 = new Label();
                label4.Text = f.Director;
                label4.AutoSize = true;
                label4.MaximumSize = new Size(780, 0);
                innerFlowPanel.Controls.Add(label4);

                var label5 = new Label();
                label5.Text = f.Country;
                label5.AutoSize = true;
                label5.MaximumSize = new Size(780, 0);
                innerFlowPanel.Controls.Add(label5);

                var label6 = new Label();
                label6.Text = f.Year.ToString();
                label6.MaximumSize = new Size(780, 0);
                label6.AutoSize = true;
                innerFlowPanel.Controls.Add(label6);

                var label7 = new Label();
                label7.Text = "Цена: " + f.Price.ToString();
                label7.MaximumSize = new Size(780, 0);
                label7.AutoSize = true;
                innerFlowPanel.Controls.Add(label7);

                var label8 = new Label();
                label8.Text = "Рейтинг: " + f.Rating.ToString();
                label8.MaximumSize = new Size(780, 0);
                label8.AutoSize = true;
                innerFlowPanel.Controls.Add(label8);

                var label9 = new Label();
                label9.Text = "Возраст: " + f.MinAge.ToString();
                label9.MaximumSize = new Size(780, 0);
                label9.AutoSize = true;
                innerFlowPanel.Controls.Add(label9);

                var label10 = new Label();
                label10.Text = "Записей: " + f.Servos.Count.ToString();
                label10.MaximumSize = new Size(780, 0);
                label10.AutoSize = true;
                innerFlowPanel.Controls.Add(label10);

                if (f.Servos.Count == ENV.CountSeatsInCinema)
                {
                    var label11 = new Label();
                    label11.Text = "Все места заняты";
                    label11.MaximumSize = new Size(780, 0);
                    label11.AutoSize = true;
                    label11.Font = new Font("Arial", 14, FontStyle.Bold);
                    label11.ForeColor = Color.Red;
                    innerFlowPanel.Controls.Add(label11);
                }
                else
                {
                    var label11 = new Label();
                    label11.Text = "Свободно мест: " + (ENV.CountSeatsInCinema - f.Servos.Count).ToString();
                    label11.MaximumSize = new Size(780, 0);
                    label11.AutoSize = true;
                    innerFlowPanel.Controls.Add(label11);

                    
                }


                panel.Click += (s, e) =>
                {
                    var form = new ChangeFilmForm(f.Name);
                    form.ShowDialog();
                    update();
                };




                panel.Controls.Add(innerFlowPanel);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var addFilmForm = new AddFilmForm();
            addFilmForm.ShowDialog();
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
