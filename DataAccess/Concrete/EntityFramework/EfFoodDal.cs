using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFoodDal : EfEntityRepositoryBase<Food, DatabaseContext>, IFoodDal
    {
        public List<FoodDetailDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext() )
            {
                var result = (from yemek in db.Yemekler
                             join res in db.Restoranlar
                             on yemek.RestoranID equals res.ID
                             join img in db.YemekResim
                             on yemek.ID equals img.YemekID

                             select new FoodDetailDto
                             {
                                 RestoranAdi = res.RestoranAdi,
                                 RestoranID = res.ID,
                                 YemekAdi = (from a in db.Yemekler where a.YemekAdi == yemek.YemekAdi select a.YemekAdi).First(),
                                 YemekID = yemek.ID,
                                 YemekResim = img.ResimPath,
                                 Fiyat = yemek.Fiyat
                             });
                return result.ToList();
            }
        }

        public List<FoodDetailDto> GetAllByFoodAndRestName(Expression<Func<FoodDetailDto, bool>> filter = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = (from yemek in db.Yemekler
                              join res in db.Restoranlar
                              on yemek.RestoranID equals res.ID
                              join img in db.YemekResim
                              on yemek.ID equals img.YemekID

                              select new FoodDetailDto
                              {
                                  RestoranAdi = res.RestoranAdi,
                                  RestoranID = res.ID,
                                  YemekAdi = (from a in db.Yemekler where a.YemekAdi == yemek.YemekAdi select a.YemekAdi).FirstOrDefault(),
                                  YemekID = yemek.ID,
                                  YemekResim = img.ResimPath//(from a in db.YemekResim where a.YemekID == yemek.ID select a.ResimPath).FirstOrDefault()
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public List<FoodDetailDto> GetAllByFoodId(Expression<Func<FoodDetailDto, bool>> filter = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = (from yemek in db.Yemekler
                              join res in db.Restoranlar
                              on yemek.RestoranID equals res.ID
                              join img in db.YemekResim
                              on yemek.ID equals img.YemekID

                              select new FoodDetailDto
                              {
                                  RestoranAdi = res.RestoranAdi,
                                  RestoranID = res.ID,
                                  YemekAdi = yemek.YemekAdi,
                                  YemekID = yemek.ID,
                                  YemekResim = img.ResimPath,//(from a in db.YemekResim where a.YemekID == yemek.ID select a.ResimPath).FirstOrDefault(),
                                  Aciklama = yemek.Aciklama,
                                  Fiyat = yemek.Fiyat
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public List<FoodDetailDto> GetAllByRestId(Expression<Func<FoodDetailDto, bool>> filter = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = (from yemek in db.Yemekler
                              join restoran in db.Restoranlar
                              on yemek.RestoranID equals restoran.ID
                              join img in db.YemekResim
                              on yemek.ID equals img.YemekID
                              select new FoodDetailDto
                              {
                                  RestoranAdi = restoran.RestoranAdi,
                                  RestoranID=restoran.ID,
                                  YemekAdi=yemek.YemekAdi,
                                  YemekID=yemek.ID,
                                  YemekResim = img.ResimPath,
                                  Aciklama = yemek.Aciklama,
                                  Fiyat = yemek.Fiyat
                  
                              });
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<FoodDetailDto> GetAllByRestId2(Expression<Func<FoodDetailDto, bool>> filter = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = (from yemek in db.Yemekler
                              join restoran in db.Restoranlar
                              on yemek.RestoranID equals restoran.ID
                              select new FoodDetailDto
                              {
                                  RestoranAdi = restoran.RestoranAdi,
                                  RestoranID = restoran.ID,
                                  YemekAdi = yemek.YemekAdi,
                                  YemekID = yemek.ID,
                                  Aciklama = yemek.Aciklama,
                                  Fiyat = yemek.Fiyat

                              });
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<FoodDetailDto> GetFoodByFoodId(Expression<Func<FoodDetailDto, bool>> filter = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = (from yemek in db.Yemekler
                              join res in db.Restoranlar
                              on yemek.RestoranID equals res.ID
                              

                              select new FoodDetailDto
                              {
                                  RestoranAdi = res.RestoranAdi,
                                  RestoranID = res.ID,
                                  YemekAdi = yemek.YemekAdi,
                                  YemekID = yemek.ID,
                                  Fiyat = yemek.Fiyat,
                                  Aciklama = yemek.Aciklama
                                 // YemekResim = img.ResimPath
                              });
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
