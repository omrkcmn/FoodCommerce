using Business.Abstract;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BankManager : IBankService
    {
        public IResult Payment(string kartSahibi, long kartNumarasi, int guvenlikKodu, int ay, int yil, double tutar, int taksit)
        {
            if (yil < DateTime.Now.Year)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
