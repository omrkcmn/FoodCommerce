using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestourantService
    {
        IDataResult<List<Restourant>> GetAll();
        IDataResult<List<Restourant>> GetAllById(int id);

        IResult Add(Restourant restourant);
        IResult Delete(Restourant restourant);

        IResult Update(Restourant restourant);
    }
}
