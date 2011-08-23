using System;
using System.Data;
using Drikka.Geo.Data.Contracts.TypesMapping;
using Drikka.Geo.Data.Converters;
using Drikka.Geo.Data.ExecutionPlan;
using Drikka.Geo.Data.Tests.Mappings;
using Drikka.Geo.Data.TypesMapping;
using Drikka.Geo.Tests.Common.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace Drikka.Geo.Data.Tests.ExecutionPlain
{
    [TestClass]
    public class UpdatePlanTest
    {
        [TestMethod]
        //[Ignore]
        public void GetText_Returns_UpdateText()
        {
            var person = new Person();
            var mapping = new PersonMap();
            mapping.ExecuteMapping();

            var mapInt = new TypeMap(DbType.Int32,typeof(int),new GenericConverter());
            var mapString = new TypeMap(DbType.String,typeof(string),new GenericConverter());

            var mock = new Moq.Mock<ITypeRegister>();
            mock.Setup(x => x.Get(typeof (int))).Returns(mapInt);
            mock.Setup(x => x.Get(typeof(string))).Returns(mapString);

            var dbparam = new Moq.Mock<IDbDataParameter>();
            Func<IDbDataParameter> func = () => dbparam.Object;

            var register = mock.Object;

            var insert = new UpdatePlan(mapping, register);
            var text = insert.CreatePlanParameter(func, person);

            text.SqlText.ToUpper().Should().Be("UPDATE PERSON SET NAME = @NAME, AGE = @AGE WHERE ID = @ID");
            text.Parameters.Count.Should().Be(3);
        }
    }
}
