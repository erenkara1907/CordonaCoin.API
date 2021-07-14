using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDashboardService
    {
        IDataResult<Dashboard> GetById(int dashboardId);
        IDataResult<Dashboard> GetByUser(int userId);
        IDataResult<List<Dashboard>> GetList();
        IDataResult<List<Dashboard>> GetListByUser(int userId);
        IResult Add(Dashboard dashboard);
        IResult Delete(Dashboard dashboard);
        IResult Update(Dashboard dashboard);

        IResult TransactionalOperation(Dashboard dashboard);
    }
}
