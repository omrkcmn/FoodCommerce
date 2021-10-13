using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IFoodDal : IEntityRepository<Food>
    {
        List<FoodDetailDto> GetAll();
        List<FoodDetailDto> GetFoodByFoodId(Expression<Func<FoodDetailDto, bool>> filter = null);
        List<FoodDetailDto> GetAllByFoodId(Expression<Func<FoodDetailDto, bool>> filter = null);
        List<FoodDetailDto> GetAllByRestId(Expression<Func<FoodDetailDto, bool>> filter = null);
        List<FoodDetailDto> GetAllByRestId2(Expression<Func<FoodDetailDto, bool>> filter = null);
        List<FoodDetailDto> GetAllByFoodAndRestName(Expression<Func<FoodDetailDto, bool>> filter = null);
    }
}
