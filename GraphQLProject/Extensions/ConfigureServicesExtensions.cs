using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Mutation;
using GraphQLProject.Query;
using GraphQLProject.Repositories;
using GraphQLProject.Schema;
using GraphQLProject.Type;

namespace GraphQLProject.Extensions
{

    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection RegisterRepositoryInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            return services;
        }

        public static IServiceCollection AddGraphQLProjectServices(this IServiceCollection services)
        {
            services.AddGraphQL(options => options.AddAutoSchema<ISchema>().AddSystemTextJson());

            services.AddScoped<MenuType>();
            services.AddScoped<CategoryType>();
            services.AddScoped<ReservationType>();

            services.AddScoped<MenuQuery>();
            services.AddScoped<CategoryQuery>();
            services.AddScoped<ReservationQuery>();
            services.AddScoped<RootQuery>();

            services.AddScoped<MenuMutation>();
            services.AddScoped<MenuInputType>();

            services.AddScoped<CategoryMutation>();
            services.AddScoped<CategoryInputType>();

            services.AddScoped<ReservationMutation>();
            services.AddScoped<ReservationInputType>();

            services.AddScoped<RootMutation>();

            services.AddScoped<ISchema, RootSchema>();

            return services;
        }
    }
}