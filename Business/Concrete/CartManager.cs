using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public IResult Add(Cart cart)
        {
            _cartDal.Add(cart);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Cart cart)
        {
            _cartDal.Delete(cart);
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<CartDetailDto>> GetAllByUserId(int id)
        {
            return new DataResult<List<CartDetailDto>>(_cartDal.GetAllByUserId(f=>f.UserId==id),true);
        }

        public IResult Update(Cart cart)
        {
            _cartDal.Update(cart);
            return new SuccessResult("Güncellendi");
        }
    }
}
