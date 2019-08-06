using System.Collections.Generic;
using HotChocolate.Types;
using HotChocolate.Types.Filters;
using HotChocolate.Types.Relay;

namespace Demo
{
    public class QueryType: ObjectType
    {
        public ICollection<City> Cities => _cities ?? (_cities = new List<City>
        {
            new City("Amsterdam"),
            new City("Berlin"),
            new City("Paris"),
            new City("Zürich"),
        });

        private ICollection<City> _cities = null;


        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");

            descriptor.Field<QueryType>(q => q.Cities)
                .UsePaging<NonNullType<ObjectType<City>>>()
                .UseFiltering();
        }
    }
}
