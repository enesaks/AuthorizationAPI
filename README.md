# REST API'lerde Sınırlı Yetkilendirme
### Proje Amacı
Bu proje, REST API'lerde belirli kullanıcı gruplarının yalnızca yetkilendirilmiş bilgilere erişmesini sağlarken, erişim izni olmayan bilgilere erişimlerini kısıtlamayı amaçlar. Proje kapsamında Product ve Order tabloları üzerinde GET, POST, PUT ve DELETE işlemleri, kullanıcılara verilen yetkilere göre sınırlanmıştır.

Admin kullanıcısı her işlemi yapabilir.
Developer kullanıcısı yalnızca GET işlemlerini gerçekleştirebilir.
Ortam Kurulumu
Projenin çalışması için aşağıdaki NuGet paketlerine ihtiyaç duyulmaktadır:

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.AspNetCore.Identity.EntityFrameworkCore
* Microsoft.AspNetCore.Identity.UI
* Microsoft.AspNetCore.Identity.Stores
  
### Kurulum Adımları
1- Basit bir web API oluşturun.

2- Code-first yöntemiyle MS SQL veritabanına bağlanın.

3- Product ve Order adında model sınıflarını oluşturun.

4- Kullanıcı türlerini yönetmek üzere AppUser.cs dosyasını oluşturun ve içerisine Role özelliğini ekleyin.

5- Migration işlemi ile Product, Order ve Identity ile otomatik gelen tabloları oluşturun.

### Identity Role Konfigürasyonu
Program.cs dosyasına aşağıdaki ayarları ekleyin:
```
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthorizationApiContext>()
    .AddDefaultTokenProviders();

```
Bu adım, kullanıcıların rollerini eklemenizi ve yönetmenizi sağlar.

### Authorization Ayarları
Program.cs dosyasında yetkilendirme için şu ayarları eklemelisiniz:
```
app.UseAuthentication();
app.UseAuthorization();

```
Controller Yetkilendirme
* Tüm API metotlarına yetkilendirme eklemek için controller başına şu etiketi ekleyin:
```
[Authorize(Roles = "Admin, Developer")]
```
* GET metodu her iki kullanıcı tarafından kullanılabilir. Bu nedenle GET metodunun başına aynı etiketi ekleyin:

```
[Authorize(Roles = "Admin, Developer")]
```
* POST metoduna sadece Admin kullanıcısının erişebilmesi için şu etiketi ekleyin:
```
[Authorize(Roles = "Admin")]

```
### Database ConnectionString Ayarı 
[/appsettings.json](https://github.com/enesaks/AuthorizationAPI/blob/main/AuthorizationApiProject/appsettings.json) üzerinden ConnectionString'i kendinize göre güncelleyin.

