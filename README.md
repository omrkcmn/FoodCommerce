 ### Proje SOLID, Kurumsal Yazılım Mimari, AOP ve Yazılım Geliştirme Prensiplerine uygun geliştirildi.

###Kullanılan Metodolojiler
* .Net Core 3.1
* **Cross Cutting Concerns** **interceptor *Autofac** kütüphanesi ile implemente edildi
  * Performance   
  * Transaction
  * Validation
  * Caching

* **Entity Framework
* **AOP** ile **Cross Cutting Concerns** "kesişen ilgililer" projede modülarite yapıda geliştirildi. 
* **Exception Middleware** ile Merkezi hata mekanizması yapısı oluşturuldu.
* **Claim** Mekanizması ile rol bazlı yetkilendirmenin sınırları esnetildi.
* **JWT (JSON Web Token)** kimlik doğrulaması entegre edildi.
* **Fluent Validation** ile validasyon(doğrulama) işlemleri geliştirildi.
* **IoC(Inversion Of Control)** ile (loose coupling) olan nesneler oluşturuldu.
* **REST VE RESTFUL WEB SERVİS** ile sunucu-istemci iletişimi sağlandı.

### C# Backend Katmanlar ve Amaçları
* **Core**: Toolların diğer projelerde kullanılmasını sağlayan genel katman 
* **Entities**: Veritabanındaki tabloları nesneye dönüştürülür
* **DataAccess**: Veritabanı işlemleri gerçekleştirilir
* **Business**: Veritabanı işlemlerinden önce uygulanacak iş kuralları gerçekleştirilir
* **WebAPI**: Restful (Representational State Transfer)
