# LAGSE -> ListelemeAramaGüncellemeSilmeEkleme

<br>

#### Pattern

- Veritabanı orm bağlantısı için Singleton Pattern kullanıldı. (DbContext)
- Service katmanı ile Repository Pattern kullanılmış oldu.
- Servisler Core alt yapısında gelen DI aracılığı ile bağlandı.

<br>

#### NOT

- Veritabanı ile ilgili bir değişiklik yapılmasına gerek yoktur. Remote Db eklenmiştir.
- Farklı bir db bağlanmak istenirse sadece appsettings altındaki connection string değiştirilmesi yeterlidir. (Service katmanında tablo oluşturulması ile ilgili script bulunuyor.)

<br>

#### Kullanılan Teknolojiler

-  .Net Standart 2.0
-  .Net Core 2.2
-  AspNetCore
-  EntityFrameworkCore
-  DB -> Remote MsSql