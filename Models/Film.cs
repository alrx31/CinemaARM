namespace cinemaARM.Models
{
    public class Film
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int MinAge { get; set; }
        public DateTime ShowDate { get; set; }


        public List<ServeModel> Servos { get; set; }

    }
}
