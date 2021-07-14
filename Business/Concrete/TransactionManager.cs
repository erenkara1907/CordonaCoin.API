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
    public class TransactionManager : ITransactionService
    {
        private ITransactionDal _transactionDal;

        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Add(Transaction transaction)
        {
            _transactionDal.Add(transaction);
            return new SuccessResult(Messages.TransactionAdded);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Delete(Transaction transaction)
        {
            _transactionDal.Delete(transaction);
            return new SuccessResult(Messages.TransactionDeleted);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Transaction> GetById(int transactionId)
        {
            return new SuccessDataResult<Transaction>(_transactionDal.Get(t => t.Id == transactionId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Transaction> GetByUser(int userId)
        {
            return new SuccessDataResult<Transaction>(_transactionDal.Get(t => t.UserId == userId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [PerformanceAspect(5)]
        public IDataResult<List<Transaction>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetList().ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Transaction>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetList(t => t.UserId == userId).ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult TransactionalOperation(Transaction transaction)
        {
            _transactionDal.Update(transaction);
            _transactionDal.Add(transaction);
            return new SuccessResult(Messages.TransactionUpdated);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Update(Transaction transaction)
        {
            _transactionDal.Update(transaction);
            return new SuccessResult(Messages.TransactionUpdated);
        }
    }
}
