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
    public class DashboardManager : IDashboardService
    {
        private IDashboardDal _dashboardDal;

        public DashboardManager(IDashboardDal dashboardDal)
        {
            _dashboardDal = dashboardDal;
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Add(Dashboard dashboard)
        {
            _dashboardDal.Add(dashboard);
            return new SuccessResult(Messages.DashboardAdded);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Delete(Dashboard dashboard)
        {
            _dashboardDal.Delete(dashboard);
            return new SuccessResult(Messages.DashboardDeleted);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Dashboard> GetById(int dashboardId)
        {
            return new SuccessDataResult<Dashboard>(_dashboardDal.Get(d => d.Id == dashboardId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Dashboard> GetByUser(int userId)
        {
            return new SuccessDataResult<Dashboard>(_dashboardDal.Get(d => d.UserId == userId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [PerformanceAspect(5)]
        public IDataResult<List<Dashboard>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Dashboard>>(_dashboardDal.GetList().ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Dashboard>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<Dashboard>>(_dashboardDal.GetList(d => d.UserId == userId).ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult TransactionalOperation(Dashboard dashboard)
        {
            _dashboardDal.Update(dashboard);
            _dashboardDal.Add(dashboard);
            return new SuccessResult(Messages.DashboardUpdated);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Update(Dashboard dashboard)
        {
            _dashboardDal.Update(dashboard);
            return new SuccessResult(Messages.DashboardUpdated);
        }
    }
}
