using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using Batu;
using System.Data;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject VarisNoktasi;
    public int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokolmaEfektleri;
    public List<GameObject> AdamLekesiEfektleri;

    [Header("Level verileri")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject AnaKarakter;
    public bool SonaGeldikMi;
    public bool OyunBittiMi;

    [Header("SAPKALAR")]
    public GameObject[] Sapkalar;

    [Header("Sopalar")]
    public GameObject[] Sopalar;

    [Header("Materyaller")]
    public Material[] Materyaller;
    public SkinnedMeshRenderer _Renderer;
    public Material VarsayýlanTema;
    public AudioSource[] Sesler;
    public GameObject[] islemPanelleri;
    public UnityEngine.UI.Slider oyunSesiAyar;

    BellekYonetim _bellekYonetim = new BellekYonetim();
    VeriYönetimi _veriYönetimi = new VeriYönetimi();
    ReklamYonetimi _reklamYonetimi = new ReklamYonetimi();
    Scene _scene;

    public List<DilVerileriAnaObje> _DilVerileriOkunan = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    public TextMeshProUGUI[] textObjeleri;

    public GameObject YüklemeEkrani;
    public UnityEngine.UI.Slider YüklemeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Sesler[0].volume = _bellekYonetim.VeriOku<float>("OyunSes");
        oyunSesiAyar.value = _bellekYonetim.VeriOku<float>("OyunSes");
        Sesler[1].volume = _bellekYonetim.VeriOku<float>("MenuFx");
        Destroy(GameObject.FindWithTag("MenuSes"));
        ItemleriKontrolEt();
    }
    void Start()
    {
        DusmanlarýOlustur();
        _scene = SceneManager.GetActiveScene();

        _veriYönetimi.Dil_Load();
        _DilVerileriOkunan = _veriYönetimi.DilListeyiAktar();
        _DilVerileriAnaObje.Add(_DilVerileriOkunan[5]);
        DilTercihiYönetimi();

        _reklamYonetimi.RequestInterstitial();

    }

    public void DilTercihiYönetimi()
    {
        if (_bellekYonetim.VeriOku<string>("Dil") == "TR")
        {

            for (int i = 0; i < textObjeleri.Length; i++)
            {
                textObjeleri[i].text = _DilVerileriAnaObje[0].DilVerileri_TR[i].Metin;
            }
        }
        else
        {

            for (int i = 0; i < textObjeleri.Length; i++)
            {
                textObjeleri[i].text = _DilVerileriAnaObje[0].DilVerileri_EN[i].Metin;
            }
        }
    }

    public void DusmanlarýOlustur()
    {
        for (int i = 0; i < KacDusmanOlsun; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }

    public void DusmanlariTetikle()
    {
        foreach(var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
        SonaGeldikMi = true;
        SavasDurumu();
    }

    public void SavasDurumu()
    {
        if (SonaGeldikMi)
        {
            if (AnlikKarakterSayisi == 1 || KacDusmanOlsun == 0)
            {
                OyunBittiMi = true;
                foreach (var item in Dusmanlar)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldýr", false);
                    }
                }

                foreach (var item in Karakterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldýr", false);
                    }
                }

                AnaKarakter.GetComponent<Animator>().SetBool("Saldýr", false);
                _reklamYonetimi.ShowInterstitial();

                if (AnlikKarakterSayisi < KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun)
                {
                    islemPanelleri[3].SetActive(true);
                    //Debug.Log("Kaybettin");
                }
                else
                {
                    if (_scene.buildIndex == -_bellekYonetim.VeriOku<int>("SonLevel"))
                    {
                        _bellekYonetim.VeriKaydet("Puan", _bellekYonetim.VeriOku<int>("Puan") + 600);
                        _bellekYonetim.VeriKaydet("SonLevel", _bellekYonetim.VeriOku<int>("SonLevel") + 1);
                    }
                    islemPanelleri[2].SetActive(true);
                    //Debug.Log("Kazandýn");

                }
            }
        }  
    }


    public void ItemleriKontrolEt()
    {
        if(_bellekYonetim.VeriOku<int>("AktifSapka") != -1)
            Sapkalar[_bellekYonetim.VeriOku<int>("AktifSapka")].SetActive(true);
        
        if (_bellekYonetim.VeriOku<int>("AktifSopa") != -1)
            Sopalar[_bellekYonetim.VeriOku<int>("AktifSopa")].SetActive(true);

        if (_bellekYonetim.VeriOku<int>("AktifTema") != -1)
        {
            Material[] mats = _Renderer.materials;
            mats[0] = Materyaller[_bellekYonetim.VeriOku<int>("AktifTema")];
            _Renderer.materials = mats;
        }
        else
        {
            Material[] mats = _Renderer.materials;
            mats[0] = VarsayýlanTema;
            _Renderer.materials = mats;
        }


    }

    public void Cýkýs(string durum)
    {
        Sesler[1].Play();
        Time.timeScale = 0;
        if (durum == "durdur")
        {
            islemPanelleri[0].SetActive(true);
        }
        else if (durum == "devamet")
        {
            islemPanelleri[0].SetActive(false);
            Time.timeScale = 1;
        }
        else if (durum == "tekrar")
        {
            SceneManager.LoadScene(_scene.buildIndex);
            Time.timeScale = 1;
        }
        else if (durum == "anasayfa")
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }

    public void Ayarlar(string durum)
    {
        if (durum == "ayarla")
        {
            islemPanelleri[1].SetActive(true);
            Time.timeScale = 0;
        }
        else 
        {
            islemPanelleri[1].SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void SesiAyarla()
    {
        _bellekYonetim.VeriKaydet("OyunSes", oyunSesiAyar.value);
        Sesler[0].volume = oyunSesiAyar.value;

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SonrakiLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
        StartCoroutine(LoadAsync(_scene.buildIndex + 1));
    }

    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        YüklemeEkrani.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            YüklemeSlider.value = progress;
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
