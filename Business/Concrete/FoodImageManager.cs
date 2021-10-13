using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class FoodImageManager : IFoodImageService
    {
        IFoodImageDal _foodImageDal;
        public FoodImageManager(IFoodImageDal foodImageDal)
        {
            _foodImageDal = foodImageDal;
        }

        [SecuredOperation("image.add,admin")]
        public IResult Add(IFormFile file, FoodImage foodImage)
        {
            var result = BusinessRules.Run(CheckImageRestriction(foodImage.ID));
            if (result != null)
            {
                return result;
            }

            foodImage.ResimPath = FileHelper.Add(file);
            foodImage.Date = DateTime.Now;
            _foodImageDal.Add(foodImage);
            return new SuccessResult(Messages.ImageAdded);
        }
        [SecuredOperation("image.delete,admin")]
        public IResult Delete(FoodImage foodImage)
        {
            //FileHelper.Delete(foodImage.ResimPath);
            _foodImageDal.Delete(foodImage);
            return new SuccessResult(Messages.UserDeleted);
        }
        
        [SecuredOperation("image.getall,admin")]
        public IDataResult<List<FoodImage>> GetAll()
        {
            return new SuccessDataResult<List<FoodImage>>(_foodImageDal.GetAll(), Messages.ImageAdded);
        }
        
        [CacheAspect]
        public IDataResult<List<FoodImage>> GetByFoodId(int id)
        {
            return new DataResult<List<FoodImage>>(_foodImageDal.GetAll(c => c.YemekID == id),true);
        }


        [SecuredOperation("image.update,admin")]

        public IResult Update(FoodImage foodImage)
        {
            _foodImageDal.Update(foodImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        /// <summary>
        /// Kısıtlama metodu. Burada sadece 5 adet resim yüklenebileceği belirlendi.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private IResult CheckImageRestriction(int id)
        {
            var foodImageCount = _foodImageDal.GetAll(p => p.YemekID == id).Count;
            if (foodImageCount > 1)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

    }
}

