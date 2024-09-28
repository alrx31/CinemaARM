using cinemaARM.Models;
using System.Text.Json;

namespace cinemaARM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var adminModel = new Person
            {
                Id = 1,
                Name = "admin",
                Surname = "admin",
                IsAdmin = true,
                Login = ENV.AdminLogin,
                Password = ENV.getHash(ENV.AdminPassword),
                Email = ""
            };

            
            string json = File.ReadAllText(ENV.DataFolder + "users.json");
            var users = JsonSerializer.Deserialize<List<Person>>(json);

            if(users.Count == 0)
            {
                users.Add(adminModel);
                json = JsonSerializer.Serialize(users);
                File.WriteAllText(ENV.DataFolder + "users.json", json);
            }



            Application.Run(new App());
        }
    }
}