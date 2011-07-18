using Drikka.Geo.Tests.Common.Entities;

namespace Drikka.Geo.Data.Mapping.Tests.Unit
{
    public class PersonMap : Mapper<Person>
    {
        public override void ExecuteMapping()
        {
            MapIdentifier(x => x.Id, "ID");
            MapAttribute(x => x.Name, "Nome");
        }
    }
}
