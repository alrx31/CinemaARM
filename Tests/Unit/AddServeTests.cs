using cinemaARM;

namespace Tests.Unit
{
    public class AddServeTests
    {
        private  AddServeForm _addServeForm;

        public AddServeTests()
        {
            _addServeForm = new AddServeForm("Film");
        }

        [Fact]
        public async Task AddServe_Success()
        {
            var seatNumber = 2;
            var name = "TestName";

            var result = _addServeForm.AddServe(seatNumber, name);

            Assert.True(result);
        }

        [Fact]
        public async Task AddServe_Fail()
        {
            var res = _addServeForm.AddServe(0, "TestName");
            
            Assert.False(res);
        }
    }
}
