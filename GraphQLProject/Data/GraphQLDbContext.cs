using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

public class GraphQLDbContext : DbContext
{
    public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options) { }

    public DbSet<MenuModel> Menus { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ReservationModel> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MenuSeedData.SeedMenus(modelBuilder);
        CategorySeedData.SeedCategories(modelBuilder);
        ReservationSeedData.SeedReservations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    public static class MenuSeedData
    {
        public static void SeedMenus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuModel>().HasData(
                new MenuModel
                {
                    Id = 1,
                    Name = "Pizza Margherita",
                    Description = "Pizza tradicional com molho de tomate, mussarela e manjericão fresco",
                    Price = 45.90,
                    CategoryId = 1
                },
                new MenuModel
                {
                    Id = 3,
                    Name = "Lasanha Bolonhesa",
                    Description = "Lasanha tradicional com molho bolonhesa, bechamel e queijo gratinado",
                    Price = 38.75,
                    CategoryId = 1
                },
                new MenuModel
                {
                    Id = 6,
                    Name = "Bife Ancho Grelhado",
                    Description = "Corte especial de bife ancho grelhado, acompanhado de batatas rústicas e molho chimichurri",
                    Price = 59.90,
                    CategoryId = 2
                },
                new MenuModel
                {
                    Id = 2,
                    Name = "Salada Caesar",
                    Description = "Alface romana, croutons, parmesão e molho caesar tradicional",
                    Price = 28.90,
                    CategoryId = 3
                },
                new MenuModel
                {
                    Id = 4,
                    Name = "Salmão Grelhado",
                    Description = "Filé de salmão grelhado com legumes salteados e molho de ervas",
                    Price = 65.00,
                    CategoryId = 4
                },
                new MenuModel
                {
                    Id = 5,
                    Name = "Tiramisù",
                    Description = "Sobremesa italiana com café, mascarpone e cacau em pó",
                    Price = 18.90,
                    CategoryId = 5
                }
            );
        }
    }

    public static class CategorySeedData
    {
        public static void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel
                {
                    Id = 1,
                    Name = "Massas",
                    ImageUrl = "massas.jpg"
                },
                new CategoryModel
                {
                    Id = 2,
                    Name = "Carnes",
                    ImageUrl = "carnes.jpg"
                },
                new CategoryModel
                {
                    Id = 3,
                    Name = "Saladas",
                    ImageUrl = "saladas.jpg"
                },
                new CategoryModel
                {
                    Id = 4,
                    Name = "Peixes",
                    ImageUrl = "peixes.jpg"
                },
                new CategoryModel
                {
                    Id = 5,
                    Name = "Sobremesas",
                    ImageUrl = "sobremesas.jpg"
                }
            );
        }
    }

    public static class ReservationSeedData
    {
        public static void SeedReservations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationModel>().HasData(
                new ReservationModel
                {
                    Id = 1,
                    CustomerName = "João Silva",
                    Email = "joao.silva@email.com",
                    PhoneNumber = "11999999999",
                    PartySize = 2,
                    SpecialRequest = "Mesa próxima à janela",
                    ReservationDate = new DateTime(2025, 8, 30, 19, 0, 0)
                },
                new ReservationModel
                {
                    Id = 2,
                    CustomerName = "Maria Oliveira",
                    Email = "maria.oliveira@email.com",
                    PhoneNumber = "11988888888",
                    PartySize = 4,
                    SpecialRequest = "Cadeira para criança",
                    ReservationDate = new DateTime(2025, 8, 31, 20, 30, 0)
                }
            );
        }
    }
}