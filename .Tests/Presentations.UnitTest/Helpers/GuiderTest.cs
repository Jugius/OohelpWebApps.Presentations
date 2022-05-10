using Xunit;
using OohelpWebApps.Presentations.Helpers;
using Xunit.Abstractions;
using OohelpWebApps.Presentations.Domain.Data;
using OohelpWebApps.Presentations.Domain.Common.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;

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
            var guid = new System.Guid("5c9a3035-3cbc-4961-a59b-73b2c52865ed");
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
            const string wrongStr = "";
            Assert.Throws<System.IndexOutOfRangeException>(() => { System.Guid guidBack = Guider.ToGuidFromString(wrongStr); });
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
        [Fact]
        public void JsonConvert()
        {
            BoardDto[] boards = new BoardDto[]
        {
            new BoardDto {                
                Supplier = "РТМ", Code ="M06TA0751B",
                Region = "Житомирская",
                City ="Житомир", Address ="Трасса M-06, Киев-Житомир, 75,100",
                Type = "Арка", Size = "3x18", Side = 'A',
                Latitude =50.3895462639, Longitude =29.4901639223, Angle = 75,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/0d01c3b4-18c7-4800-900c-ee61e215b28c.jpg",
                Condition = BoardCondition.Free,
                IconStyle = IconStyle.Billboard,
                IconColor = "eb17c4",
                Price = 20000,
            },
            new BoardDto {
                Supplier = "РТМ", Code ="M03TA0456B",
                Region = "Киевская",
                City ="Борисполь", Address ="Трасса M-03, Киев - Харьков, 45,650",
                Type = "Арка", Size = "3x18", Side = 'A',
                Latitude =50.3172779486, Longitude =31.0401856899, Angle = 290,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/ae9d515f-bd0b-429f-bb53-4b857bfbdc78.jpg",
                Condition = BoardCondition.Free,
                IconStyle = IconStyle.House,
                IconColor = "33eb17",
                Price = 20000,
            },
            new BoardDto {
                Supplier = "РТМ", Code ="M05TA0768A",
                Region = "Киевская",
                City ="Белая Церковь", Address ="Трасса M-05, Киев-Одесса, 76,800",
                Type = "Арка", Size = "3x18", Side = 'A',
                Latitude =49.8607770802, Longitude =30.1644122601, Angle = 200,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/c5251675-fda1-4916-92fd-7b52acfa579b.jpg",
                Condition = BoardCondition.Free,
                IconStyle = IconStyle.Arrow,
                IconColor = "f50521",
                Price = 20000,
            }
        };
            JsonSerializerOptions jOptions = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            var str = System.Text.Json.JsonSerializer.Serialize(new { Boards = boards }, jOptions);

            output.WriteLine(str);
        }
    }
}
