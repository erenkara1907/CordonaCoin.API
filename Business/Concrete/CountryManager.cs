using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
    public class CountryManager : ICountryService
    {
        private ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Add(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult(Messages.CountryAdded);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult(Messages.CountryDeleted);
        }

        public IDataResult<Country> GetById(int countryId)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(c => c.Id == countryId));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Country>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Country>>(_countryDal.GetList().ToList());
        }

        public IResult TransactionalOperation(Country country)
        {
            _countryDal.Update(country);
            _countryDal.Add(country);
            return new SuccessResult(Messages.CountryUpdated);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(Messages.CountryUpdated);
        }
    }
}
