using cadastro_clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace cadastro_clientes.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        
    }
}
