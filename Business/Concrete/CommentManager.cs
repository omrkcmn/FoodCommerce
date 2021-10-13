using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IDataResult<List<CommentDetailDto>> GetAllByRestId(int restourantID)
        {
            return new DataResult<List<CommentDetailDto>>(_commentDal.GetAllByRestId(r => r.RestoranId == restourantID), true);
        }
    }
}
