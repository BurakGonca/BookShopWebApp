# ASP.NET Core MVC BurakKitap Projesi (N-Tier Architecture)

Kullanılan Teknolojiler
Geliştirme Ortamı: Ms Visual Studio 2022
Kod Altyapısı: C# - .NET CORE 8.0 , HTML-CSS-JavaScript

Mimari Tasarım: N-Tier Katmanlı Mimari

Veri Tabanı: Ms SQL Server
Veri Erişim Teknolojisi: Entity Framework CORE (CodeFirst)

Veri Tabanı Sorguları: LINQ

File Upload: IFormFile

Authentication & Authorization: ASP.NET Core Identity

Tema Giydirme İşlemleri: Hazır template ve Bootstrap5 kütüphanesi

Projeyi Başlatma;
BookShopWebApp UI katmanındaki appsettings.json dosyasındaki server bağlantısını düzenleyin. 
PM Console'da add-migration [Migration Adı] komutunu yazıp çalıştırın.
PM Console'da update-database diyerek veritabanını oluşturun.

Program verilen rotalarla başlangıç olarak ön yüz ile çalışır.
Url'e /admin yazarak admin login sayfasına girebilirsiniz.

Admin için seeddata ile göndermiş olduğumuz,
admin@admin.com - 12345*Abcde şifresiyle admin paneline ulaşabilirsiniz.
Admin seeddata ile Admin rolündedir.

Admin panelinde  kategorileri ve kitapları oluşturarak, ön yüzü kullanıma hazır hale getirebilirsiniz.
Ardından dilerseniz admin tarafında crud işlemleri güvenle gerçekleştirebilirsiniz

Ön yüzde kullanıcılar için register ve login işlemleri mevcuttur.
Kullanıcı kayıtlarında otomatik olarak Customer rolü atanır.

Keyifli incelemeler.

![bookshop1](https://github.com/BurakGonca/BookShopWebApp/assets/154968593/9d89c31a-2d53-48ec-b044-ef19acef9d86)
![bookshop2](https://github.com/BurakGonca/BookShopWebApp/assets/154968593/23474e56-e6e7-425f-96b7-5c878e4ece98)
![bookshop3](https://github.com/BurakGonca/BookShopWebApp/assets/154968593/5f793a5a-1428-4b0d-9e00-56e03cb4e669)
![bookshop4](https://github.com/BurakGonca/BookShopWebApp/assets/154968593/082a91cf-dd4a-4422-86cf-51f97dbaa8e1)
