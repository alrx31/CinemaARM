using cinemaARM;

namespace Tests.Unit
{
    public class ChangeFilmTests
    {
        private readonly ChangeFilmForm _changeFilmForm;

        public ChangeFilmTests()
        {
            _changeFilmForm = new ChangeFilmForm("Film1");
        }

        [Fact]
        public async  Task DeleteFilm_Fail()
        {
            var res = _changeFilmForm.Delete_Film();

            Assert.False(res);
        }

        [Fact]
        public async Task DeleteFilm_Success()
        {
            var res = _changeFilmForm.Delete_Film();
        
            Assert.True(res);
        }

        [Fact]
        public async Task ClearFilm_Fail()
        {
            var res = _changeFilmForm.CrearFilm();

            Assert.False(res);
        }

        [Fact]
        public async Task ClearFilm_Success()
        {
            var res = _changeFilmForm.CrearFilm();

            Assert.True(res);
        }
    }
}
