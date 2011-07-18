using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drikka.Geo.Data.Query
{
    class Class1
    {
        public string Nome { get; set; }

        public Class1(IQuery<Class1> query)
        {
            query.Where(x => x.Nome).Equal("Nome")
                .And(x => x.Nome).Equal("Nome de Novo")
                .And().Brackets(w => w(x => x.Nome).Equal("Nome").Or(x=> x.Nome).NotEqual("Bianco"));

            
        }

    }
}
