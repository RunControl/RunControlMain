# Run Control

[![Unity Version](https://img.shields.io/badge/Unity-2021.3.x%20LTS-blue.svg)](https://unity3d.com/get-unity/download/archive)
[![Platform](https://img.shields.io/badge/Platform-Mobile-brightgreen.svg)](https://github.com/RunControl/RunControlMain)
[![License](https://img.shields.io/badge/License-MIT-lightgrey.svg)](LICENSE.md)

**Run Control**, oyuncuların engellerle dolu dinamik parkurlarda karakterlerini kontrol ettiği, kalabalıklarını büyüttüğü ve seviye sonu düşmanlarını yendiği, bağımlılık yaratan bir hyper-casual mobil oyundur. Oyun, sürükleyici bir **Artırılmış Gerçeklik (AR)** modu ile klasik runner mekaniklerini birleştirerek benzersiz bir deneyim sunar.


https://github.com/user-attachments/assets/9ab2c09a-fc0a-4387-b12c-8f191eda3a76


## 📜 İçindekiler

- [Oyun Hakkında](#-oyun-hakkında)
- [✨ Temel Özellikler](#-temel-özellikler)
- [🕹️ Oynanış Mekanikleri](#️-oynanış-mekanikleri)
- [📱 Artırılmış Gerçeklik (AR) Modu](#-artırılmış-gerçeklik-ar-modu)
- [🛠️ Teknik Detaylar](#️-teknik-detaylar)
- [⚠️ Gerekli Harici Paketler (Önemli)](#️-gerekli-harici-paketler-önemli)
- [🚀 Projeyi Çalıştırma](#-projeyi-çalıştırma)
- [📂 Proje Yapısı](#-proje-yapısı)
- [✍️ Yazar](#️-yazar)
- [📄 Lisans](#-lisans)

## 📖 Oyun Hakkında

**Run Control**'da amaç, tek bir karakterle başlayıp parkur boyunca doğru kapılardan geçerek kalabalığınızı büyütmektir. Oyuncular, karakterlerini çarpan (`x20`) veya ekleyen (`+3`) kapılara yönlendirerek stratejik kararlar almalıdır. Aynı zamanda, kalabalığınızı azaltabilecek çeşitli engellerden kaçınmanız gerekir. Seviyenin sonunda, biriktirdiğiniz kalabalıkla düşman ordusuna karşı savaşarak zafere ulaşmaya çalışırsınız!

## ✨ Temel Özellikler

- **🏃‍♂️ Dinamik Runner Mekanikleri:** Hızlı, akıcı ve tatmin edici bir oyun döngüsü.
- **📈 Stratejik Kalabalık Yönetimi:** Doğru kapıları seçerek ordunuzu büyütün ve gücünüzü katlayın.
- **🎨 Karakter Özelleştirme:** Oyuncuların karakterleri için farklı şapkalar ve silahlar gibi kozmetik ürünlerin kilidini açıp kullanabileceği bir sistem.
- **📱 Sürükleyici AR Modu:** Özelleştirdiğiniz karakterinizi artırılmış gerçeklik ile kendi dünyanıza taşıyın ve her açıdan inceleyin!
- **🌐 Çoklu Seviye Tasarımı:** Her biri farklı engeller ve zorluklar sunan özenle tasarlanmış seviyeler.
- **🛒 Market ve Ayarlar:** Oyun içi para birimiyle yeni özelleştirme öğeleri satın alın ve ses/dil gibi ayarları yönetin.
- **✨ Temiz ve Sezgisel Arayüz:** Hyper-casual estetiğine uygun, modern ve kullanıcı dostu bir arayüz.

## 🕹️ Oynanış Mekanikleri

1.  **Kontrol:** Oyuncu, parmağını ekranda sola ve sağa kaydırarak karakter grubunu kontrol eder.
2.  **Kapılar:** Parkurda bulunan kapılar, grubunuzdaki karakter sayısını artırır (`+`) veya çarpar (`x`).
3.  **Engeller:** Dikenli tuzaklar, dönen engeller ve düşmanlar gibi çeşitli engellerden kaçınarak kalabalığınızı koruyun.
4.  **Savaş:** Seviye sonunda, biriktirdiğiniz ordu ile rakip orduya karşı savaşırsınız. Zafer için onlardan daha güçlü olmalısınız!

## 📱 Artırılmış Gerçeklik (AR) Modu

Oyunun en dikkat çekici özelliklerinden biri olan AR modu, oyunculara özelleştirme ekranında karakterlerini gerçek dünyaya yansıtma imkanı tanır. Bu özellik sayesinde oyuncular:
- Cihazlarının kamerasını kullanarak karakterlerini bir masa, zemin veya herhangi bir düz yüzey üzerinde görebilirler.
- Karakterlerini 360 derece döndürerek özelleştirmelerini detaylı bir şekilde inceleyebilirler.
- Eğlenceli fotoğraflar çekip sosyal medyada paylaşabilirler.

Bu mod, Unity'nin **AR Foundation** paketi kullanılarak geliştirilmiştir.

## 🛠️ Teknik Detaylar

- **Oyun Motoru:** Unity 2021.3.15f1 (veya üstü)
- **Platform:** Mobil (Android & iOS)
- **Programlama Dili:** C#
- **Temel Paketler:**
  - AR Foundation, ARCore XR Plugin, ARKit XR Plugin (AR Modu için)
  - Universal Render Pipeline (URP)

## ⚠️ Gerekli Harici Paketler (Önemli)

Bu projenin düzgün çalışabilmesi için Unity Asset Store'dan satın alınması gereken **iki adet ücretli paket** bulunmaktadır. Lisans kısıtlamaları nedeniyle bu paketler repoda **yer almamaktadır**.

> **UYARI:** Projeyi Unity'de açmadan önce aşağıdaki paketleri satın alıp projenize import etmeniz **zorunludur**. Aksi takdirde proje derlenmeyecek ve kritik hatalar verecektir.

1.  **[Universal Hyper Casual UI for Mobile Games](https://assetstore.unity.com/packages/3d/gui/universal-hyper-casual-ui-for-mobile-games-176645)**
    - Oyunun ana menüsü, ayarlar, market ve diğer tüm arayüz elemanları için kullanılmıştır.

2.  **[Mega Hyper Casual Obstacles Pack](https://assetstore.unity.com/packages/3d/props/mega-hyper-casual-obstacles-pack-209978)**
    - Seviyelerdeki çeşitli engeller ve tuzaklar için kullanılmıştır.

## 🚀 Projeyi Çalıştırma

Bu projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

1.  **Repoyu Klonlayın:**
    ```bash
    git clone https://github.com/RunControl/RunControlMain.git
    ```
2.  **Unity'de Açın:**
    - Proje klasörünü Unity Hub üzerinden açın. Uyumlu bir **Unity 2021.3.x** sürümü kullandığınızdan emin olun.
3.  **Gerekli Paketleri İçe Aktarın (Kritik Adım):**
    - Unity Asset Store hesabınızla giriş yapın.
    - Yukarıda belirtilen [Universal Hyper Casual UI](https://assetstore.unity.com/packages/3d/gui/universal-hyper-casual-ui-for-mobile-games-176645) ve [Mega Hyper Casual Obstacles Pack](https://assetstore.unity.com/packages/3d/props/mega-hyper-casual-obstacles-pack-209978) paketlerini satın alın.
    - `Package Manager` üzerinden bu iki paketi projeye import edin.
4.  **Derleme ve Çalıştırma:**
    - Gerekli tüm paketler yüklendikten sonra proje hatasız bir şekilde derlenmelidir.
    - Unity Editor üzerinde `Play` butonuna basarak oyunu test edebilir veya `File > Build Settings` üzerinden hedef platformunuz (Android/iOS) için build alabilirsiniz.

## 📂 Proje Yapısı

Projenin ana klasör yapısı aşağıdaki gibidir:

<pre lang="markdown">
 RunControlMain/
├── Assets/
│ ├── _Project/
│ │ ├── Prefabs/ # Oyun objeleri, karakterler, engeller
│ │ ├── Scenes/ # Ana menü, oyun ve AR sahneleri
│ │ ├── Scripts/ # Tüm C# oyun mantığı kodları
│ │ ├── Materials/ # Materyaller ve shader'lar
│ │ └── Textures/ # Doku ve arayüz görselleri
│ ├── Packages/ # Proje paketleri (URP, AR Foundation vb.)
└── ProjectSettings/ # Unity proje ayarları 
 </pre>
