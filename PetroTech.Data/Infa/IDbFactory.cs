using System;

namespace PetroTech.Data.Infa
{
    public interface IDbFactory : IDisposable
    {
        PetroTechDbContext Init();
    }
}