using System;
using System.Collections.Generic;
using System.Text;
using TestOrigin.DAL.Repositories;
using TestOrigin.Domain.Entities;

namespace TestOrigin.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();
        GenericRepository<Tarjeta> Tarjetas();
        GenericRepository<Retiro> Retiros();
        GenericRepository<Balance> Balances();
    }
}
