﻿using cinemaARM.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace cinemaARM
{
    public partial class App : Form
    {
        private int _ruleLevel;
        private Person person;

        private bool isPriceSort = false;
        private bool isRatingSort = false;
        private List<Film> films;

        public App()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Text = ENV.CinimaName;
        }

        private void App_Load(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(ref _ruleLevel, ref person);
            loginForm.Login(ref _ruleLevel, ref person);

            if (_ruleLevel == 0)
            {
                this.Close();
            }

            if (_ruleLevel == 2)
            {
                button3.Visible = true;
                button4.Visible = true;
            }
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void update()
        {
            var films = getAllMovies();
            this.films = films;
            initialFilms();
        }



        public List<Film> getAllMovies()
        {
            var json = File.ReadAllText(ENV.DataFolder + "films.json");

            var films = JsonSerializer.Deserialize<List<Film>>(json);

            return films;
        }


        public void initialFilms()
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
                panel.MinimumSize = new Size(1600, 300);

                var innerFlowPanel = new FlowLayoutPanel();
                innerFlowPanel.FlowDirection = FlowDirection.TopDown;
                innerFlowPanel.AutoSize = true;
                innerFlowPanel.WrapContents = false;
                innerFlowPanel.MaximumSize = new Size(1500, 0);

                var label = new Label();
                label.Text = f.Name;
                label.Font = new Font("Arial", 16, FontStyle.Bold);
                label.AutoSize = true;
                label.MaximumSize = new Size(1500, 0);
                innerFlowPanel.Controls.Add(label);

                var label111 = new Label();
                label111.Text = f.ShowDate.ToString("dd.MM.yyyy HH:mm");
                label111.Font = new Font("Arial", 16, FontStyle.Bold);
                label111.AutoSize = true;
                label111.MaximumSize = new Size(1500, 0);
                innerFlowPanel.Controls.Add(label111);

                var label2 = new Label();
                label2.Text = f.Description;
                label2.AutoSize = true;
                label2.MaximumSize = new Size(1500, 0);
                innerFlowPanel.Controls.Add(label2);

                var label3 = new Label();
                label3.Text = f.Genre;
                label3.AutoSize = true;
                label3.MaximumSize = new Size(1500, 0);
                innerFlowPanel.Controls.Add(label3);

                var label4 = new Label();
                label4.Text = f.Director;
                label4.AutoSize = true;
                label4.MaximumSize = new Size(1500, 0);
                innerFlowPanel.Controls.Add(label4);

                var label5 = new Label();
                label5.Text = f.Country;
                label5.AutoSize = true;
                label5.MaximumSize = new Size(1500, 0);
                innerFlowPanel.Controls.Add(label5);

                var label6 = new Label();
                label6.Text = f.Year.ToString();
                label6.MaximumSize = new Size(1500, 0);
                label6.AutoSize = true;
                innerFlowPanel.Controls.Add(label6);

                var label7 = new Label();
                label7.Text = "Цена: " + f.Price.ToString();
                label7.MaximumSize = new Size(1500, 0);
                label7.AutoSize = true;
                innerFlowPanel.Controls.Add(label7);

                var label8 = new Label();
                label8.Text = "Рейтинг: " + f.Rating.ToString();
                label8.MaximumSize = new Size(1500, 0);
                label8.AutoSize = true;
                innerFlowPanel.Controls.Add(label8);

                var label9 = new Label();
                label9.Text = "Возраст: " + f.MinAge.ToString();
                label9.MaximumSize = new Size(1500, 0);
                label9.AutoSize = true;
                innerFlowPanel.Controls.Add(label9);

                var label10 = new Label();
                label10.Text = "Записей: " + f.Servos.Count.ToString();
                label10.MaximumSize = new Size(1500, 0);
                label10.AutoSize = true;
                innerFlowPanel.Controls.Add(label10);

                if (f.Servos.Count == ENV.CountSeatsInCinema)
                {
                    var label11 = new Label();
                    label11.Text = "Все места заняты";
                    label11.MaximumSize = new Size(1500, 0);
                    label11.AutoSize = true;
                    label11.Font = new Font("Arial", 14, FontStyle.Bold);
                    label11.ForeColor = Color.Red;
                    innerFlowPanel.Controls.Add(label11);
                }
                else
                {
                    var label11 = new Label();
                    label11.Text = "Свободно мест: " + (ENV.CountSeatsInCinema - f.Servos.Count).ToString();
                    label11.MaximumSize = new Size(1500, 0);
                    label11.AutoSize = true;
                    innerFlowPanel.Controls.Add(label11);

                    EventHandler action = (object sender,EventArgs e) =>
                    {
                        var form = new AddServeForm(f.Name);
                        form.ShowDialog();
                        update();
                    };

                    panel.Click += action;
                    label11.Click += action;
                    label10.Click += action;
                    label9.Click += action;
                    label8.Click += action;
                    label7.Click += action;
                    label6.Click += action;
                    label5.Click += action;
                    label4.Click += action;
                    label3.Click += action;
                    label2.Click += action;
                    label.Click += action;
                    innerFlowPanel.Click += action;

                }

                panel.Controls.Add(innerFlowPanel);
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
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (_ruleLevel != 2)
            {
                MessageBox.Show("У вас нет прав на это действие");
                return;
            }

            var editUserForm = new EditUsersForm(person.Login);
            editUserForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_ruleLevel != 2)
            {
                MessageBox.Show("У вас нет прав на это действие");
                return;
            }

            var editFilms = new EditFilmsForm();
            editFilms.ShowDialog();
        }

        private List<Film> SortByPrice(List<Film> films)
        {
            var filmsArray = films.ToArray();

            for (var i = 1; i < filmsArray.Length; i++)
            {
                var currentFilm = filmsArray[i];
                var j = i - 1;

                while (j >= 0 && filmsArray[j].Price > currentFilm.Price)
                {
                    filmsArray[j + 1] = filmsArray[j];
                    j--;
                }

                filmsArray[j + 1] = currentFilm;
            }

            return filmsArray.ToList();
        }

        private List<Film> SortByPriceDESC(List<Film> films)
        {
            if (films.Count <= 1)
                return films;

            var pivot = films[films.Count / 2]; 
            var left = new List<Film>();        
            var right = new List<Film>();       
            var middle = new List<Film>();      

            foreach (var film in films)
            {
                if (film.Price > pivot.Price)
                    left.Add(film);             
                else if (film.Price < pivot.Price)
                    right.Add(film);            
                else
                    middle.Add(film);           
            }
            
            return SortByPriceDESC(left)
                .Concat(middle)
                .Concat(SortByPriceDESC(right))
                .ToList();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (isPriceSort)
            {
                this.films = SortByPrice(this.films);
            }
            else
            {
                this.films = SortByPriceDESC(this.films);
            }

            isPriceSort = !isPriceSort;
            initialFilms();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(isRatingSort)
            {
                this.films = SortByRating(this.films);
            }
            else
            {
                this.films = SortByRatingDESC(this.films);
            }

            isRatingSort = !isRatingSort;
            initialFilms();
        }

        private List<Film> SortByRating(List<Film> films)
        {
            var filmsArray = films.ToArray();
            var left = 0;
            var right = filmsArray.Length - 1;
            while (left < right)
            {
                var min = left;
                for (var i = left + 1; i <= right; i++)
                {
                    if (filmsArray[i].Rating < filmsArray[min].Rating)
                    {
                        min = i;
                    }
                }

                var temp = filmsArray[min];
                filmsArray[min] = filmsArray[left];
                filmsArray[left] = temp;
                left++;
            }

            return filmsArray.ToList();
        }

        private List<Film> SortByRatingDESC(List<Film> films)
        {
            var filmsArray = films.ToArray();
            var left = 0;
            var right = filmsArray.Length - 1;
            while (left < right)
            {
                var min = left;
                for (var i = left + 1; i <= right; i++)
                {
                    if (filmsArray[i].Rating > filmsArray[min].Rating)
                    {
                        min = i;
                    }
                }

                var temp = filmsArray[min];
                filmsArray[min] = filmsArray[left];
                filmsArray[left] = temp;
                left++;
            }

            return filmsArray.ToList();
        }
    }
}