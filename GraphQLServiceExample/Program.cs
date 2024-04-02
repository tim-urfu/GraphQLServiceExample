
using GraphQLServiceExample.GraphQL;

namespace GraphQLServiceExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddInMemorySubscriptions();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
            }

            app.UseAuthorization();

            app.UseRouting();

            app.UseWebSockets();

            app.MapControllers(); 
            app.MapGraphQL();
            app.MapBananaCakePop("/graphql/ui");

            app.Run();
        }
    }
}
