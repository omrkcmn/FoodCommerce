using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DatabaseContext>,IUserDal
    {
        /// <summary>
        /// Kullanıcı rolleri burada çekilir.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<OperationClaim> GetClaims(int userId)
        {
            using (var context = new DatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == userId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public List<User> GetRestIdByUserId(Expression<Func<User, bool>> filter = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = (from res in db.Restoranlar
                              join user in db.Users
                              on res.ID equals user.RestoranId

                              select new User
                              {
                                  RestoranId = user.RestoranId,
                                  ID = user.ID
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
