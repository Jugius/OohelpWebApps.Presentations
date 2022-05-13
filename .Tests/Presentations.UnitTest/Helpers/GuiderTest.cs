using Xunit;
using OohelpWebApps.Presentations.Helpers;
using Xunit.Abstractions;

namespace Presentations.UnitTest.Helpers
{
    public class GuiderTest
    {
        private readonly ITestOutputHelper output;
        public GuiderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GuidToStringToGuid_ReturnEqual()
        {
            var guid = new System.Guid("3d74d23c-cf2f-4ba1-6845-08da334e7650");
            output.WriteLine(guid.ToString());

            string guidStr = Guider.ToStringFromGuid(guid);
            output.WriteLine(guidStr);

            System.Guid guidBack = Guider.ToGuidFromString(guidStr);
            output.WriteLine(guidBack.ToString());

            Assert.Equal(guid, guidBack);
        }
        [Fact]
        public void WrongLongStringToGuid_ReturnEqual()
        {
            var guid = System.Guid.NewGuid();
            output.WriteLine(guid.ToString());

            string guidStr = Guider.ToStringFromGuid(guid);
            output.WriteLine(guidStr);

            string wrongStr = guidStr + "iuy";
            output.WriteLine(wrongStr);

            System.Guid guidBack = Guider.ToGuidFromString(wrongStr);
            output.WriteLine(guidBack.ToString());

            Assert.Equal(guid, guidBack);
        }

        [Fact]
        public void WrongShortStringToGuid_Throws()
        {
            var guid = System.Guid.NewGuid();
            output.WriteLine(guid.ToString());

            string guidStr = Guider.ToStringFromGuid(guid);
            output.WriteLine(guidStr);

            string wrongStr = guidStr[..12];
            output.WriteLine(wrongStr);       
            

            Assert.Throws<System.IndexOutOfRangeException>(() => { System.Guid guidBack = Guider.ToGuidFromString(wrongStr); });
        }
        [Fact]
        public void EmptyStringToGuid_Throws()
        {            
            Assert.Throws<System.IndexOutOfRangeException>(() => { System.Guid guidBack = Guider.ToGuidFromString(string.Empty); });
        }
        [Fact]
        public void NullStringToGuid_Throws()
        {
            Assert.Throws<System.IndexOutOfRangeException>(() => { System.Guid guidBack = Guider.ToGuidFromString(null); });
        }
        [Fact]
        public void WrongShortStringToGuid_ReturnNotEqual()
        {
            var guid = System.Guid.NewGuid();
            output.WriteLine(guid.ToString());

            string guidStr = Guider.ToStringFromGuid(guid);
            output.WriteLine(guidStr);

            var ch = guidStr[0];
            var wrongStr = guidStr.Replace(ch, 'N');
            output.WriteLine(wrongStr);


            System.Guid guidBack = Guider.ToGuidFromString(wrongStr);
            output.WriteLine(guidBack.ToString());

            Assert.NotEqual(guid, guidBack);
        }
        [Fact]
        public void GuidEmptyToString_ReturnEmptyString()
        {
            var str = Guider.ToStringFromGuid(guid:System.Guid.Empty);
            output.WriteLine(str);

            Assert.Equal(str, string.Empty);
        }
    }
}
