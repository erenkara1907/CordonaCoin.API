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
    public class WalletManager : IWalletService
    {
        private IWalletDal _walletDal;

        public WalletManager(IWalletDal walletDal)
        {
            _walletDal = walletDal;
        }

        public IResult Add(Wallet wallet)
        {
            _walletDal.Add(wallet);
            return new SuccessResult(Messages.WalletAdded);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Delete(Wallet wallet)
        {
            _walletDal.Delete(wallet);
            return new SuccessResult(Messages.WalletDeleted);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Wallet> GetById(int walletId)
        {
            return new SuccessDataResult<Wallet>(_walletDal.Get(w => w.Id == walletId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Wallet> GetByUser(int userId)
        {
            return new SuccessDataResult<Wallet>(_walletDal.Get(w => w.UserId == userId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [PerformanceAspect(5)]
        public IDataResult<List<Wallet>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Wallet>>(_walletDal.GetList().ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Wallet>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<Wallet>>(_walletDal.GetList(w => w.UserId == userId).ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult TransactionalOperation(Wallet wallet)
        {
            _walletDal.Update(wallet);
            _walletDal.Add(wallet);
            return new SuccessResult(Messages.WalletUpdated);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Update(Wallet wallet)
        {
            _walletDal.Update(wallet);
            return new SuccessResult(Messages.WalletUpdated);
        }
    }
}
