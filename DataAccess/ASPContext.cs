using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPProjekat.DomainLayer;
using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.CompilerServices;
namespace ASPProjekat.DataAccess
{
    public class ASPContext : DbContext
    {
        private readonly string _connectionString;
        public ASPContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ASPContext()
        {
            _connectionString = "Data Source=DESKTOP-54K3IOI\\SQLEXPRESS;Initial Catalog=ASPBookstore;Integrated Security=True;Trust Server Certificate=True";
        }
        public ASPContext(DbContextOptions options) : base(options)
        {
            _connectionString = "Data Source=DESKTOP-54K3IOI\\SQLEXPRESS;Initial Catalog=ASPBookstore;Integrated Security=True;Trust Server Certificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "user"
                }
            );
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "United Kingdom"
                }
            );
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    CountryId = 1,
                    Name = "London",
                    ZipCode = "zip1",
                },
                new City
                {
                    Id = 2,
                    CountryId = 1,
                    Name = "Manchester",
                    ZipCode = "zip2"
                }
            );
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "George Martin"
                },
                new Author
                {
                    Id = 2,
                    Name = "JK Rowling"
                }
            );
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "Best Books"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Fantasy Reader"
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Mark",
                    LastName = "White",
                    Email = "user@test.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("userpass"),
                    RoleId = 2
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jack",
                    LastName = "Black",
                    Email = "admin@test.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("adminpass"),
                    RoleId = 1
                }
            );
            modelBuilder.Entity<UseCase>().HasData(
                new UseCase
                {
                    Id = 1,
                    Name = "Search Books"
                },
                new UseCase
                {
                    Id = 2,
                    Name = "Search Users"
                },
                new UseCase
                {
                    Id = 3,
                    Name = "Search Orders"
                },
                new UseCase
                {
                    Id = 4,
                    Name = "Check Availability"
                },
                new UseCase
                {
                    Id = 5,
                    Name = "Register User"
                },
                new UseCase
                {
                    Id = 6,
                    Name = "Create Book"
                },
                new UseCase
                {
                    Id = 7,
                    Name = "Create Edition"
                },
                new UseCase
                {
                    Id = 8,
                    Name = "Create Order"
                },
                new UseCase
                {
                    Id = 9,
                    Name = "Update Book"
                },
                new UseCase
                {
                    Id = 10,
                    Name = "Update Edition"
                }
            );
            modelBuilder.Entity<RoleUseCase>().HasData(
                new RoleUseCase
                {
                    Id = 1,
                    RoleId = 1,
                    UseCaseId = 1
                },
                new RoleUseCase
                {
                    Id = 2,
                    RoleId = 1,
                    UseCaseId = 2
                },
                new RoleUseCase
                {
                    Id = 3,
                    RoleId = 1,
                    UseCaseId = 3
                },
                new RoleUseCase
                {
                    Id = 4,
                    RoleId = 1,
                    UseCaseId = 4
                },
                new RoleUseCase
                {
                    Id = 5,
                    RoleId = 1,
                    UseCaseId = 5
                },
                new RoleUseCase
                {
                    Id = 6,
                    RoleId = 1,
                    UseCaseId = 6
                },
                new RoleUseCase
                {
                    Id = 7,
                    RoleId = 1,
                    UseCaseId = 7
                },
                new RoleUseCase
                {
                    Id = 8,
                    RoleId = 1,
                    UseCaseId = 8
                },
                new RoleUseCase
                {
                    Id = 9,
                    RoleId = 1,
                    UseCaseId = 9
                },
                new RoleUseCase
                {
                    Id = 10,
                    RoleId = 1,
                    UseCaseId = 10
                },
                new RoleUseCase
                {
                    Id = 11,
                    RoleId = 2,
                    UseCaseId = 1
                },
                new RoleUseCase
                {
                    Id = 12,
                    RoleId = 1,
                    UseCaseId = 4
                },
                new RoleUseCase
                {
                    Id = 13,
                    RoleId = 1,
                    UseCaseId = 8
                }
            );
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id=1,
                    Name="Fantasy"
                },
                new Genre
                {
                    Id=2,
                    Name="Drama"
                },
                new Genre
                {
                    Id=3,
                    Name="Manga"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id=1,
                    Title="Harry Potter",
                    Isbn="harrypotterisbn",
                    Description="Harry Potter Wizard Prodigy",
                    AuthorId=2,
                    PublicationYear="2002",
                },
                new Book
                {
                    Id=2,
                    Title="Game Of Thrones",
                    Isbn="gotisbn",
                    Description="Game Of Thrones Book",
                    AuthorId=1,
                    PublicationYear="2003"
                },
                new Book
                {
                    Id=3,
                    Title="Attack On Titan",
                    Isbn="aotisbn",
                    Description = "Attack On Titan - Shingeki No Kyojin",
                    AuthorId = 1,
                    PublicationYear = "2017"
                }
            );
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id=1,
                    Path="default.png"
                }    
            );
            modelBuilder.Entity<Edition>().HasData(
                new Edition
                {
                    Id=1,
                    BookId=1,
                    ImageId=1,
                    PublisherId=1
                },
                new Edition
                {
                    Id = 2,
                    BookId = 1,
                    ImageId = 1,
                    PublisherId = 2
                },
                new Edition
                {
                    Id = 3,
                    BookId = 2,
                    ImageId = 1,
                    PublisherId = 1
                },
                new Edition
                {
                    Id = 4,
                    BookId = 3,
                    ImageId = 1,
                    PublisherId = 1
                },
                new Edition
                {
                    Id = 5,
                    BookId = 3,
                    ImageId = 1,
                    PublisherId = 2
                }
            );
            modelBuilder.Entity<Price>().HasData(
                new Price
                {
                    Id=1,
                    EditionId=1,
                    Value=65
                },
                new Price
                {
                    Id=2,
                    EditionId = 2,
                    Value = 70
                },
                new Price
                {
                    Id=3,
                    EditionId = 3,
                    Value = 70
                },
                new Price
                {
                    Id=4,
                    EditionId = 3,
                    Value = 45
                },
                new Price
                {
                    Id=5,
                    EditionId = 4,
                    Value = 43
                },
                new Price
                {
                    Id=6,
                    EditionId = 4,
                    Value = 40
                },
                new Price
                {
                    Id=7,
                    EditionId = 5,
                    Value = 36
                }
            );
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id=1,
                    CityId=1,
                    Name="Bookstore 1",
                    Address="Sesame Street 17"
                },
                new Store
                {
                    Id = 2,
                    CityId = 2,
                    Name = "Bookstore 2",
                    Address = "Pineapple Street 13"
                }
            );
            modelBuilder.Entity<StoreEdition>().HasData(
                new StoreEdition
                {
                    Id = 1,
                    StoreId =1,
                    EditionId=1
                },
                new StoreEdition
                {
                    Id = 2,
                    StoreId = 1,
                    EditionId = 2
                },
                new StoreEdition
                {
                    Id = 3,
                    StoreId = 1,
                    EditionId = 3
                },
                new StoreEdition
                {
                    Id = 4,
                    StoreId = 2,
                    EditionId = 1
                },
                new StoreEdition
                {
                    Id = 5,
                    StoreId = 1,
                    EditionId = 4
                },
                new StoreEdition
                {
                    Id = 6,
                    StoreId = 1,
                    EditionId = 5
                },
                new StoreEdition
                {
                    Id = 7,
                    StoreId = 1,
                    EditionId = 2
                }
            );
            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre
                {
                    Id = 1,
                    BookId =1,
                    GenreId=1
                },
                new BookGenre
                {
                    Id = 2,
                    BookId = 2,
                    GenreId = 1
                },
                new BookGenre
                {
                    Id = 3,
                    BookId = 2,
                    GenreId = 2
                },
                new BookGenre
                {
                    Id = 4,
                    BookId = 3,
                    GenreId = 1
                },
                new BookGenre
                {
                    Id = 5,
                    BookId = 3,
                    GenreId = 3
                }
            );
            modelBuilder.Entity<Wishlist>().HasData(
                new Wishlist
                {
                    Id = 1,
                    EditionId =1,
                    UserId=1
                },
                 new Wishlist
                 {
                     Id = 2,
                     EditionId = 2,
                     UserId = 1
                 },
                  new Wishlist
                  {
                      Id = 3,
                      EditionId = 4,
                      UserId = 1
                  }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id=1,
                    UserId=1
                }    
            );
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id=1,
                    OrderId=1,
                    EditionId=3,
                    PriceId=4
                },
                new OrderItem
                {
                    Id=2,
                    OrderId=1,
                    EditionId=5,
                    PriceId=7
                }
            );
        }
        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.ModifiedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<RoleUseCase> RolesUseCases { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreEdition> StoresEditions { get; set; }
        public DbSet<BookGenre> BooksGenres { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
