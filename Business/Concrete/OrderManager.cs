using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        
        
        //[SecuredOperation("user")]
        
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult("Sipariş Verildi");
        }

        //[SecuredOperation("user,admin")]
        [TransactionScopeAspect]
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);

            return new SuccessResult(Messages.ProductDeleted);
        }
     
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.UserUpdated);
        }
        
        public IDataResult<List<UserOrderDetailDto>> GetUserFilteredDetail(int userID, bool tamamlama)
        {
            return new DataResult<List<UserOrderDetailDto>>(_orderDal.GetUserFilteredDetail(usr => usr.KullaniciID == userID && usr.SiparisTamamlanma == tamamlama),true,"");
        }

        public IDataResult<List<UserOrderDetailDto>> GetRestourantFilteredDetail(int restID, bool tamamlama)
        {
            return new DataResult<List<UserOrderDetailDto>>(_orderDal.GetUserFilteredDetail(usr => usr.RestoranID == restID && usr.SiparisTamamlanma == tamamlama), true, "");
        }

        public IDataResult<List<Order>> GetAll(int id)
        {
            return new DataResult<List<Order>>(_orderDal.GetAll(p=>p.KullaniciID.Equals(id)),true,"");
        }
    }
}
