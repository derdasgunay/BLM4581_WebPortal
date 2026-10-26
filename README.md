# BLM4581 Dönem Projesi

## Proje Hakkında

Bu proje ASP.NET Core MVC (.NET 10) ile geliştirilmiş bir web portalıdır. Şu an etkinlik (Event) yönetimi için bellek içi CRUD işlemleri çalışmaktadır: listeleme, oluşturma, detay, düzenleme ve silme.

Veriler henüz veritabanına yazılmaz; uygulama yeniden başlatıldığında kayıtlar sıfırlanır.

## Özellikler

- **Etkinlik listesi** (`/Event`): kayıtları tablo halinde gösterir.
- **Yeni etkinlik** (`/Event/Create`): başlık, açıklama ve kapasite ile kayıt oluşturur.
- **Detay** (`/Event/Details/{id}`): tek bir etkinliğin bilgilerini gösterir.
- **Düzenleme** (`/Event/Edit/{id}`): mevcut kaydı günceller.
- **Silme** (`/Event/Delete/{id}`): onay sonrası kaydı bellekten kaldırır.
- Form doğrulama: başlık zorunludur (en fazla 100 karakter), kapasite 1–1000 arasında olmalıdır.
- Başarılı işlemlerden sonra `TempData` ile bildirim mesajı gösterilir.

## Model

`Event` modeli şu alanları içerir:

| Alan | Açıklama |
| --- | --- |
| `Id` | Otomatik artan kimlik |
| `Title` | Etkinlik başlığı (zorunlu, en fazla 100 karakter) |
| `Description` | Açıklama |
| `Capacity` | Kapasite (1–1000) |

## Çalıştırma Talimatları

1. .NET 10 SDK kurulu olmalıdır.
2. Proje klasörüne girin:

```bash
cd WebPortal
```

3. Uygulamayı başlatın:

```bash
dotnet run
```

Geliştirme sırasında kod değiştikçe otomatik yeniden derlemek için:

```bash
dotnet watch
```

4. Tarayıcıda şu adreslere gidin:
   - Ana sayfa: http://localhost:5218
   - Etkinlikler: http://localhost:5218/Event

HTTPS profili kullanılıyorsa uygulama `https://localhost:7145` üzerinden de açılır.

# Dönem projesi videoları ve proje planı için [tıklayınız](https://drive.google.com/drive/folders/1sjnD3c2ELqg59nS5YTY-Ri7dV3FrJfgL?usp=sharing)
