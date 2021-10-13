using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll(int id);
        IResult Add(Order order);
        
        IResult Update(Order order);
        IResult Delete(Order order);
        IDataResult<List<UserOrderDetailDto>> GetRestourantFilteredDetail(int rest, bool tamamlama);
        IDataResult<List<UserOrderDetailDto>> GetUserFilteredDetail(int userID, bool siparisTamamlandimi);//burada sadece siparisi tamamlanmamış olanlar gelecek şekilde
    }
}
