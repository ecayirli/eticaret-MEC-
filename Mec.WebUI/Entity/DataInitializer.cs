using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mec.WebUI.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name = "Telefon",Description = "Telefon Ürünleri"},
                new Category(){Name = "TV",Description = "TV Ürünleri"},
                new Category(){Name = "Bilgisayar",Description = "Bilgisayar Ürünleri"},
                new Category(){Name = "Kamera",Description = "Kamera Ürünleri"},
                new Category(){Name = "Beyaz Eşya",Description = "Beyaz Eşya Ürünleri"},
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }

            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){Name = "Samsung Galaxy M20 32 Gb Siyah",Description = "Enerji dolu bir gün yaşaman için 5000 mAh batarya ile yanındayım.",Price=1300,CategoryId=1,Stock=24,IsApproved = false,Image = "1.jpg"},
                new Product(){Name = "Xiaomi Redmi Note 8 64 GB (Xiaomi Türkiye Garantili)",Description = "Ram: 4 GB Dahili Hafıza: 64 GB Renk: Beyaz Kamera (Arka): 24.0.",Price=1700,CategoryId=1,Stock=45,Image = "2.jpg"},
                new Product(){Name = "Huawei P30 Lite 128 GB (Huawei Türkiye Garantili) ",Description = "6.15'' Damla Çentikli Ekran 48+8+2 MP Arka Kamera 3340 mAh Batarya Huawei 9V2A Hızlı Şarj ile güçlü 3340 mAh pil kapasitesi",Price=2399,CategoryId=1,Stock=78,IsApproved =true,IsHome = true,Image = "3.jpg"},
                new Product(){Name = "Asus Zenfone 4 Max ZC554KL 32 GB (Asus Türkiye Garantili) - Siyah",Description = "Bu ürün Resmi Distribütör firma garantisi altındadır. (Distribütör Garantili)",Price=799,CategoryId=1,Stock=800,IsApproved =false,Image = "4.jpg"},
                new Product(){Name = "Samsung Galaxy A10s 32 GB (Samsung Türkiye Garantili) - Siyah",Description = "Süper telefon al geç.",Price=1187,CategoryId=1,Stock=86,IsApproved =true,IsHome = true,Image = "2.jpg"},

                new Product(){Name = "Philips Ambilight 50PUS7304/62 Televizyon",Description = "Büyük bir YV mi istiyorsun? İşte bu TV tam senlik.",Price=3500,CategoryId=2,Stock=24,IsApproved =true,Image = "1.jpg"},
                new Product(){Name = "LG 50UM7450PLA 4K Ultra HD Televizyon, 50 inç (LG Türkiye Garantili)",Description = "LG 50UM7450PLA 4K Ultra HD Televizyon, 50 inç (LG Türkiye Garantili) gerçek bir televizyon.",Price=3200,CategoryId=2,Stock=78,IsApproved =true,IsHome = true,Image = "2.jpg"},
                new Product(){Name = "LG 49SM8200PLA LG NanoCell Televizyon, 49 inç (LG Türkiye Garantili)",Description = "LG 49SM8200PLA LG NanoCell Televizyon, 49 inç (LG Türkiye Garantili) çok ucuz televizyon al hemen.",Price=4144,CategoryId=2,Stock=98,IsApproved =true,Image = "3.jpg"},
                new Product(){Name = "LG 49UK6470 4K Uhd Led Televizyon, 129 cm (49 inç)",Description = "LG 49UK6470 4K Uhd Led Televizyon, 129 cm (49 inç) gel alda kampanya var.",Price=3300,CategoryId=2,Stock=64,IsApproved =false,IsHome = true,Image = "4.jpg"},

                new Product(){Name = "Lenova Ideapad 100s",Description = " SSD:Yok Marka:Lenovo Ekran Boyutu:14.1",Price=1390,CategoryId=3,Stock=24,IsApproved =true,Image = "4.jpg"},
                new Product(){Name = "HP 15-DB1002NT Athlon 300U 8GB 256SSD 2GB Ekran Kartı",Description = "Enerji dolu bir gün yaşaman için 5000 mAh batarya ile yanındayım.",Price=2340,CategoryId=3,Stock=24,IsApproved =false,IsHome = true,Image = "2.jpg"},
                new Product(){Name = "Lenovo IdeaPad S145-15API AMD Ryzen 7 3700U",Description = "Lenovo Ideapad S145 81ut008dtx Ryzen 7 37",Price=3300,CategoryId=3,Stock=24,IsApproved =true,IsHome = true,Image = "3.jpg"},
                new Product(){Name = "HP i5-8500T/440 G4 AIO",Description = "IŞLEMCİ HIZI Intel Core i5 8500T - 2.1 GHz (Turbo Boost Teknoloji ile Max. 3.5 Ghz) 9 MB Önbellek ",Price=1564,CategoryId=3,Stock=24,IsApproved =true,Image = "1.jpg"},


            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}