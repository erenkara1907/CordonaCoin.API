using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDepositService
    {
        IDataResult<Deposit> GetById(int depositId);
        IDataResult<Deposit> GetByUser(int userId);
        IDataResult<List<Deposit>> GetList();
        IDataResult<List<Deposit>> GetListByUser(int userId);
        IResult Add(Deposit deposit);
        IResult Delete(Deposit deposit);
        IResult Update(Deposit deposit);

        IResult TransactionalOperation(Deposit deposit);
    }
}
