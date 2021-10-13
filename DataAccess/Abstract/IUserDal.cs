using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(int userId);
        List<User> GetRestIdByUserId(Expression<Func<User, bool>> filter = null);
    }
}
