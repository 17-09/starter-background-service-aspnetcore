using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackgroundServiceStarter
{
    public class MigrationService :  IHostedService
    {
        // We need to inject the IServiceProvider so we can create 
        // the scoped service, DbContext
        private readonly IServiceProvider _serviceProvider;
        public MigrationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Create a new scope to retrieve scoped services
            using(var scope = _serviceProvider.CreateScope())
            {
                // Get the DbContext instance
                // var myDbContext = scope.ServiceProvider.GetRequiredService<DbContext>();

                //Do the migration asynchronously
                // await myDbContext.Database.MigrateAsync();
            }

            return Task.CompletedTask;
        }

        // noop
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}