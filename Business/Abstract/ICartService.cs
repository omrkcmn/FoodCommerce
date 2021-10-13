using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICartService
    {
        IDataResult<List<CartDetailDto>> GetAllByUserId(int id);
        IResult Add(Cart cart);
        IResult Update(Cart cart);
        IResult Delete(Cart cart);
    }
}
