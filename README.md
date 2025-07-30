# 📊 Rapor Paneli Uygulaması

Bu proje, farklı rapor türlerine (Finans, Lojistik, Üretim, Cari) göre veri filtreleme, tablo ve grafik gösterimi gibi özellikler sunan bir **raporlama panelidir**.  
ASP.NET Core MVC, SQL Server ve JavaScript teknolojileri kullanılarak geliştirilmiştir.

---

## 🚀 Özellikler

- ✅ **Stored Procedure ile veri çekme**
- ✅ **Tarih aralığına göre filtreleme**
- ✅ **Rapor taslaklarını kaydetme ve yeniden yükleme**
- ✅ **Excel’e veri aktarımı** (xlsx.js ile)
- ✅ **Dinamik kolon seçimi (checkbox ile)**
- ✅ **KPI kutucukları ile özet bilgiler**
- ✅ **ApexCharts ile grafik gösterimi**

---

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server & Stored Procedures
- JavaScript & jQuery
- Bootstrap 5
- ApexCharts (grafikler için)
- xlsx (Excel aktarımı için)
- Newtonsoft.Json

---


## 💾 Taslak Kaydetme Özelliği

Kullanıcılar seçtikleri:
- Rapor türünü  
- Kolonları (checkbox seçimiyle)  
- Tarih aralığını  
kaydederek daha sonra tekrar kullanabilecekleri rapor taslakları oluşturabilirler.

Tüm taslaklar veritabanında `RaporTaslak` tablosunda saklanır.

---

## 📦 Projeyi Çalıştırma

1. `appsettings.json` üzerinden veritabanı bağlantısını yapılandırın.
2. SQL Server üzerinde gerekli stored procedure'leri oluşturun.
3. Visual Studio ile projeyi çalıştırın.
4. Uygulama otomatik olarak `Index.cshtml` üzerinden rapor panelini açacaktır.

---

## 📁 Örnek Stored Procedure

```sql
CREATE PROCEDURE Get_Order_Details
    @BaslangicTarihi DATE = NULL,
    @BitisTarihi DATE = NULL,
    @OrderID INT = NULL
AS
BEGIN
    SELECT * FROM Orders
    WHERE (@OrderID IS NULL OR OrderID = @OrderID)
      AND (@BaslangicTarihi IS NULL OR OrderDate >= @BaslangicTarihi)
      AND (@BitisTarihi IS NULL OR OrderDate <= @BitisTarihi)
END
