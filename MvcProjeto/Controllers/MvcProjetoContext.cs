using MvcProjeto.Models;
using System.Data.Entity;
using System.Reflection.Emit;

namespace MvcProjeto.Controllers
{
    public class MvcProjetoContext : DbContext
    {
        public MvcProjetoContext() : base("name=MvcProjetoBase")
        {

            DropCreateDatabaseIfModelChanges<MvcProjetoContext> initializer = new DropCreateDatabaseIfModelChanges<MvcProjetoContext>();
            Database.SetInitializer(initializer);
           
           
        }
        public System.Data.Entity.DbSet<Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Models.Chamado> Chamados { get; set; }

        public System.Data.Entity.DbSet<MvcProjeto.Models.Tipo> Tipoes { get; set; }
    }
}