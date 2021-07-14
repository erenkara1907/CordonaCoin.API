using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWalletService
    {
        IDataResult<Wallet> GetById(int walletId);
        IDataResult<Wallet> GetByUser(int userId);
        IDataResult<List<Wallet>> GetList();
        IDataResult<List<Wallet>> GetListByUser(int userId);
        IResult Add(Wallet wallet);
        IResult Delete(Wallet wallet);
        IResult Update(Wallet wallet);

        IResult TransactionalOperation(Wallet wallet);
    }
}
