using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQL(s =>
            {
                ISchemaBuilder builder = SchemaBuilder.New()
                    .EnableRelaySupport()
                    .AddQueryType<QueryType>()
                    .AddServices(s);

                return builder.Create();
            }, QueryOptions);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseGraphQL();

        }

        protected QueryExecutionOptions QueryOptions =>
            new QueryExecutionOptions
            {
                TracingPreference = TracingPreference.Always
            };
    }
}
