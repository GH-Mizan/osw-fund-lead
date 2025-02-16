using Abp.Zero.EntityFrameworkCore;
using OSW.Authorization.Roles;
using OSW.Authorization.Users;
using OSW.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using OSW.Entities;

namespace OSW.EntityFrameworkCore;

public class OSWDbContext : AbpZeroDbContext<Tenant, Role, User, OSWDbContext>
{
    /* Define a DbSet for each entity of the application */

    public OSWDbContext(DbContextOptions<OSWDbContext> options)
        : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<MemberDetail> MemberDetails { get; set; }
    public DbSet<Desgnation> Desgnations { get; set; }
}
