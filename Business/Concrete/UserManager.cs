using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new DataResult<List<User>>(_userDal.GetAll(), true, Messages.UserListed);
        }

        public IDataResult<List<User>> GetCarByRentUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OperationClaim>> GetClaims(int userId)
        {
            return new DataResult<List<OperationClaim>>(_userDal.GetClaims(userId),true,"");
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(m => m.Email == email);
        }

        public IDataResult<List<User>> GetUserById(int id)
        {
            return new DataResult<List<User>>(_userDal.GetAll(u => u.ID == id), true, Messages.UserListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<User>> GetREstIdByUserId(int id)
        {
            return new DataResult<List<User>>(_userDal.GetRestIdByUserId(user => user.ID == id), true);
        }
    }
}
