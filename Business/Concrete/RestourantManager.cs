using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RestourantManager : IRestourantService
    {

        IRestourantDal _resDal;
        public RestourantManager(IRestourantDal resDal)
        {
            _resDal = resDal;
        }
        public IResult Add(Restourant restourant)
        {
            _resDal.Add(restourant);
            return new SuccessResult();
        }

        public IResult Delete(Restourant restourant)
        {
            _resDal.Delete(restourant);
            return new SuccessResult();
        }

        public IDataResult<List<Restourant>> GetAll()
        {
            return new SuccessDataResult<List<Restourant>>(_resDal.GetAll());
        }

        public IDataResult<List<Restourant>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Restourant>>(_resDal.GetAll(r => r.ID == id));
        }

        public IResult Update(Restourant restourant)
        {
            _resDal.Update(restourant);
            return new SuccessResult();
        }
    }
}
