namespace PetroTech.Data.Infa
{
    public class DbFactory : Disposable, IDbFactory
    {
        private PetroTechDbContext dbContext;

        public PetroTechDbContext Init()
        {
            return dbContext ?? (dbContext = new PetroTechDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}