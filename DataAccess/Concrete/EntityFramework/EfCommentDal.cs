using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, DatabaseContext>, ICommentDal
    {
        public List<CommentDetailDto> GetAllByRestId(Expression<Func<CommentDetailDto, bool>> filter = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from yorum in db.Yorumlar
                            join rest in db.Restoranlar
                            on yorum.RestoranId equals rest.ID


                            select new CommentDetailDto
                            {
                                ID = yorum.ID,
                                Puan = yorum.Puan,
                                RestoranAdi = rest.RestoranAdi,
                                RestoranId = rest.ID,
                                Yorum = yorum.Yorum
                            };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
