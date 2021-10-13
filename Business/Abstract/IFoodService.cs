using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace Business.Abstract
{
    public interface IFoodService
    {
        IDataResult<List<FoodDetailDto>> GetAll();
        IDataResult<List<FoodDetailDto>> GetAllById(int id);
        IDataResult<List<FoodDetailDto>> GetFoodByFoodId(int id);
        IDataResult<List<FoodDetailDto>> GetAllByRestourantId(int restId);
        IDataResult<List<FoodDetailDto>> GetAllByRestourantId2(int restId);
        IDataResult<List<FoodDetailDto>> GetAllByFoodAndRestName(string foodName, string restName);
        IResult Add(Food food);
        IResult Delete(Food food);
        IResult Update(Food food);
    }
}
