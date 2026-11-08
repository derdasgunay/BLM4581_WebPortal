# BLM4581 Dönem Projesi

## Proje Hakkında

Bu proje ASP.NET Core MVC (.NET 10) ile geliştirilmiş bir kampüs etkinlik portalıdır. Etkinlik ve kategori kayıtları PostgreSQL veritabanında tutulur. Tablolar Entity Framework Core migration ile oluşturulur. Uygulama yeniden başlatıldığında kayıtlar silinmez.

Dönem projesi videoları ve proje planı: [Google Drive klasörü](https://drive.google.com/drive/folders/1sjnD3c2ELqg59nS5YTY-Ri7dV3FrJfgL?usp=sharing)

## Özellikler

- **Kategori listesi** (`/Category`): kategorileri tablo halinde gösterir. Veritabanında dört hazır kategori vardır: Teknoloji, Kariyer, Kültür ve Sanat, Spor.
- **Yeni kategori** (`/Category/Create`): kategori adı ile kayıt oluşturur.
- **Kategori düzenleme ve silme** (`/Category/Edit/{id}`, `/Category/Delete/{id}`).
- **Etkinlik listesi** (`/Event`): kayıtları tablo halinde gösterir.
- **Yeni etkinlik** (`/Event/Create`): başlık, açıklama, kapasite ve kategori ile kayıt oluşturur.
- **Detay** (`/Event/Details/{id}`): tek bir etkinliğin bilgilerini gösterir.
- **Düzenleme** (`/Event/Edit/{id}`): mevcut kaydı ve kategorisini günceller.
- **Silme** (`/Event/Delete/{id}`): onay sonrası kaydı veritabanından kaldırır.
- Form doğrulama: kategori adı zorunludur (en fazla 50 karakter). Etkinlik başlığı zorunludur (en fazla 100 karakter), kapasite 1–1000 arasında olmalıdır ve bir kategori seçilmelidir.
- Başarılı etkinlik işlemlerinden sonra `TempData` ile bildirim mesajı gösterilir.
- Bir kategorinin birden fazla etkinliği olabilir. Kategori silinirse ona bağlı etkinlikler de silinir.

## Modeller

`Category`: `Id`, `Name`.

`User`: `Id`, `Name`. Giriş ekranı henüz yoktur.

`Event`:

| Alan | Açıklama |
| --- | --- |
| `Id` | Otomatik artan kimlik |
| `Title` | Etkinlik başlığı (zorunlu, en fazla 100 karakter) |
| `Description` | Açıklama |
| `Capacity` | Kapasite (1–1000) |
| `CategoryId` | Bağlı olduğu kategori |

## Çalıştırma Talimatları

1. .NET 10 SDK ve PostgreSQL kurulu olmalıdır.
2. Proje klasörüne girin:

```bash
cd WebPortal
```

3. Bağlantı dizesi depoya konmaz. Geliştirme ortamında kullanıcı sırrı olarak tanımlanır. `KULLANICI` ve `SIFRE` yerine kendi PostgreSQL bilgilerinizi yazın:

```bash
dotnet user-secrets set "ConnectionStrings:PortalDb" "Host=localhost;Database=WebPortal;Username=KULLANICI;Password=SIFRE"
```

4. Migration'ları veritabanına uygulayın:

```bash
dotnet ef database update
```

5. Uygulamayı başlatın:

```bash
dotnet run
```

Geliştirme sırasında kod değiştikçe otomatik yeniden derlemek için:

```bash
dotnet watch
```

6. Tarayıcıda şu adreslere gidin:
   - Ana sayfa: http://localhost:5218
   - Etkinlikler: http://localhost:5218/Event
   - Kategoriler: http://localhost:5218/Category

HTTPS profili kullanılıyorsa uygulama `https://localhost:7145` üzerinden de açılır.
