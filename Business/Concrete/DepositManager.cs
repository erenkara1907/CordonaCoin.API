using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class DepositManager : IDepositService
    {
        private IDepositDal _depositDal;

        public DepositManager(IDepositDal depositDal)
        {
            _depositDal = depositDal;
        }


        public IResult Add(Deposit deposit)
        {
            _depositDal.Add(deposit);
            return new SuccessResult(Messages.DepositdAdded);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Delete(Deposit deposit)
        {
            _depositDal.Delete(deposit);
            return new SuccessResult(Messages.DepositDeleted);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Deposit> GetById(int depositId)
        {
            return new SuccessDataResult<Deposit>(_depositDal.Get(d => d.Id == depositId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Deposit> GetByUser(int userId)
        {
            return new SuccessDataResult<Deposit>(_depositDal.Get(d => d.UserId == userId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [PerformanceAspect(5)]
        public IDataResult<List<Deposit>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Deposit>>(_depositDal.GetList().ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Deposit>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<Deposit>>(_depositDal.GetList(d => d.UserId == userId).ToList());
        }


        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult TransactionalOperation(Deposit deposit)
        {
            _depositDal.Update(deposit);
            _depositDal.Add(deposit);
            return new SuccessResult(Messages.DepositUpdated);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Update(Deposit deposit)
        {
            _depositDal.Update(deposit);
            return new SuccessResult(Messages.DepositUpdated);
        }
    }
}
