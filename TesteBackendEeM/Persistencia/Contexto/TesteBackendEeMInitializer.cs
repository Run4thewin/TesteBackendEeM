namespace TesteBackendEeM.Persistencia.Contexto
{
    public class TesteBackendEeMInitializer
    {
        public static void Initialize(TesteBackendEeMDbContext context)
        {
            var initializer = new TesteBackendEeMInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(TesteBackendEeMDbContext context)
        {
            context.Database.EnsureCreated();

        }

    }
}
