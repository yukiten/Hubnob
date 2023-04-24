using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Hubnob.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Guild> Guilds { get; set; }
        public DbSet<GuildMember> GuildMembers { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<GuildRole> GuildRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Set up one-to-many relationship between Guild and GuildMember
            builder.Entity<Guild>()
                .HasMany(g => g.GuildMembers)
                .WithOne(gm => gm.Guild)
                .HasForeignKey(gm => gm.GuildId)
                .OnDelete(DeleteBehavior.NoAction); // Add this line

            // Set up one-to-many relationship between ApplicationUser and GuildMember
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.GuildMemberships)
                .WithOne(gm => gm.User)
                .HasForeignKey(gm => gm.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Add this line

            builder.Entity<UserFollower>()
            .HasKey(uf => new { uf.FollowerId, uf.FollowingId });

            builder.Entity<UserFollower>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserFollower>()
                .HasOne(uf => uf.Following)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<GuildRole>()
                .HasMany(gr => gr.GuildMembers)
                .WithOne(gm => gm.GuildRole)
                .HasForeignKey(gm => gm.GuildRoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}