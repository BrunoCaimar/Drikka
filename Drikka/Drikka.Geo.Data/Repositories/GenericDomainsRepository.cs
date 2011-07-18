using System;
using System.Collections;
using Drikka.Geo.Data.Contracts.Repository;

namespace Drikka.Geo.Data.Repositories
{
    public class GenericDomainsRepository : IDomainRepository
    {
        
        public object Save(object domain)
        {
            throw new NotImplementedException();
        }

        public object Update(object domain)
        {
            throw new NotImplementedException();
        }

        public void Delete(object domain)
        {
            throw new NotImplementedException();
        }

        public object Get(object id)
        {
            throw new NotImplementedException();
        }

        public IList GetAll(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
