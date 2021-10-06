using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteBackendEeM.Entidades;

namespace TesteBackendEeM.Persistencia.Contexto
{
    public class TesteBackendEeMDbContext : DbContext
    {

        public TesteBackendEeMDbContext(DbContextOptions<TesteBackendEeMDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Account> Account { get; set; }


        public DbDataReader ExecuteQuery(string query, params object[] parameters)
        {
            var concurrencyDetector = Database.GetService<IConcurrencyDetector>();

            using (concurrencyDetector.EnterCriticalSection())
            {
                var rawSqlCommand = Database
                    .GetService<IRawSqlCommandBuilder>()
                    .Build(query, parameters);

                var paramObject = new RelationalCommandParameterObject(Database.GetService<IRelationalConnection>(), rawSqlCommand.ParameterValues, null, null, null);

                return rawSqlCommand
                    .RelationalCommand
                    .ExecuteReader(paramObject)
                    .DbDataReader;
            }
        }

        public int ExecuteNonQuery(string query, params object[] parameters)
        {
            var concurrencyDetector = Database.GetService<IConcurrencyDetector>();

            using (concurrencyDetector.EnterCriticalSection())
            {
                var rawSqlCommand = Database
                    .GetService<IRawSqlCommandBuilder>()
                    .Build(query, parameters);

                var paramObject = new RelationalCommandParameterObject(Database.GetService<IRelationalConnection>(), rawSqlCommand.ParameterValues, null, null, null);

                return rawSqlCommand
                    .RelationalCommand
                    .ExecuteNonQuery(paramObject);
            }
        }

        public async Task BulkInsertAsync(IEnumerable<object> entities, CancellationToken cancellationToken)
        {
            var skip = 0;
            int linhasCommit = 100;
            IEnumerable<object> itensInsert;

            do
            {

                itensInsert = entities.Skip(skip).Take(100);
                await AddRangeAsync(itensInsert, cancellationToken);
                await SaveChangesAsync(cancellationToken);

                skip += skip + linhasCommit;

            } while (itensInsert.Any());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TesteBackendEeMDbContext).Assembly);
        }
    }
}
