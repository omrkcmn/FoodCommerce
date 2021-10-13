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
    public class EfCartDal : EfEntityRepositoryBase<Cart, DatabaseContext>, ICartDal
    {
        public List<CartDetailDto> GetAllByUserId(Expression<Func<CartDetailDto, bool>> filter = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from yemek in db.Yemekler
                             join restoran in db.Restoranlar
                             on yemek.RestoranID equals restoran.ID
                             join img in db.YemekResim
                             on yemek.ID equals img.YemekID
                             join sepet in db.Sepet
                             on yemek.ID equals sepet.FoodId
                             join user in db.Users
                             on sepet.UserId equals user.ID

                             select new CartDetailDto
                             {
                                 RestoranAdi = restoran.RestoranAdi,
                                 RestoranID = restoran.ID,
                                 
                                 Tamamlandimi = sepet.Tamamlandimi,
                                 YemekAdi = yemek.YemekAdi,
                                 YemekID = yemek.ID,
                                 YemekResim = img.ResimPath,
                                 UserId = user.ID,
                                 Fiyat = yemek.Fiyat,
                                 Id = sepet.ID,
                                 Miktar = sepet.Quantity
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
