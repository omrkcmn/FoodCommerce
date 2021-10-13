using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
        IFoodDal _food;
        public FoodManager(IFoodDal foodDal)
        {
            _food = foodDal;
        }

        [SecuredOperation("food.add")]
        
        [CacheRemoveAspect("IFoodService.Get")]
        public IResult Add(Food food)
        {
            _food.Add(food);
            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheRemoveAspect("IFoodService.Get")]
        [SecuredOperation("food.delete,admin")]
        public IResult Delete(Food food)
        {
            _food.Delete(food);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<FoodDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<FoodDetailDto>>(_food.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<FoodDetailDto>> GetAllByFoodAndRestName(string foodName, string restName)
        {
            return new DataResult<List<FoodDetailDto>>(_food.GetAllByFoodAndRestName(a=>a.YemekAdi == foodName && a.RestoranAdi == restName),true);
        }

        public IDataResult<List<FoodDetailDto>> GetAllById(int id)
        {
            return new DataResult<List<FoodDetailDto>>(_food.GetAllByFoodId(b => b.YemekID == id), true);
        }

        //[SecuredOperation("brand.getallbyid,admin")]
        [CacheAspect]

        public IDataResult<List<FoodDetailDto>> GetAllByRestourantId(int restId)
        {
            return new DataResult<List<FoodDetailDto>>(_food.GetAllByRestId(x=>x.RestoranID == restId),true);
        }

        public IDataResult<List<FoodDetailDto>> GetAllByRestourantId2(int restId)
        {
            return new DataResult<List<FoodDetailDto>>(_food.GetAllByRestId2(x => x.RestoranID == restId), true);
        }

        public IDataResult<List<FoodDetailDto>> GetFoodByFoodId(int id)
        {
            return new DataResult<List<FoodDetailDto>>(_food.GetFoodByFoodId(food => food.YemekID == id),true);
        }



        [SecuredOperation("food.update,admin")]
        [CacheRemoveAspect("IFoodService.Get")]
        public IResult Update(Food food)
        {
            _food.Update(food);
            return new SuccessResult();
        }
    }
}
