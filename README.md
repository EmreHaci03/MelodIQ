# MelodIQ

MelodIQ, Türkiye'deki müzik dinleme alışkanlıklarını analiz etmek ve büyük veri kümeleri üzerinde anlamlı dashboard çıktıları üretmek için geliştirilmiş bir ASP.NET Core MVC projesidir. Proje, SQL Server üzerinde tutulan dinleme kayıtlarını Dapper ile okuyarak genel istatistikler, platform dağılımları, tür analizleri, yaş kırılımları, şehir bazlı veriler ve detaylı veri tablosu ekranları sunar.

## Proje Amacı

MelodIQ, yüksek hacimli müzik dinleme verilerinin hızlı ve okunabilir biçimde analiz edilmesini hedefler. Uygulama, tek tek kayıt incelemek yerine veriyi özetleyen, karşılaştıran ve görselleştiren bir panel sağlar.

Proje özellikle büyük veritabanlarındaki kayıtlarla çalışabilmek için tasarlanmıştır. Geliştirme ve test sürecinde `DapperDb` veritabanındaki `MusicData` tablosunda bulunan 2.600.000+ kayıt üzerinden denenmiştir.

## Ekran Görüntüleri

### Dashboard
![Dashboard 1](https://github.com/EmreHaci03/MelodIQ/blob/main/DapperProject/DapperProject/images/1.png)
![Dashboard 2](https://github.com/EmreHaci03/MelodIQ/blob/main/DapperProject/DapperProject/images/2.png)

### Veri Tablosu
![Veri Tablosu](https://github.com/EmreHaci03/MelodIQ/blob/main/DapperProject/DapperProject/images/3.png)

### Veri Tablosu - İsme Göre Arama
![İsme Göre Arama](https://github.com/EmreHaci03/MelodIQ/blob/main/DapperProject/DapperProject/images/4.png)

### Veri Tablosu - Silme
![Silme](https://github.com/EmreHaci03/MelodIQ/blob/main/DapperProject/DapperProject/images/5.png)

### Kayıt Güncelleme
![Güncelleme](https://github.com/EmreHaci03/MelodIQ/blob/main/DapperProject/DapperProject/images/6.png)

## Özellikler

* Toplam dinlenme, kayıt sayısı, en çok dinlenen şarkı, popüler platform ve en aktif şehir özetleri
* İstatistik kartları ve widget'lar
* Türlere göre dağılım analizi (donut grafik)
* Yaş gruplarına göre dinleme istatistikleri (progress bar)
* İllere göre dinleme sıralaması
* Platform bazlı dinleme dağılımı
* Türkiye şehir yoğunluk haritası (Leaflet.js)
* Şehir yoğunluklarına göre lokasyon işaretleme
* Büyük veri setleri için sayfalama destekli veri tablosu
* ID ve şarkı adı ile kayıt arama
* Güncelleme ve silme işlemleri (SweetAlert2 ile onay)
* Dark tema dashboard tasarımı

## Kullanılan Teknolojiler

* ASP.NET Core MVC
* .NET 6
* SQL Server
* Dapper
* Microsoft.Data.SqlClient
* Razor Views
* Leaflet.js (Harita)
* HTML, CSS, JavaScript

## Proje Yapısı
DapperProject/
Context/
DapperContext.cs
Controllers/
MusicDataController.cs
Entities/
MusicData.cs
Services/
IMusicService.cs
MusicService.cs
Views/
MusicData/
Dashboard.cshtml
MusicList.cshtml
UpdateMusic.cshtml
appsettings.json

## Veritabanı

Uygulama varsayılan olarak aşağıdaki connection string ile çalışır:
"connectionkey": "Server=YOUR_SERVER;Database=DapperDb;Integrated Security=True;TrustServerCertificate=True;"

Kullanılan tablo `MusicData` tablosudur. Temel alanlar:

* `Id`
* `SongName`
* `ArtistName`
* `Genre`
* `City`
* `Platform`
* `ListenCount`
* `AgeGroup`
* `ListenDate`

## Veri Seti

Veri seti Gemini yapay zeka aracı kullanılarak oluşturulmuştur. 2.100.000+ kayıt içermektedir. Türkiye'nin 15 şehrine ait müzik dinleme verileri, 4 tür (Pop, Rock, Hiphop, Arabesk), 3 platform (Spotify, YouTube, Apple Music) ve 5 yaş grubu (13-17, 18-24, 25-34, 35-44, 45+) kapsamaktadır.

## Kurulum

Projeyi çalıştırmak için aşağıdaki ortam gereklidir:

* .NET 6 SDK
* SQL Server
* `DapperDb` veritabanı

Bağımlılıkları yüklemek ve projeyi derlemek için:

```bash
dotnet restore
dotnet build
```

Uygulamayı çalıştırmak için:

```bash
dotnet run --project DapperProject/DapperProject.csproj
```

`appsettings.json` dosyasındaki connection string'i kendi SQL Server bilgilerinize göre güncelleyin.

## Ekranlar

Uygulamada iki ana ekran bulunur:

* **Dashboard:** Müzik dinleme verilerinden üretilen genel istatistik, grafik ve harita ekranı
* **Veri Tablosu:** Sayfalama, ID ve şarkı adı araması ile kayıtların incelenebildiği, güncellenip silinebildiği tablo ekranı

## Notlar

Bu proje eğitim amacıyla geliştirilmiştir. Büyük veri setleriyle çalışma pratiği, SQL sorgularının dashboard ihtiyaçlarına göre şekillendirilmesi ve ASP.NET Core MVC üzerinde veri odaklı arayüz geliştirme deneyimi kazanmayı hedefler.

## Geliştirici

GitHub: [EmreHaci03](https://github.com/EmreHaci03)
