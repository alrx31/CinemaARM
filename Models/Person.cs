namespace cinemaARM.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsAdmin { get; set; }
        
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
