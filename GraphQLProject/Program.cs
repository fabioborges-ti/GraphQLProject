using GraphQL;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using GraphQLProject.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register repositories and types
builder.Services.RegisterRepositoryInterfaces();
builder.Services.AddGraphQLProjectServices();

// Adicionar GraphQL Server
builder.Services.AddGraphQL(b => b
    .AddSystemTextJson()
    .AddSchema<GraphQLProject.Schema.RootSchema>()
    .AddGraphTypes());

// Configure the database context with SQL Server connection string
builder.Services.AddDbContext<GraphQLDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Bloco de código para verificar e aplicar migrações do Entity Framework Core.
// O "using" garante que o "scope" seja descartado corretamente.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<GraphQLDbContext>();

        // Aplica todas as migrações pendentes.
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogWarning(ex, "An error occurred while migrating the database.");
    }
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Configurar GraphQL
app.UseGraphQL<GraphQLProject.Schema.RootSchema>("/graphql");

// Interface GraphiQL para desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseGraphQLGraphiQL("/graphiql", new GraphiQLOptions
    {
        GraphQLEndPoint = "/graphql"
    });
}

// Use the GraphQL endpoint
app.UseGraphQL<ISchema>();

app.UseAuthorization();
app.MapControllers();

app.Run();
