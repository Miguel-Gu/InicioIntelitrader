using IntelitraderAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IntelitraderAPI.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                .GetService<IntelitraderContext>();
                if (serviceDb != null)
                {
                    serviceDb.Database.Migrate();
                }
            }
        }
    }
}