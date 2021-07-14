using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<City> GetById(int cityId);
        IDataResult<City> GetByCountry(int countryId);
        IDataResult<List<City>> GetList();
        IDataResult<List<City>> GetListByCountry(int countryId);
        IResult Add(City city);
        IResult Delete(City city);
        IResult Update(City city);

        IResult TransactionalOperation(City city);
    }
}
