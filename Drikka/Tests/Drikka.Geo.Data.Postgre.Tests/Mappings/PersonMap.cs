using Drikka.Geo.Data.Mapping;
using Drikka.Geo.Tests.Common.Entities;

namespace Drikka.Geo.Data.Postgre.Tests.Mappings
{
    public class PersonMap : Mapper<Person>
    {
        public override void ExecuteMapping()
        {
            SetTableName("Person");

            MapIdentifier(x => x.Id, "ID");
            MapAttribute(x => x.Name, "Name");
            MapAttribute(x => x.Age, "Age");
        }
    }
}
