using System;
using System.Collections.Generic;
using System.Text;
using TestOrigin.DAL.Repositories;
using TestOrigin.Domain.Interfaces;
using System.Linq;
using TestOrigin.Domain.Mensajes;
using TestOrigin.Domain.Entities;
using TestOrigin.DAL;
using TestOrigin.Domain.Exceptions;

namespace TestOrigin.Business
{
    public class OperacionesBusiness : BaseBusiness, IOperacionesBusiness
    {
        public OperacionesBusiness(IUnitOfWork uow) : base(uow)
        {
        }

        public void InsertarBalance(int tarjetId)
        {
            if (unitOfWork.Tarjetas().Get(tarjetId) == null) throw new Exception(MsjErrores.ERROR_TJ_NO_EXISTE); 
            unitOfWork.Balances().Save(new Balance() { TarjetaId = tarjetId, FechaOperacion = DateTime.Now });
            unitOfWork.Save();
        }

        public void InsertarRetiro(int tarjetId, decimal cantidadRetirada)
        {
            var tarjeta = unitOfWork.Tarjetas().List(i => i.TarjetaId == tarjetId).FirstOrDefault();
            if (tarjeta == null) throw new Exception(MsjErrores.ERROR_TJ_NO_EXISTE);

            if (tarjeta.Balance < cantidadRetirada)
            {
                throw new BalanceExcedidoException();
            }

            unitOfWork.Retiros().Save(new Retiro()
            {
                CantidadOperada = cantidadRetirada,
                TarjetaId = tarjetId,
                FechaOperacion = DateTime.Now
            });

            tarjeta.Balance -= cantidadRetirada;
            unitOfWork.Tarjetas().Save(tarjeta);
            unitOfWork.Save();
        }
    }
}
