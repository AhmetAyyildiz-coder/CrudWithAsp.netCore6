using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace crud.Models;

public class IslemDbModel:DbContext
{
    public IslemDbModel(DbContextOptions<IslemDbModel> options) : base(options)
    {
    }

    public DbSet<Islem> Islemler { get; set; }
}