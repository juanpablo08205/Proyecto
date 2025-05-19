using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Data
{
    public class BDDirectorioDBContext : DbContext
    {
        public BDDirectorioDBContext(
                   DbContextOptions<BDDirectorioDBContext> options
                                    ) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}