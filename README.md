# Run Control

[![Unity Version](https://img.shields.io/badge/Unity-2021.3.x%20LTS-blue.svg)](https://unity3d.com/get-unity/download/archive)
[![Platform](https://img.shields.io/badge/Platform-Mobile-brightgreen.svg)](https://github.com/RunControl/RunControlMain)
[![License](https://img.shields.io/badge/License-MIT-lightgrey.svg)](LICENSE.md)

**Run Control**, oyuncuların engellerle dolu dinamik parkurlarda karakterlerini kontrol ettiği, kalabalıklarını büyüttüğü ve seviye sonu düşmanlarını yendiği, bağımlılık yaratan bir hyper-casual mobil oyundur. Oyun, sürükleyici bir **Artırılmış Gerçeklik (AR)** modu ile klasik runner mekaniklerini birleştirerek benzersiz bir deneyim sunar.

>  **Run Control** is a thrilling hyper-casual mobile game that challenges players to navigate dynamic tracks packed with obstacles, build up their mob, and conquer formidable final bosses. It redefines the genre by fusing classic runner gameplay with a captivating  **Augmented Reality (AR)** mode for a truly one-of-a-kind experience.

https://github.com/user-attachments/assets/9ab2c09a-fc0a-4387-b12c-8f191eda3a76


## 📜 İçindekiler (Table of Contents)

- [Oyun Hakkında (About the Game)](#-oyun-hakkında)
- [✨ Temel Özellikler (Key Features)](#-temel-özellikler)
- [🕹️ Oynanış Mekanikleri (Gameplay Mechanics)](#️-oynanış-mekanikleri)
- [📱 Artırılmış Gerçeklik (AR) Modu (Augmented Reality (AR) Mode)](#-artırılmış-gerçeklik-ar-modu)
- [🛠️ Teknik Detaylar (Technical Details)](#️-teknik-detaylar)
- [⚠️ Gerekli Harici Paketler (Önemli) (Dependencies (Important))](#️-gerekli-harici-paketler-önemli)
- [🚀 Projeyi Çalıştırma (Getting Started)](#-projeyi-çalıştırma)
- [📂 Proje Yapısı (Project Structure)](#-proje-yapısı)

## 📖 Oyun Hakkında (About the Game)

**Run Control**'da amaç, tek bir karakterle başlayıp parkur boyunca doğru kapılardan geçerek kalabalığınızı büyütmektir. Oyuncular, karakterlerini çarpan (`x20`) veya ekleyen (`+3`) kapılara yönlendirerek stratejik kararlar almalıdır. Aynı zamanda, kalabalığınızı azaltabilecek çeşitli engellerden kaçınmanız gerekir. Seviyenin sonunda, biriktirdiğiniz kalabalıkla düşman ordusuna karşı savaşarak zafere ulaşmaya çalışırsınız!

> In **Run Control**, the objective is to start with a single character and grow your crowd by passing through the correct gates along the course. Players must make strategic decisions by guiding their characters toward multiplier (x20) or additive (+3) gates. Simultaneously, you must avoid various obstacles that can diminish your crowd. At the end of the level, you use your accumulated crowd to battle an enemy army and fight for victory!

## ✨ Temel Özellikler  (Key Features)

- **🏃‍♂️ Dinamik Runner Mekanikleri:** Hızlı, akıcı ve tatmin edici bir oyun döngüsü.
- **📈 Stratejik Kalabalık Yönetimi:** Doğru kapıları seçerek ordunuzu büyütün ve gücünüzü katlayın.
- **🎨 Karakter Özelleştirme:** Oyuncuların karakterleri için farklı şapkalar ve silahlar gibi kozmetik ürünlerin kilidini açıp kullanabileceği bir sistem.
- **📱 Sürükleyici AR Modu:** Özelleştirdiğiniz karakterinizi artırılmış gerçeklik ile kendi dünyanıza taşıyın ve her açıdan inceleyin!
- **🌐 Çoklu Seviye Tasarımı:** Her biri farklı engeller ve zorluklar sunan özenle tasarlanmış seviyeler.
- **🛒 Market ve Ayarlar:** Oyun içi para birimiyle yeni özelleştirme öğeleri satın alın ve ses/dil gibi ayarları yönetin.
- **✨ Temiz ve Sezgisel Arayüz:** Hyper-casual estetiğine uygun, modern ve kullanıcı dostu bir arayüz.

> - 🏃‍♂️ Dynamic Runner Mechanics: A fast, fluid, and satisfying gameplay loop.
> - 📈 Strategic Crowd Growth: Choose the right gates to grow your army and multiply its power.
> - 🎨 Character Customization: Unlock and equip various cosmetic items like hats and weapons to personalize your characters.
> - 📱 Immersive AR Mode: Bring your customized character into the real world with Augmented Reality and inspect it from every angle!
> - 🌐 Multiple Level Designs: Meticulously designed levels, each presenting unique obstacles and challenges.
> - 🛒 In-Game Shop & Settings: Purchase new customization items with in-game currency and manage options like audio and language.
> - ✨ Clean & Intuitive UI: A modern, user-friendly interface designed with a clean hyper-casual aesthetic.

## 🕹️ Oynanış Mekanikleri (Gameplay Mechanics)

1.  **Kontrol:** Oyuncu, parmağını ekranda sola ve sağa kaydırarak karakter grubunu kontrol eder.
2.  **Kapılar:** Parkurda bulunan kapılar, grubunuzdaki karakter sayısını artırır (`+`) veya çarpar (`x`).
3.  **Engeller:** Dikenli tuzaklar, dönen engeller ve düşmanlar gibi çeşitli engellerden kaçınarak kalabalığınızı koruyun.
4.  **Savaş:** Seviye sonunda, biriktirdiğiniz ordu ile rakip orduya karşı savaşırsınız. Zafer için onlardan daha güçlü olmalısınız!

> 1. **Controls:** The player controls their group of characters by swiping left and right on the screen.
> 2. **Gates:** Gates on the course either increase (+) or multiply (x) the number of characters in your group.>
> 3. **Obstacles:** Protect your crowd by avoiding various obstacles such as spiked traps, rotating barriers, and enemies.
> 4. **The Battle:** At the end of the level, you battle an opposing army with the crowd you've amassed. You must be stronger than them to claim victory!

## 📱 Artırılmış Gerçeklik (AR) Modu (Augmented Reality (AR) Mode)

Oyunun en dikkat çekici özelliklerinden biri olan AR modu, oyunculara özelleştirme ekranında karakterlerini gerçek dünyaya yansıtma imkanı tanır. Bu özellik sayesinde oyuncular:
- Cihazlarının kamerasını kullanarak karakterlerini bir masa, zemin veya herhangi bir düz yüzey üzerinde görebilirler.
- Karakterlerini 360 derece döndürerek özelleştirmelerini detaylı bir şekilde inceleyebilirler.
- Eğlenceli fotoğraflar çekip sosyal medyada paylaşabilirler.

Bu mod, Unity'nin **AR Foundation** paketi kullanılarak geliştirilmiştir.


> One of the game's most notable features is the AR mode, which allows players to project their characters into the real world directly from the customization screen. With this feature, players can:
> - Use their device's camera to view their character on a desk, the floor, or any flat surface.
> - Rotate their character 360 degrees to inspect their customizations in detail.
> - Take fun photos and share them on social media.

> This mode was developed using Unity's **AR Foundation** package.

## 🛠️ Teknik Detaylar (Technical Details)

- **Oyun Motoru:** Unity 2021.3.15f1 (veya üstü)
- **Platform:** Mobil (Android & iOS)
- **Programlama Dili:** C#
- **Temel Paketler:**
  - AR Foundation, ARCore XR Plugin, ARKit XR Plugin (AR Modu için)
  - Universal Render Pipeline (URP)

> - **Game Engine:** Unity 2021.3.15f1 (or newer)
> - **Platform:** Mobile (Android & iOS)
> - **Programming Language:** C#
> - **Key Dependencies / Required Packages:**  AR Foundation, ARCore XR Plugin, ARKit XR Plugin (for AR Mode) / Universal Render Pipeline (URP)

## ⚠️ Gerekli Harici Paketler (Önemli) (Dependencies (Important))

Bu projenin düzgün çalışabilmesi için Unity Asset Store'dan satın alınması gereken **iki adet ücretli paket** bulunmaktadır. Lisans kısıtlamaları nedeniyle bu paketler repoda **yer almamaktadır**.

>  [!WARNING]  
> Projeyi Unity'de açmadan önce aşağıdaki paketleri satın alıp projenize import etmeniz **zorunludur**. Aksi takdirde proje derlenmeyecek ve kritik hatalar verecektir.

1.  **[Universal Hyper Casual UI for Mobile Games](https://assetstore.unity.com/packages/3d/gui/universal-hyper-casual-ui-for-mobile-games-176645)**
    - Oyunun ana menüsü, ayarlar, market ve diğer tüm arayüz elemanları için kullanılmıştır.

2.  **[Mega Hyper Casual Obstacles Pack](https://assetstore.unity.com/packages/3d/props/mega-hyper-casual-obstacles-pack-209978)**
    - Seviyelerdeki çeşitli engeller ve tuzaklar için kullanılmıştır.

> For this project to function correctly, there are two paid assets that must be purchased from the Unity Asset Store. Due to licensing restrictions, these assets are not included in the repository.

> [!WARNING]
>  It is **mandatory** to purchase and import the following assets into your project before opening it in Unity. Failure to do so will prevent the project from compiling and will result in critical errors.

> 1.  **[Universal Hyper Casual UI for Mobile Games](https://assetstore.unity.com/packages/3d/gui/universal-hyper-casual-ui-for-mobile-games-176645)**
   > - Used for the game's main menu, settings, shop, and all other UI elements.
> 2.  **[Mega Hyper Casual Obstacles Pack](https://assetstore.unity.com/packages/3d/props/mega-hyper-casual-obstacles-pack-209978)**
   > - Used for the various obstacles and traps within the levels.

## 🚀 Projeyi Çalıştırma (Getting Started)

Bu projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

1.  **Repoyu Klonlayın:**
    - ```bash
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


> Follow the steps below to run this project on your local machine:
> 1.  **Clone the Repository:**
>      - ```bash
>         git clone https://github.com/RunControl/RunControlMain.git
>        ```
> 2.  **Open in Unity:**
>     - Open the project folder via the Unity Hub. Ensure you are using a compatible Unity 2021.3.x version.
> 3.  **Import Required Assets (Critical Step):**
>     - Log into your Unity Asset Store account.
>     - Purchase the [Universal Hyper Casual UI](https://assetstore.unity.com/packages/3d/gui/universal-hyper-casual-ui-for-mobile-games-176645) and [Mega Hyper Casual Obstacles Pack](https://assetstore.unity.com/packages/3d/props/mega-hyper-casual-obstacles-pack-209978) assets mentioned above.
>     - Import both assets into the project via the Package Manager.
> 4.  **Build and Run:**
>      - Once all required assets are imported, the project should compile without errors.
>      - You can test the game by pressing the Play button in the Unity Editor, or create a build for your target platform (Android/iOS) via File > Build Settings.


## 📂 Proje Yapısı (Project Structure)

Projenin ana klasör yapısı aşağıdaki gibidir:
> The main folder structure of the project is as follows:


<pre lang="markdown">
 RunControlMain/
├── Assets/
│ ├── _Project/
│ │ ├── Prefabs/      # Oyun objeleri, karakterler, engeller (Game objects, characters, obstacles)
│ │ ├── Scenes/       # Ana menü, oyun ve AR sahneleri (Main Menu, Gameplay, and AR scenes)
│ │ ├── Scripts/      # Tüm C# oyun mantığı kodları (All C# scripts for game logic)
│ │ ├── Materials/    # Materyaller ve shader'lar (Materials and shaders)
│ │ └── Textures/     # Doku ve arayüz görselleri (Textures and UI graphics)
│ ├── Packages/       # Proje paketleri (URP, AR Foundation vb.) (Project packages (URP, AR Foundation, etc.))
 </pre>
