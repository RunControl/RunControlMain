using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GoogleMobileAds.Api;

namespace Batu
{
    public class Hesaplama
    {
        public void AdamYönetimi(string veri, Transform pozisyon, List<GameObject> Karakterler, ref int AnlikKarakterSayisi)
        {
            if (string.IsNullOrEmpty(veri) || veri.Length < 2)
                return;

            char islemTipi = veri[0];
            string sayiStr = veri.Substring(1);

            if (!int.TryParse(sayiStr, out int sayi) || sayi <= 0)
                return;

            switch (islemTipi)
            {
                case 'x': // Çarpma
                    Degistir((sayi - 1) * AnlikKarakterSayisi, pozisyon, true, Karakterler, ref AnlikKarakterSayisi);
                    break;

                case '+': // Toplama
                    Degistir(sayi, pozisyon, true, Karakterler, ref AnlikKarakterSayisi);
                    break;

                case '%': // Bölme
                    Degistir(AnlikKarakterSayisi / sayi, pozisyon, false, Karakterler, ref AnlikKarakterSayisi);
                    break;

                case '-': // Çıkarma
                    Degistir(sayi, pozisyon, false, Karakterler, ref AnlikKarakterSayisi);
                    break;
            }
        }

        private void Degistir(int miktar, Transform pozisyon, bool aktiflestir, List<GameObject> Karakterler, ref int AnlikKarakterSayisi)
        {
            if (miktar <= 0) return;

            for (int i = 0; i < Karakterler.Count && miktar > 0; i++)
            {
                var item = Karakterler[i];

                if (aktiflestir && !item.activeInHierarchy)
                {
                    item.transform.position = pozisyon.position;
                    item.SetActive(true);
                    AnlikKarakterSayisi++;
                    miktar--;
                }
                else if (!aktiflestir && item.activeInHierarchy)
                {
                    // ❗ Eğer azaltma sonucunda karakter sayısı 1'in altına inecekse durdur
                    if (AnlikKarakterSayisi <= 1)
                        break;

                    item.transform.position = pozisyon.position;
                    item.SetActive(false);
                    AnlikKarakterSayisi--;
                    miktar--;
                }
            }
        }

    }

    public class EfektYönetimi
    {
        public void EfektOlustur(Transform transform, List<GameObject> Efektler, bool balyoz = false)
        {
            Vector3 pozisyon = transform.position;
            if (balyoz)
            {
                foreach (var efekt in Efektler)
                {
                    if (!efekt.activeInHierarchy)
                    {
                        efekt.transform.position = pozisyon;
                        efekt.SetActive(true);
                        efekt.GetComponent<AudioSource>().Play();
                        break;
                    }
                }
            }
            else
            {
                pozisyon.y = 0.23f;
                foreach (var efekt in Efektler)
                {
                    if (!efekt.activeInHierarchy)
                    {
                        efekt.transform.position = pozisyon;
                        efekt.SetActive(true);
                        var particleSystem = efekt.GetComponent<ParticleSystem>();
                        if (particleSystem != null)
                        {
                            particleSystem.Play();
                        }
                        efekt.GetComponent<AudioSource>().Play();
                        break;
                    }
                }
            }
        }
    }


    public class BellekYonetim
    {
        public void VeriKaydet<T>(string key, T val)
        {
            switch (val)
            {
                case int i:
                    PlayerPrefs.SetInt(key, i);
                    break;
                case float f:
                    PlayerPrefs.SetFloat(key, f);
                    break;
                case string s:
                    PlayerPrefs.SetString(key, s);
                    break;
                default:
                    Debug.LogError($"VeriKaydet: Desteklenmeyen veri tipi ({typeof(T)})");
                    return;
            }

            PlayerPrefs.Save();
        }


        public T VeriOku<T>(string key)
        {
            if (typeof(T) == typeof(int))
            {
                object val = PlayerPrefs.GetInt(key, default);
                return (T)val;
            }
            else if (typeof(T) == typeof(float))
            {
                object val = PlayerPrefs.GetFloat(key, default);
                return (T)val;
            }
            else if (typeof(T) == typeof(string))
            {
                object val = PlayerPrefs.GetString(key, default);
                return (T)val;
            }
            else
            {
                Debug.LogError($"VeriOku: Desteklenmeyen tür ({typeof(T)})");
                return default;
            }
        }


        public void KontrolEtveTanımla()
        {
            if (!PlayerPrefs.HasKey("SonLevel"))
            {
                PlayerPrefs.SetInt("SonLevel", 6);
                PlayerPrefs.SetInt("Puan", 100);
                PlayerPrefs.SetInt("AktifSapka", -1);
                PlayerPrefs.SetInt("AktifSopa", -1);
                PlayerPrefs.SetInt("AktifTema", -1);
                PlayerPrefs.SetFloat("MenuSes", 1);
                PlayerPrefs.SetFloat("MenuFx", 1);
                PlayerPrefs.SetFloat("OyunSes", 1);
                PlayerPrefs.SetString("Dil", "TR");
                PlayerPrefs.SetInt("GecısReklamiSayisi", 1);
            }
        }

    }

    [Serializable]
    public class ItemBilgileri
    {
        public int GrupIndex;
        public int ItemIndex;
        public string ItemAd;
        public int Puan;
        public bool SatinAlmaDurumu;
    }

    public class VeriYönetimi
    {
        public void Save(List<ItemBilgileri> _itemBilgileri)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.persistentDataPath + "/ItemVerileri.gd");
            bf.Serialize(file, _itemBilgileri);
            file.Close();
        }

        List<ItemBilgileri> _itemIcListe;
        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/ItemVerileri.gd", FileMode.Open);
                _itemIcListe = (List<ItemBilgileri>)bf.Deserialize(file);
                file.Close();
            }
        }

        public List<ItemBilgileri> ListeyiAktar()
        {
            return _itemIcListe;
        }

        public void ilkKurulumDosyaOlusturma(List<ItemBilgileri> _itemBilgileri, List<DilVerileriAnaObje> _DilVerileri)
        {
            if (!File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd");
                bf.Serialize(file, _itemBilgileri);
                file.Close();
            }

            if (!File.Exists(Application.persistentDataPath + "/DilVerileri.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/DilVerileri.gd");
                bf.Serialize(file, _DilVerileri);
                file.Close();
            }
        }


        //----------------------------------

        List<DilVerileriAnaObje> _DilVerileriIcListe;
        public void Dil_Load()
        {
            if (File.Exists(Application.persistentDataPath + "/DilVerileri.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/DilVerileri.gd", FileMode.Open);
                _DilVerileriIcListe = (List<DilVerileriAnaObje>)bf.Deserialize(file);
                file.Close();
            }
        }

        public List<DilVerileriAnaObje> DilListeyiAktar()
        {
            return _DilVerileriIcListe;
        }
    }

    //-----------------------DİL YÖNETİMİ



    [Serializable]
    public class DilVerileriAnaObje
    {
        public int BolumIndex;
        public List<DilVerileri_TR> DilVerileri_TR = new List<DilVerileri_TR>();
        public List<DilVerileri_EN> DilVerileri_EN = new List<DilVerileri_EN>();

    }

    [Serializable]
    public class DilVerileri_TR
    {
        public string Metin;
    }
    
    [Serializable]
    public class DilVerileri_EN
    {
        public string Metin;
    }


    //------------------------------------------------------

    public class ReklamYonetimi : MonoBehaviour
    {
        private InterstitialAd interstitial;
        private RewardedAd rewardedAd;
        public void RequestInterstitial()
        {
            string adUnitId;

#if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        adUnitId = "unexpected_platform";
#endif

            AdRequest request = new AdRequest();

            InterstitialAd.Load(adUnitId, request, (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Interstitial failed to load: " + error);
                    return;
                }

                interstitial = ad;

                interstitial.OnAdFullScreenContentClosed += () =>
                {
                    Debug.Log("Ad closed.");
                    interstitial.Destroy();
                    RequestInterstitial(); // yeni reklam yükle
                };

                interstitial.OnAdFullScreenContentFailed += (AdError err) =>
                {
                    Debug.LogError("Ad failed to show: " + err.GetMessage());
                    interstitial.Destroy();
                    RequestInterstitial(); // tekrar dene
                };

                interstitial.OnAdFullScreenContentOpened += () =>
                {
                    Debug.Log("Ad opened.");
                };
            });
        }

        public void ShowInterstitial()
        {
            if (PlayerPrefs.GetInt("GecısReklamiSayisi") == 2)
            {
                if (interstitial != null && interstitial.CanShowAd())
                {
                    PlayerPrefs.SetInt("GecısReklamiSayisi", 0);
                    interstitial.Show();
                }
                else
                {
                    Debug.Log("Interstitial ad is not ready yet.");
                }
            }
            else
            {
                PlayerPrefs.SetInt("GecısReklamiSayisi", PlayerPrefs.GetInt("GecısReklamiSayisi") + 1);
            }

        }

        public void RequestRewardedAd()
        {
            string adUnitId;

#if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/5224354917"; // test ID
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-3940256099942544/1712485313"; // test ID
#else
        adUnitId = "unexpected_platform";
#endif

            AdRequest request = new AdRequest();

            RewardedAd.Load(adUnitId, request, (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load: " + error);
                    return;
                }

                rewardedAd = ad;

                rewardedAd.OnAdFullScreenContentOpened += () =>
                {
                    Debug.Log("Rewarded ad opened.");
                };

                rewardedAd.OnAdFullScreenContentClosed += () =>
                {
                    Debug.Log("Rewarded ad closed.");
                    rewardedAd.Destroy();
                    RequestRewardedAd(); // tekrar yükle
                };

                rewardedAd.OnAdFullScreenContentFailed += (AdError adError) =>
                {
                    Debug.LogError("Rewarded ad failed to show: " + adError.GetMessage());
                    rewardedAd.Destroy();
                    RequestRewardedAd(); // tekrar yükle
                };
            });
        }

        public void ShowRewardedAd()
        {
            if (rewardedAd != null && rewardedAd.CanShowAd())
            {
                rewardedAd.Show((Reward reward) =>
                {
                    Debug.Log("Kullanıcı ödül kazandı: " + reward.Amount + " " + reward.Type);
                    KullaniciyaOdulVer();
                });
            }
            else
            {
                Debug.Log("Rewarded ad is not ready yet.");
            }
        }

        private void KullaniciyaOdulVer()
        {
            // Kullanıcıya ödül verme işlemini burada yap
            Debug.Log("Ödül başarıyla verildi.");
        }
    }
    }