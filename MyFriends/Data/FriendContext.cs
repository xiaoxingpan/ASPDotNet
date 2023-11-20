using MyFriends.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyFriends.Data
{
    public class FriendContext : IdentityDbContext
    {
        public FriendContext(DbContextOptions<FriendContext> options) : base(options)
        {
        }
        public DbSet<Friend> Friends { get; set; }

        // to define the relation bwtween different entities and special requirements
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Data Source=MyFriends.db");
        // }
    }
    // public class FriendContext : DbContext
    // {
    //     public FriendContext(DbContextOptions<FriendContext> options) : base(options)
    //     {
    //     }
    //     public DbSet<Friend> Friends { get; set; }

    //     // to define the relation bwtween different entities and special requirements
    //     // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     // {
    //     //     optionsBuilder.UseSqlite("Data Source=MyFriends.db");
    //     // }
    // }
}