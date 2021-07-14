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
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult(Messages.CityAdded);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.CityDeleted);
        }


        public IDataResult<City> GetByCountry(int countryId)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.CountryId == countryId));
        }

        public IDataResult<City> GetById(int cityId)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == cityId));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<City>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<City>>(_cityDal.GetList().ToList());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<City>> GetListByCountry(int countryId)
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetList(c => c.CountryId == countryId).ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult TransactionalOperation(City city)
        {
            _cityDal.Update(city);
            _cityDal.Add(city);
            return new SuccessResult(Messages.CityUpdated);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(Messages.CityUpdated);
        }
    }
}
