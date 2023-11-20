using MyFriends.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyFriends.Data.Configurations
{
    public class FriendConfiguration
    {
        // relation between different entities
        // special requirements eg: rename a column
        // sqlite doesn't have foreign key constraints
        // Fluent API can be used to define addtionnal requirements
        // public void Configure(EntityTypeBuilder<Friend> builder)
        // {
        //     builder.ToTable("Friend");
        //     builder.Property(f => f.Name).IsRequired().HasMaxLength(50);
        //     builder.Property(f => f.Age).IsRequired().HasMaxLength(3);
        // }
    }
}