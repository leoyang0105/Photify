using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Photify.Domain.Identity;
using Photify.Infrastructure;

namespace Photify.Server.Configurations
{
    public class PhotifyContextSeed
    {
        static public async Task SeedAsync(IServiceProvider serviceProvider, PhotifyContext db)
        {
            if (!await db.Folders.AnyAsync())
            {
                await db.Folders.AddAsync(new Domain.Entities.Folder
                {
                    CreatedAt = DateTime.UtcNow,
                    Name = "/"
                });
                await db.SaveChangesAsync();
            }
        }
    }
}
