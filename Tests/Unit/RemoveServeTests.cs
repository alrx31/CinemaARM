using cinemaARM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Unit
{
    public class RemoveServeTests
    {
        private AddServeForm addServeForm;

        public RemoveServeTests()
        {
            addServeForm = new AddServeForm("Film");
        }

        [Fact]
        public async Task RemoveServe_Success()
        {
            var res1 = addServeForm.AddServe(2, "Name1");

            Assert.True(res1);

            var res2 = addServeForm.Remove_Serve(2, "Name1");

            Assert.True(res2);
        }

        [Fact]
        public async Task RemoveServe_Fail()
        {
            var res = addServeForm.Remove_Serve(2, "");

            Assert.False(res);
        }
    }
}
