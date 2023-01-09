using Microsoft.QualityTools.Testing.Fakes;

namespace TddBank.Tests
{
    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2023, 1, 09, 10, 30, true)]//mo
        [InlineData(2023, 1, 09, 10, 29, false)]//mo
        [InlineData(2023, 1, 09, 10, 31, true)] //mo
        [InlineData(2023, 1, 09, 18, 59, true)] //mo
        [InlineData(2023, 1, 09, 19, 00, false)] //mo
        [InlineData(2023, 1, 14, 13, 0, true)] //sa
        [InlineData(2023, 1, 14, 16, 0, false)] //sa
        [InlineData(2023, 1, 15, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();


            Assert.Equal(result, oh.IsOpen(dt));
        }


        [Fact]
        public void OpeningHours_IsWeekend()
        {
            var oh = new OpeningHours();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 1, 2); //mo
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 1, 3); //di
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 1, 4); //mi
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 1, 5); //do
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 1, 6); //fr
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 1, 7); //sa
                Assert.True(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 1, 8); //so
                Assert.True(oh.IsWeekend());
            }
        }

        [Fact]
        public void ReadConfFile_Tests()
        {
            var oh = new OpeningHours();

            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimStreamReader.ConstructorString = (sr, path) => { };
                System.IO.Fakes.ShimStreamReader.AllInstances.ReadToEnd = (sr) => "Tee";

               oh.ReadConfFile();
            }
        }

    }
}
