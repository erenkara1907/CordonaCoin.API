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
    public class ReferenceManager : IReferenceService
    {
        private IReferenceDal _referenceDal;

        public ReferenceManager(IReferenceDal referenceDal)
        {
            _referenceDal = referenceDal;
        }

        public IResult Add(Reference reference)
        {
            _referenceDal.Add(reference);
            return new SuccessResult(Messages.ReferenceAdded);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Delete(Reference reference)
        {
            _referenceDal.Delete(reference);
            return new SuccessResult(Messages.ReferenceDeleted);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Reference> GetById(int referenceId)
        {
            return new SuccessDataResult<Reference>(_referenceDal.Get(r => r.Id == referenceId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IDataResult<Reference> GetByProfile(int profileId)
        {
            return new SuccessDataResult<Reference>(_referenceDal.Get(r => r.ProfileId == profileId));
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [PerformanceAspect(5)]
        public IDataResult<List<Reference>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Reference>>(_referenceDal.GetList().ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Reference>> GetListByProfile(int profileId)
        {
            return new SuccessDataResult<List<Reference>>(_referenceDal.GetList(r => r.ProfileId == profileId).ToList());
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult TransactionalOperation(Reference reference)
        {
            _referenceDal.Update(reference);
            _referenceDal.Add(reference);
            return new SuccessResult(Messages.ReferenceUpdated);
        }

        [SecuredOperation("Kurucu, Admin, Moderatör")]
        public IResult Update(Reference reference)
        {
            _referenceDal.Update(reference);
            return new SuccessResult(Messages.ReferenceUpdated);
        }
    }
}
