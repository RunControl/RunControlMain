using UnityEngine;
using UnityEngine.SceneManagement;
using Batu;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class AnaMenuManager : MonoBehaviour
{

    BellekYonetim _bellekYonetim = new BellekYonetim();
    public GameObject CikisPaneli;
    public List<ItemBilgileri> _itemBilgileri = new List<ItemBilgileri>();
    VeriYönetimi _veriYönetimi = new VeriYönetimi();
    public AudioSource buttonSes;

    public List<DilVerileriAnaObje> _VarsayýlanDilVerileriAnaObje = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriOkunan = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();

    public TextMeshProUGUI[] textObjeleri;

    public GameObject YüklemeEkrani;
    public Slider YüklemeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bellekYonetim.KontrolEtveTanýmla();
        _veriYönetimi.ilkKurulumDosyaOlusturma(_itemBilgileri, _VarsayýlanDilVerileriAnaObje); // diðer tüm itemlar bitince aktifleþtir
        buttonSes.volume = _bellekYonetim.VeriOku<float>("MenuFx");

        _veriYönetimi.Dil_Load();
        _DilVerileriOkunan = _veriYönetimi.DilListeyiAktar();
        _DilVerileriAnaObje.Add(_DilVerileriOkunan[0]);
        DilTercihiYönetimi();
 

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

    public void SahneYukle(int Index)
    {
        buttonSes.Play();
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {
        buttonSes.Play();
        SceneManager.LoadScene(_bellekYonetim.VeriOku<int>("SonLevel"));
        Debug.Log(_bellekYonetim.VeriOku<int>("SonLevel"));
        StartCoroutine(LoadAsync(_bellekYonetim.VeriOku<int>("SonLevel")));
    }

    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        YüklemeEkrani.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            YüklemeSlider.value = progress;
            yield return null;
        }

    }

    public void Cýkýs(bool control)
    {
        buttonSes.Play();
        if (control) 
            CikisPaneli.SetActive(true);
        else
            CikisPaneli.SetActive(false);
    }

    public void Quit()
    {
            Application.Quit();
    }


}
