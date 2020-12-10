using System;
using System.Collections.Generic;
using System.Text;
using TestOrigin.DAL;
using TestOrigin.DAL.Repositories;
using TestOrigin.Domain.Interfaces;

namespace TestOrigin.Business
{
    public abstract class BaseBusiness
    {
        protected IUnitOfWork unitOfWork;

        public BaseBusiness(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

    }
}
