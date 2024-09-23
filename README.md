# Kütüphane Yönetim Sistemi

## Proje Tanımı
Bu proje, bir kütüphanenin kitap ve yazar işlemlerini yönetmek amacıyla geliştirilmiş bir ASP.NET Core MVC uygulamasıdır. Uygulama, kullanıcıların kitapları ve yazarları ekleyip düzenlemelerine, detaylarını görüntülemelerine ve kayıt olma/giriş yapma işlemlerini gerçekleştirmelerine olanak tanır.

## Teknolojiler
- ASP.NET Core MVC
- Entity Framework Core
- Bootstrap (CSS Framework)
- C#
- HTML/CSS

## Proje Gereksinimleri

### Model Oluşturma

1. **Book Modeli**
   - `Id`: (int) Benzersiz kimlik
   - `Title`: (string) Kitap başlığı
   - `AuthorId`: (int) Yazar kimliği (Author modeline referans)
   - `Genre`: (string) Kitap türü
   - `PublishDate`: (DateTime) Yayın tarihi
   - `ISBN`: (string) ISBN numarası
   - `CopiesAvailable`: (int) Mevcut kopya sayısı

2. **Author Modeli**
   - `Id`: (int) Benzersiz kimlik
   - `FirstName`: (string) Yazarın adı
   - `LastName`: (string) Yazarın soyadı
   - `DateOfBirth`: (DateTime) Doğum tarihi

3. **User Modeli**
   - `Id`: (int) Benzersiz kimlik
   - `FullName`: (string) Üye adı ve soyadı
   - `Email`: (string) Üye e-posta adresi
   - `Password`: (string) Üye giriş parolası
   - `PhoneNumber`: (string) Üye telefon numarası
   - `JoinDate`: (DateTime) Üye kayıt tarihi

### ViewModel Oluşturma
- Kitap detayları için bir ViewModel
- Yazar detayları için bir ViewModel
- Kayıt olma ve giriş yapma sayfaları için iki ViewModel

### Controller Oluşturma
1. **BookController**
   - `List`: Kitapların listesini gösterir.
   - `Details`: Belirli bir kitabın detaylarını gösterir.
   - `Create`: Yeni bir kitap eklemek için form sağlar.
   - `Edit`: Var olan bir kitabı düzenlemek için form sağlar.
   - `Delete`: Kitabı silmek için bir onay sayfası sağlar.

2. **AuthorController**
   - `List`: Yazarların listesini gösterir.
   - `Details`: Belirli bir yazarın detaylarını gösterir.
   - `Create`: Yeni bir yazar eklemek için form sağlar.
   - `Edit`: Var olan bir yazarı düzenlemek için form sağlar.
   - `Delete`: Yazarı silmek için bir onay sayfası sağlar.

3. **AuthController**
   - `SignUp`: Kayıt işlemini yönetir.
   - `Login`: Giriş işlemini yönetir.

### View Oluşturma
- **Kitap Views**: List, Details, Create, Edit
- **Yazar Views**: List, Details, Create, Edit
- **User Views**: Sign Up ve Login

### Program.cs Konfigürasyonu
- MVC Servislerinin Eklenmesi
- wwwroot Kullanımı
- Routing Konfigürasyonu
- Varsayılan Routing

### Ek Özellikler
- Layout ve PartialView kullanımı
- Sayfanın altında sabitlenmiş bir footer

## Kullanım
1. Projeyi indirin veya klonlayın.
2. Visual Studio veya tercih ettiğiniz bir IDE ile açın.
3. Gerekli NuGet paketlerini yükleyin.
4. Veritabanını oluşturun ve gerekli tabloları ekleyin.
5. Uygulamayı başlatın ve tarayıcınızda görüntüleyin.

## Katkıda Bulunanlar
- [Adınız]

## Lisans
Bu proje [Lisans Bilgisi] altında lisanslanmıştır.

