using UnityEngine;
using UnityEngine.UI;
using Batu;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class OzellestirmeManager : MonoBehaviour
{
    [Header("TEXTLER")]
    public TextMeshProUGUI PuanText;
 
    public GameObject[] islemPanelleri;
    public GameObject islemCanvasi;
    public GameObject[] GenelPaneller;
    public Button[] IslemButonlari;
    int AktifÝslemPaneliIndex;

    [Header("SAPKALAR")]
    public GameObject[] Sapkalar;
    public Button[] SapkaButonlari;
    public TextMeshProUGUI SapkaText;

    [Header("Sopalar")]
    public GameObject[] Sopalar;
    public Button[] SopaButonlari;
    public TextMeshProUGUI SopaText;

    [Header("Materyaller")]
    public Material[] Materyaller;
    public Material VarsayýlanTema;
    public Button[] MateryalButonlari;
    public TextMeshProUGUI MateryalText;
    public SkinnedMeshRenderer _Renderer;
    public AudioSource[] Sesler;

    int SapkaIndex = -1;
    int SopaIndex = -1;
    int MateryalIndex = -1;

    BellekYonetim _bellekyonetim = new BellekYonetim();
    VeriYönetimi _veriYönetimi = new VeriYönetimi();

    [Header("Genel Veriler")]
    public List<ItemBilgileri> _itemBilgileri = new List<ItemBilgileri>();

    public List<DilVerileriAnaObje> _DilVerileriOkunan = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();

    public TextMeshProUGUI[] textObjeleri;
    string SatinAlmaText;
    string ItemText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       // _bellekyonetim.VeriKaydet("Puan", 1500);
        PuanText.text = _bellekyonetim.VeriOku<int>("Puan").ToString();

         // _veriYönetimi.Save(_itemBilgileri);

        _veriYönetimi.Load();
        _itemBilgileri = _veriYönetimi.ListeyiAktar();

        DurumuKontrolEt(0,true);
        DurumuKontrolEt(1, true);
        DurumuKontrolEt(2, true);


        foreach (var item in Sesler)
        {
            item.volume = _bellekyonetim.VeriOku<float>("MenuFx");
        }

        _veriYönetimi.Dil_Load();
        _DilVerileriOkunan = _veriYönetimi.DilListeyiAktar();
        _DilVerileriAnaObje.Add(_DilVerileriOkunan[1]);
        DilTercihiYönetimi();
    }

    public void DilTercihiYönetimi()
    {
        if (_bellekyonetim.VeriOku<string>("Dil") == "TR")
        {

            for (int i = 0; i < textObjeleri.Length; i++)
            {
                textObjeleri[i].text = _DilVerileriAnaObje[0].DilVerileri_TR[i].Metin;
            }

            SatinAlmaText = _DilVerileriAnaObje[0].DilVerileri_TR[5].Metin;
            ItemText = _DilVerileriAnaObje[0].DilVerileri_TR[4].Metin;
        }
        else
        {

            for (int i = 0; i < textObjeleri.Length; i++)
            {
                textObjeleri[i].text = _DilVerileriAnaObje[0].DilVerileri_EN[i].Metin;
            }
            SatinAlmaText = _DilVerileriAnaObje[0].DilVerileri_EN[5].Metin;
            ItemText = _DilVerileriAnaObje[0].DilVerileri_EN[4].Metin;
        }
    }

    public void SapkaYonButonlarý(string islem)
    {
        Sesler[0].Play();
        if (islem == "ileri")
        {
            if(SapkaIndex == -1)
            {
                SapkaIndex = 0;
                Sapkalar[SapkaIndex].SetActive(true);
               SapkaText.text = _itemBilgileri[SapkaIndex].ItemAd;

                if (!_itemBilgileri[SapkaIndex].SatinAlmaDurumu)
                {
                    textObjeleri[5].text = _itemBilgileri[SapkaIndex].Puan.ToString() + " - " + SatinAlmaText;
                    IslemButonlari[1].interactable = false;
                    if (_bellekyonetim.VeriOku<int>("Puan") < _itemBilgileri[SapkaIndex].Puan)
                        IslemButonlari[0].interactable = false;
                    else
                        IslemButonlari[0].interactable = true;
                }
                else
                {
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                    IslemButonlari[1].interactable = true;
                }
            }
            else
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex++;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text = _itemBilgileri[SapkaIndex].ItemAd;

                if (!_itemBilgileri[SapkaIndex].SatinAlmaDurumu)
                {
                    textObjeleri[5].text = _itemBilgileri[SapkaIndex].Puan.ToString() + " - " + SatinAlmaText;
                    IslemButonlari[1].interactable = false;
                    if (_bellekyonetim.VeriOku<int>("Puan") < _itemBilgileri[SapkaIndex].Puan)
                        IslemButonlari[0].interactable = false;
                    else
                        IslemButonlari[0].interactable = true;
                }
                else
                {
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                    IslemButonlari[1].interactable = true;
                }
            }

            //--------------------

            if(SapkaIndex == Sapkalar.Length - 1)
                SapkaButonlari[1].interactable = false;
            else
                SapkaButonlari[1].interactable = true;
            if (SapkaIndex != -1)
            {
                SapkaButonlari[0].interactable = true;
            }
        }
        else
        {
            if (SapkaIndex != -1)
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex--;
                if (SapkaIndex != -1)
                {
                    Sapkalar[SapkaIndex].SetActive(true);
                    SapkaButonlari[0].interactable = true;
                    SapkaText.text = _itemBilgileri[SapkaIndex].ItemAd;

                    if (!_itemBilgileri[SapkaIndex].SatinAlmaDurumu)
                    {
                        textObjeleri[5].text = _itemBilgileri[SapkaIndex].Puan.ToString() + " - " + SatinAlmaText;
                        IslemButonlari[1].interactable = false;
                        if (_bellekyonetim.VeriOku<int>("Puan") < _itemBilgileri[SapkaIndex].Puan)
                            IslemButonlari[0].interactable = false;
                        else
                            IslemButonlari[0].interactable = true;
                    }
                    else
                    {
                        textObjeleri[5].text = SatinAlmaText;
                        IslemButonlari[0].interactable = false;
                        IslemButonlari[1].interactable = true;
                    }
                }
                else
                {
                    SapkaButonlari[0].interactable = false;
                    SapkaText.text = ItemText;
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                }
            }
            else
            {
                SapkaButonlari[0].interactable = false;
                SapkaText.text = ItemText;
                textObjeleri[5].text = SatinAlmaText;
                IslemButonlari[0].interactable = false;

            }

            //--------------------

            if (SapkaIndex != Sapkalar.Length - 1)
                SapkaButonlari[1].interactable = true;

        }
    }

    public void SopaYonButonlarý(string islem)
    {
        Sesler[0].Play();
        if (islem == "ileri")
        {
            if (SopaIndex == -1)
            {
                SopaIndex = 0;
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _itemBilgileri[SopaIndex + 3].ItemAd;

                if (!_itemBilgileri[SopaIndex + 3].SatinAlmaDurumu)
                {
                    textObjeleri[5].text = _itemBilgileri[SopaIndex + 3].Puan.ToString() + " - " + SatinAlmaText;
                    IslemButonlari[1].interactable = false;
                    if (_bellekyonetim.VeriOku<int>("Puan")< _itemBilgileri[SapkaIndex + 3].Puan)
                        IslemButonlari[0].interactable = false;
                    else
                        IslemButonlari[0].interactable = true;
                }
                else
                {
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                    IslemButonlari[1].interactable = true;
                }
            }
            else
            {
                Sopalar[SopaIndex].SetActive(false);
                SopaIndex++;
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _itemBilgileri[SopaIndex + 3].ItemAd;

                if (!_itemBilgileri[SopaIndex + 3].SatinAlmaDurumu)
                {
                    textObjeleri[5].text = _itemBilgileri[SopaIndex + 3].Puan.ToString() + " - " + SatinAlmaText;
                    IslemButonlari[1].interactable = false;
                    if (_bellekyonetim.VeriOku<int>("Puan") < _itemBilgileri[SapkaIndex + 3].Puan)
                        IslemButonlari[0].interactable = false;
                    else
                        IslemButonlari[0].interactable = true;
                }
                else
                {
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                    IslemButonlari[1].interactable = true;
                }
            }

            //--------------------

            if (SopaIndex == Sopalar.Length - 1)
                SopaButonlari[1].interactable = false;
            else
                SopaButonlari[1].interactable = true;
            if (SopaIndex != -1)
            {
                SopaButonlari[0].interactable = true;
            }
        }
        else
        {
            if (SopaIndex != -1)
            {
                Sopalar[SopaIndex].SetActive(false);
                SopaIndex--;

                if (SopaIndex != -1)
                {
                    Sopalar[SopaIndex].SetActive(true);
                    SopaButonlari[0].interactable = true;
                    SopaText.text = _itemBilgileri[SopaIndex + 3].ItemAd;

                    if (!_itemBilgileri[SopaIndex + 3].SatinAlmaDurumu)
                    {
                        textObjeleri[5].text = _itemBilgileri[SopaIndex + 3].Puan.ToString() + " - " + SatinAlmaText;
                        IslemButonlari[1].interactable = false;
                        if (_bellekyonetim.VeriOku<int>("Puan") < _itemBilgileri[SapkaIndex + 3].Puan)
                            IslemButonlari[0].interactable = false;
                        else
                            IslemButonlari[0].interactable = true;
                    }
                    else
                    {
                        textObjeleri[5].text = SatinAlmaText;
                        IslemButonlari[0].interactable = false;
                        IslemButonlari[1].interactable = true;
                    }
                }
                else
                {
                    SopaButonlari[0].interactable = false;
                    SopaText.text = ItemText;
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                }
            }
            else
            {
                SopaButonlari[0].interactable = false;
                SopaText.text = ItemText;
                textObjeleri[5].text = SatinAlmaText;
                IslemButonlari[0].interactable = false;
            }

            //--------------------

            if (SopaIndex != Sopalar.Length - 1)
                SopaButonlari[1].interactable = true;

        }
    }

    public void MateryalYonButonlarý(string islem)
    {
        Sesler[0].Play();
        if (islem == "ileri")
        {
            if (MateryalIndex == -1)
            {
                MateryalIndex = 0;
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MateryalIndex];
                _Renderer.materials = mats;
                MateryalText.text = _itemBilgileri[MateryalIndex + 6].ItemAd;

                if (!_itemBilgileri[MateryalIndex + 6].SatinAlmaDurumu)
                {
                    textObjeleri[5].text = _itemBilgileri[MateryalIndex + 6].Puan.ToString() + " - " + SatinAlmaText;
                    IslemButonlari[1].interactable = false;
                    if (_bellekyonetim.VeriOku<int>("Puan") < _itemBilgileri[SapkaIndex + 6].Puan)
                        IslemButonlari[0].interactable = false;
                    else
                        IslemButonlari[0].interactable = true;
                }
                else
                {
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                    IslemButonlari[1].interactable = true;
                }
            }
            else
            {
                MateryalIndex++;
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MateryalIndex];
                _Renderer.materials = mats;
                MateryalText.text = _itemBilgileri[MateryalIndex + 6].ItemAd;

                if (!_itemBilgileri[MateryalIndex + 6].SatinAlmaDurumu)
                {
                    textObjeleri[5].text = _itemBilgileri[MateryalIndex + 6].Puan.ToString() + " - " + SatinAlmaText;
                    IslemButonlari[1].interactable = false;
                    if (_bellekyonetim.VeriOku<int>("Puan") < _itemBilgileri[SapkaIndex + 6].Puan)
                        IslemButonlari[0].interactable = false;
                    else
                        IslemButonlari[0].interactable = true;
                }
                else
                {
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                    IslemButonlari[1].interactable = true;
                }
            }

            //--------------------

            if (MateryalIndex == Materyaller.Length - 1)
                MateryalButonlari[1].interactable = false;
            else
                MateryalButonlari[1].interactable = true;
            if (MateryalIndex != -1)
            {
                MateryalButonlari[0].interactable = true;
            }
        }
        else
        {
            if (MateryalIndex != -1)
            {
                MateryalIndex--;

                if (MateryalIndex != -1)
                {
                    Material[] mats = _Renderer.materials;
                    mats[0] = Materyaller[MateryalIndex];
                    _Renderer.materials = mats;
                    MateryalButonlari[0].interactable = true;
                    MateryalText.text = _itemBilgileri[MateryalIndex + 6].ItemAd;

                    if (!_itemBilgileri[MateryalIndex + 6].SatinAlmaDurumu)
                    {
                        textObjeleri[5].text = _itemBilgileri[MateryalIndex + 6].Puan.ToString() + " - " + SatinAlmaText;
                        IslemButonlari[1].interactable = false;
                        if (_bellekyonetim.VeriOku<int>("Puan") < _itemBilgileri[SapkaIndex + 6].Puan)
                            IslemButonlari[0].interactable = false;
                        else
                            IslemButonlari[0].interactable = true;
                    }
                    else
                    {
                        textObjeleri[5].text = SatinAlmaText;
                        IslemButonlari[0].interactable = false;
                        IslemButonlari[1].interactable = true;
                    }
                }
                else
                {
                    Material[] mats = _Renderer.materials;
                    mats[0] = VarsayýlanTema;
                    _Renderer.materials = mats;
                    MateryalButonlari[0].interactable = false;
                    MateryalText.text = ItemText;
                    textObjeleri[5].text = SatinAlmaText;
                    IslemButonlari[0].interactable = false;
                }
            }
            else
            {
                Material[] mats = _Renderer.materials;
                mats[0] = VarsayýlanTema;
                _Renderer.materials = mats;
                MateryalButonlari[0].interactable = false;
                MateryalText.text = ItemText;
                textObjeleri[5].text = SatinAlmaText;
                IslemButonlari[0].interactable = false;
            }

            //--------------------

            if (MateryalIndex != Materyaller.Length - 1)
                MateryalButonlari[1].interactable = true;

        }
    }


    void DurumuKontrolEt(int Bolum, bool islem=false)
    {
        if (Bolum==0)
        {
            if (_bellekyonetim.VeriOku<int>("AktifSapka") == -1)
            {
                foreach (var item in Sapkalar)
                {
                    item.SetActive(false);
                }
                IslemButonlari[0].interactable = false;
                IslemButonlari[1].interactable = false;
                textObjeleri[5].text = SatinAlmaText;
                if (!islem)
                {
                    SapkaIndex = -1;
                    SapkaText.text = ItemText;
                }
            }
            else
            {
                foreach(var item in Sapkalar)
                {
                    item.SetActive(false);
                }
                SapkaIndex = _bellekyonetim.VeriOku<int>("AktifSapka");
                Sapkalar[SapkaIndex].SetActive(true);

                SapkaText.text = _itemBilgileri[SapkaIndex].ItemAd;
                textObjeleri[5].text = SatinAlmaText;
                IslemButonlari[0].interactable = false;
                IslemButonlari[1].interactable = true;
            }
        }else if(Bolum == 1)
        {
            if (_bellekyonetim.VeriOku<int>("AktifSopa") == -1)
            {
                foreach (var item in Sopalar)
                {
                    item.SetActive(false);
                }
                IslemButonlari[0].interactable = false;
                IslemButonlari[1].interactable = false;
                textObjeleri[5].text = SatinAlmaText;
                if (!islem)
                {
                    SopaIndex = -1;
                    SopaText.text = ItemText;
                }
            }
            else
            {
                foreach (var item in Sopalar)
                {
                    item.SetActive(false);
                }
                SopaIndex = _bellekyonetim.VeriOku<int>("AktifSopa");
                Sopalar[SopaIndex].SetActive(true);

                SopaText.text = _itemBilgileri[SopaIndex + 3].ItemAd;
                textObjeleri[5].text = SatinAlmaText;
                IslemButonlari[0].interactable = false;
                IslemButonlari[1].interactable = true;
            }
        }
        else
        {
            if (_bellekyonetim.VeriOku<int>("AktifTema") == -1)
            {
                if (!islem)
                {
                    textObjeleri[5].text = SatinAlmaText;
                    MateryalIndex = -1;
                    MateryalText.text = ItemText;
                    IslemButonlari[0].interactable = false;
                    IslemButonlari[1].interactable = false;
                }
                else
                {
                    Material[] mats = _Renderer.materials;
                    mats[0] = VarsayýlanTema;
                    _Renderer.materials = mats;
                    textObjeleri[5].text = SatinAlmaText;
                }
            }
            else
            {
                MateryalIndex = _bellekyonetim.VeriOku<int>("AktifTema");
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MateryalIndex];
                _Renderer.materials = mats;

                MateryalText.text = _itemBilgileri[MateryalIndex + 6].ItemAd;
                textObjeleri[5].text = SatinAlmaText;
                IslemButonlari[0].interactable = false;
                IslemButonlari[1].interactable = true;
            }
        }
    }

    void SatýnAlmaSonuc(int Index)
    {
        _itemBilgileri[Index].SatinAlmaDurumu = true;
        _bellekyonetim.VeriKaydet("Puan", _bellekyonetim.VeriOku<int>("Puan") - _itemBilgileri[Index].Puan);
        textObjeleri[5].text = SatinAlmaText;
        IslemButonlari[0].interactable = false;
        IslemButonlari[1].interactable = true;
        PuanText.text = _bellekyonetim.VeriOku<int>("Puan").ToString();

    }

    public void SatýnAl()
    {
        Sesler[1].Play();
        if (AktifÝslemPaneliIndex != -1)
        {
            switch (AktifÝslemPaneliIndex) {
                case 0:
                    SatýnAlmaSonuc(SapkaIndex);                
                    break;
                case 1:
                    SatýnAlmaSonuc(SopaIndex + 3);
                    break;
                case 2:
                    SatýnAlmaSonuc(MateryalIndex + 6);
                    break;
            }
        }
    }

    public void Kaydet()
    {
        Sesler[2].Play();
        if (AktifÝslemPaneliIndex != -1)
        {
            switch (AktifÝslemPaneliIndex)
            {
                case 0:
                   _bellekyonetim.VeriKaydet("AktifSapka", SapkaIndex);
                    break;
                case 1:
                    _bellekyonetim.VeriKaydet("AktifSopa", SopaIndex + 3);
                    break;
                case 2:
                    _bellekyonetim.VeriKaydet("AktifTema", MateryalIndex + 6);
                    break;
            }
        }
    }

    public void ÝslemPaneliCýkart(int Index)
    {
        Sesler[0].Play();
        DurumuKontrolEt(Index);
        GenelPaneller[0].SetActive(true);
        AktifÝslemPaneliIndex = Index;
        islemPanelleri[Index].SetActive(true);
        GenelPaneller[1].SetActive(true);
        islemCanvasi.SetActive(false);

    }

    public void GeriDön()
    {
        Sesler[0].Play();
        GenelPaneller[0].SetActive(false);
        islemCanvasi.SetActive(true);
        GenelPaneller[1].SetActive(false);
        islemPanelleri[AktifÝslemPaneliIndex].SetActive(false);
        DurumuKontrolEt(AktifÝslemPaneliIndex,true);
        AktifÝslemPaneliIndex = -1;
       
    }

    public void AnaMenuyeDon()
    {
        Sesler[0].Play();   
        _veriYönetimi.Save(_itemBilgileri);
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
