using Drikka.Geo.Data.Mapping;
using Drikka.Geo.Tests.Common.Entities;

namespace Drikka.Geo.Data.Tests.Mappings
{
    public class CityMap : Mapper<City>
    {
        public override void ExecuteMapping()
        {
            SetTableName("City");
            MapIdentifier(x => x.Id, "id");
            MapAttribute(x => x.Name, "name");
            MapAttribute(x => x.State, "state");
        }
    }
}
