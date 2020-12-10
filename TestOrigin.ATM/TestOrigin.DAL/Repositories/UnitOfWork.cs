using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestOrigin.Domain.Entities;
using TestOrigin.Domain.Interfaces;

namespace TestOrigin.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private ATMContext context;
        private GenericRepository<Tarjeta> tarjetas { get; set; }
        private GenericRepository<Retiro> retiros { get; set; }
        private GenericRepository<Balance> balances { get; set; }

        public UnitOfWork(ATMContext context)
        {
            this.context = context;
        }

        public GenericRepository<Tarjeta> Tarjetas()
        {
            if (this.tarjetas == null)
            {
                this.tarjetas = new GenericRepository<Tarjeta>(context);
            }
            return tarjetas;
        }

        public GenericRepository<Retiro> Retiros()
        {
            if (this.retiros == null)
            {
                this.retiros = new GenericRepository<Retiro>(context);
            }
            return retiros;
        }

        public GenericRepository<Balance> Balances()
        {
            if (this.balances == null)
            {
                this.balances = new GenericRepository<Balance>(context);
            }
            return balances;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
