using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<Order> GetOrderDetails();

        List<UserOrderDetailDto> GetUserFilteredDetail(Expression<Func<UserOrderDetailDto, bool>> filter = null);

    }
}
