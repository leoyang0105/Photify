using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Photify.Domain;
using Photify.Domain.Identity;
using Photify.Infrastructure.Constants;
using Photify.Infrastructure.Extensions;

namespace Photify.Infrastructure
{
    public class IdentityContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public IdentityContext(DbContextOptions<IdentityContext> options, IMediator mediator = null) : base(options)
        {
            _mediator = mediator;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureIdentityContext(builder);
        }

        private static void ConfigureIdentityContext(ModelBuilder builder)
        {
            builder.Entity<Role>(b =>
            {
                b.ToTable(IdentityDbConstants.Role, IdentityDbConstants.Schema);
                b.Property(x => x.DisplayName).HasMaxLength(32);
                b.HasMany(x => x.UserRoles).WithOne().HasForeignKey(r => r.RoleId);
            });
            builder.Entity<RoleClaim>().ToTable(IdentityDbConstants.RoleClaim, IdentityDbConstants.Schema);
            builder.Entity<UserRole>().ToTable(IdentityDbConstants.UserRole, IdentityDbConstants.Schema);
            builder.Entity<User>(b =>
            {
                b.ToTable(IdentityDbConstants.User, IdentityDbConstants.Schema);
                b.HasIndex(x => x.UserName).IsUnique();
                b.HasMany(x => x.UserRoles).WithOne().HasForeignKey(r => r.UserId);
                b.HasMany(x => x.UserClaims).WithOne().HasForeignKey(r => r.UserId);
            });
            builder.Entity<UserLogin>().ToTable(IdentityDbConstants.UserLogin, IdentityDbConstants.Schema);
            builder.Entity<UserClaim>().ToTable(IdentityDbConstants.UserClaim, IdentityDbConstants.Schema);
            builder.Entity<UserToken>().ToTable(IdentityDbConstants.UserToken, IdentityDbConstants.Schema);
        }
        public virtual async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            if (_mediator != null)
                await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
