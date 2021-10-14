using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Data;

namespace Tasks.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Themes.Any())
                {
                    return;
                }

                context.Themes.AddRange(
                    new Theme
                    {
                        Name = "Theme1"
                    },
                    new Theme
                    {
                        Name = "Theme2"
                    },
                    new Theme
                    {
                        Name = "Theme3"
                    },
                    new Theme
                    {
                        Name = "Theme4"
                    },
                    new Theme
                    {
                        Name = "Theme5"
                    }
                ) ;
                context.SaveChanges();
            }
    }
}
}
