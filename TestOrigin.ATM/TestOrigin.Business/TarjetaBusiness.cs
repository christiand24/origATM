using System;
using TestOrigin.DAL.Repositories;
using TestOrigin.Domain.Interfaces;
using TestOrigin.Domain.Results;
using System.Linq;
using TestOrigin.Domain.Mensajes;
using TestOrigin.Domain.Const;
using TestOrigin.DAL;
using TestOrigin.Domain.Exceptions;
using TestOrigin.Domain.Entities;

namespace TestOrigin.Business
{
    public class TarjetaBusiness : BaseBusiness, ITarjetaBusiness
    {
        public TarjetaBusiness(IUnitOfWork uow): base(uow)
        {
        }

        public Tarjeta Traer(int tarjetaId)
        {
            return unitOfWork.Tarjetas().Get(tarjetaId);
        }

        public BusinessResult EsTarjetaOperativa(string numeroTarjeta)
        {
            var tarjeta = unitOfWork.Tarjetas().List(i => i.Numero == numeroTarjeta).FirstOrDefault();

            var result = new BusinessResult();

            result.Codigo = tarjeta != null && !tarjeta.Bloqueada ? 0 : 1;
            result.Mensaje = tarjeta == null ? MsjErrores.ERROR_TJ_NO_EXISTE : "";
            result.Mensaje = tarjeta != null && tarjeta.Bloqueada ? MsjErrores.ERROR_TJ_BLQ : result.Mensaje;
            return result;
        }

        public int ValidarPIN(string numeroTarjeta, int PIN)
        {
            var tarjeta = unitOfWork.Tarjetas().List(i => i.Numero == numeroTarjeta).FirstOrDefault();
            if (tarjeta != null)
            {
                if (tarjeta.PIN == PIN)
                {
                    tarjeta.Reintentos = 0;
                    unitOfWork.Tarjetas().Save(tarjeta);
                    unitOfWork.Save();
                    return tarjeta.TarjetaId;
                }
                else
                {
                    tarjeta.Reintentos++;
                }

                tarjeta.Bloqueada = tarjeta.Reintentos >= Sistema.MAX_INTENTOS_PIN;

                unitOfWork.Tarjetas().Save(tarjeta);
                unitOfWork.Save();

                if (tarjeta.Bloqueada)
                    throw new TarjetaBloqueadaException();
            }

            return -1;
        }
    }
}
