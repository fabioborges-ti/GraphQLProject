using GraphiQl;
using GraphQL.Types;
using GraphQLProject.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register repositories and types
builder.Services.RegisterRepositoryInterfaces();
builder.Services.AddGraphQLProjectServices();

// Configure the database context with SQL Server connection string
builder.Services.AddDbContext<GraphQLDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Bloco de c�digo para verificar e aplicar migra��es do Entity Framework Core.
// O "using" garante que o "scope" seja descartado corretamente.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<GraphQLDbContext>();

        // Aplica todas as migra��es pendentes.
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Use GraphiQL for an interactive GraphQL UI
app.UseGraphiQl("/graphql");

// Use the GraphQL endpoint
app.UseGraphQL<ISchema>();

app.UseAuthorization();
app.MapControllers();

app.Run();
