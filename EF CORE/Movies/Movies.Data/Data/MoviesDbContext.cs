using Microsoft.EntityFrameworkCore;
using Movies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Player> Players { get; set; }
        //private DbSet<MoviesPlayer> MoviesPlayers { get; set; }

        public MoviesDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(movie => movie.Name)
                                                .IsRequired()
                                                .HasMaxLength(250);

            modelBuilder.Entity<Movie>().HasOne(movie => movie.Director)
                                        .WithMany(director => director.Movies)
                                        .HasForeignKey(movie => movie.DirectorId);


            //ilişkileri biz yapmak istiyoruz
            //haskey ile primary key'i tanımlarız
            //bizim ara tablomuzda 2 tablonun da primary key'i olduğundan onları belirttik
            //primary key'ler tanımlandıysa foreign key'ler de tanımlanmalı
            modelBuilder.Entity<MoviesPlayer>().HasKey("MovieId", "PlayerId");

            modelBuilder.Entity<Movie>().HasMany(movie => movie.Players)//her filmde birçok oyuncu var
                                        .WithOne(movie => movie.Movie)//her oyuncu bir filme sahiptir 
                                        .HasForeignKey(movie => movie.MovieId);//foreign key 'i belirttik

            modelBuilder.Entity<Player>().HasMany(player => player.Movies)//her oyuncunun birçok filmi var
                                        .WithOne(player => player.Player)//her film bir oyuncuya sahiptir 
                                        .HasForeignKey(player => player.PlayerId);//foreign key 'i belirttik

            modelBuilder.Entity<Director>().HasData(new Director { Id = 1, FirstName = "Nuri Bilge", LastName = "Ceylan" });//hasdata test için vardır
            modelBuilder.Entity<Player>().HasData(new Player { Id = 1, FirstName = "Doğu", LastName = "Demirkol" });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Name = "Ahlat Ağacı", DirectorId = 1 });
            modelBuilder.Entity<MoviesPlayer>().HasData(new MoviesPlayer { MovieId=1, PlayerId=1, Role="Sinan Karasu -> Bir öğretmen mezunu"});
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =  "Data Source=YALCINSELCUK-AC;Integrated Security=True;Initial Catalog=moviesSample;" +
                "                       Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "                       MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
