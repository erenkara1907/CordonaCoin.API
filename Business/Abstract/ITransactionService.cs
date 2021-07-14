using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITransactionService
    {
        IDataResult<Transaction> GetById(int transactionId);
        IDataResult<Transaction> GetByUser(int userId);
        IDataResult<List<Transaction>> GetList();
        IDataResult<List<Transaction>> GetListByUser(int userId);
        IResult Add(Transaction transaction);
        IResult Delete(Transaction transaction);
        IResult Update(Transaction transaction);

        IResult TransactionalOperation(Transaction transaction);
    }
}
