using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBankService
    {
        IResult Payment(string kartSahibi, long kartNumarasi, int guvenlikKodu, int ay, int yil, double tutar, int taksit);
    }
}
