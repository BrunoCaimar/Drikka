using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Mapping;
using Drikka.Geo.Tests.Common.Entities;

namespace Drikka.Geo.Data.Tests.Mappings
{
    public class FormatedPersonMap : Mapper<Person2>
    {
        public override void ExecuteMapping()
        {
            SetTableName("Person");

            MapIdentifier(x => x.Id, "ID");
            MapAttribute(x => x.Name, "Name").Formatters.Add(DmlType.Select, "AsBinary({0}) as Name");
            MapAttribute(x => x.Age, "Age");
        }
    }
}
