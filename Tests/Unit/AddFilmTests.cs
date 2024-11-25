using cinemaARM;

namespace Tests.Unit
{
    public class AddFilmTests
    {
        private readonly AddFilmForm addFilmForm;

        public AddFilmTests()
        {
            addFilmForm = new AddFilmForm();
        }

        [Fact]
        public async Task AddFilm_Success()
        {
            var name = "Film";
            var description = "Description";
            var genre = "Genre";
            var director = "Director";
            var country = "Country";
            var showDate = DateTime.UtcNow.AddDays(1);
            var year = 2021;
            var price = 100;
            var rating = 5;
            var minAge = 12;

            var result = addFilmForm.AddFilm(name, description, genre,
                director, country, showDate, year, price, rating, minAge);

            Assert.True(result);
        }

        [Fact]
        public async Task AddFilm_Fail()
        {
            var res = addFilmForm.AddFilm("", "", "", "", "", DateTime.UtcNow, 0, 0, 0, 0);

            Assert.False(res);
        }
    }
}
