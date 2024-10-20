using Microsoft.EntityFrameworkCore;
using MyAPI.Models;

public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    //public DbSet<JogosAbstract> Jogos { get; set; }
    public DbSet<NintendoDS> DsJogos { get; set; }
    public DbSet<NintendoWii> WiiJogos { get; set; }
    public DbSet<Playstation3> Play3Jogos { get; set; }
    public DbSet<SonyPSP> PspJogos { get; set; }
    public DbSet<Xbox360> XboxJogos { get; set; }

    //Mapear cada subclasse para sua própria tabela (estratégia Table Per Type - TPT)

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define herança usando TPT (Table per Type)
        modelBuilder.Entity<NintendoDS>().ToTable("nintendods");
        modelBuilder.Entity<NintendoWii>().ToTable("nintendowii");
        modelBuilder.Entity<Playstation3>().ToTable("playstation3");
        modelBuilder.Entity<SonyPSP>().ToTable("sonypsp");
        modelBuilder.Entity<Xbox360>().ToTable("xbox360");
    }
}
