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
    public class EfOrderDal : EfEntityRepositoryBase<Order, DatabaseContext>, IOrderDal
    {
        public List<UserOrderDetailDto> GetUserFilteredDetail(Expression<Func<UserOrderDetailDto, bool>> filter = null)
        {
            
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from kullanicilar in db.Users
                             join siparisler in db.Siparisler
                             on kullanicilar.ID equals siparisler.KullaniciID
                             join yemekler in db.Yemekler
                             on siparisler.YemekID equals yemekler.ID
                             join restoran in db.Restoranlar
                             on siparisler.RestoranID equals restoran.ID
                             join img in db.YemekResim
                             on yemekler.ID equals img.YemekID

                             select new UserOrderDetailDto
                             {
                                 ID=siparisler.ID,
                                 KullaniciID = kullanicilar.ID,
                                 RestoranID = restoran.ID,
                                 YemekID = yemekler.ID,
                                 Adres = kullanicilar.Adres,
                                 KullaniciAdi = kullanicilar.KullaniciAdi,
                                 KullaniciSoyadi = kullanicilar.KullaniciSoyadi,
                                 Il = kullanicilar.Il,
                                 Ilce = kullanicilar.Ilce,
                                 RestoranAdi = restoran.RestoranAdi,
                                 Telefon = kullanicilar.Telefon,
                                 YemekAdi = yemekler.YemekAdi,
                                 SiparisTamamlanma = siparisler.Tamamlandimi,
                                 Fiyat = yemekler.Fiyat,
                                 Resim = img.ResimPath,
                                 Miktar = siparisler.Miktar,
                                 SiparisDurum = siparisler.SiparisDurum
                         };   
                return  filter == null ? result.ToList() : result.Where(filter).ToList();
            }


        }



        public List<Order> GetOrderDetails()
        {
            throw new NotImplementedException();
        }
    }
}
