using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProfileService
    {
        IDataResult<Profile> GetById(int profileId);
        IDataResult<Profile> GetByUser(int userId);
        IDataResult<Profile> GetByCountry(int countryId);
        IDataResult<Profile> GetByCity(int cityId);

        IDataResult<List<Profile>> GetList();
        IDataResult<List<Profile>> GetListByUser(int userId);
        IResult Add(Profile profile);
        IResult Delete(Profile profile);
        IResult Update(Profile profile);

        IResult TransactionalOperation(Profile profile);
    }
}
