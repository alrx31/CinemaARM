namespace cinemaARM.Models
{
    public class Cheque
    {
        public int ChequeId { get; set; }
        public string FilmName { get; set; }
        public string DateTIme { get; set; }
        public int Seat { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }


        public string ManagerName { get; set; }
        public string CinemaName {get;set;}


        public bool IsReturned { get; set; }
    }
}
