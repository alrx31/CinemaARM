namespace cinemaARM.Models
{
    public class ENV
    {
        public static string CinimaName = "Октябрьский Кинотеатр";
        public static int CountSeatsInCinema = 2;
        public static int FilmPrice = 10;
        public static string DataFolder = "./../../../Data/";

        public static string AdminLogin = "admin";
        public static string AdminPassword = "admin";


        public static string getHash(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = System.Security.Cryptography.SHA256.HashData(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
    }
}
