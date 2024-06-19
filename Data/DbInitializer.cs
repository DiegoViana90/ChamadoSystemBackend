using System;
using System.Linq;
using ChamadoSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ChamadoSystemBackend.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    // Verifica se já existem usuários
                    if (context.Users.Any())
                    {
                        return; // Se existir, não faz nada
                    }

                    // Caso não exista nenhum usuário, adiciona um usuário padrão
                    context.Users.Add(new User
                    {
                        Email = "admin@primeplus.com.br",
                        Password = "admin",
                        Role = "support"
                    });

                    context.SaveChanges(); 
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<DbInitializer>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
