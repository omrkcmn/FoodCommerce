using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFoodImageService
    {
        IDataResult<List<FoodImage>> GetAll();
        IDataResult<List<FoodImage>> GetByFoodId(int id);
        IResult Add(IFormFile file, FoodImage foodImage);
        IResult Delete(FoodImage foodImage);
        IResult Update(FoodImage foodImage);
    }
}
