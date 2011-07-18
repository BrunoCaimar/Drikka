using System.Data;
using Drikka.Geo.Data.Contracts.TypesMapping;
using Drikka.Geo.Data.Converters;
using Drikka.Geo.Data.ExecutionPlain;
using Drikka.Geo.Data.Tests.Mappings;
using Drikka.Geo.Data.TypesMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace Drikka.Geo.Data.Tests.ExecutionPlain
{
    [TestClass]
    public class InsertPlainTest
    {
        [TestMethod]
        public void GetText_Returns_InsertText()
        {
            var mapping = new PersonMap();
            mapping.ExecuteMapping();

            var mapInt = new TypeMap(DbType.Int32,typeof(int),new GenericConverter());
            var mapString = new TypeMap(DbType.String,typeof(string),new GenericConverter());

            var mock = new Moq.Mock<ITypeRegister>();
            mock.Setup(x => x.Get(typeof (int))).Returns(mapInt);
            mock.Setup(x => x.Get(typeof(string))).Returns(mapString);

            var register = mock.Object;

            var insert = new InsertPlain(mapping, register);
            var text = insert.GetText();

            text.ToUpper().Should().Be("INSERT INTO PERSON (AGE, NAME, ID) VALUES (@AGE, @NAME, @ID)");
        }
    }
}
