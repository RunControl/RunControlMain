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
    VeriY�netimi _veriY�netimi = new VeriY�netimi();
    public AudioSource buttonSes;

    public List<DilVerileriAnaObje> _Varsay�lanDilVerileriAnaObje = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriOkunan = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();

    public TextMeshProUGUI[] textObjeleri;

    public GameObject Y�klemeEkrani;
    public Slider Y�klemeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bellekYonetim.KontrolEtveTan�mla();
        _veriY�netimi.ilkKurulumDosyaOlusturma(_itemBilgileri, _Varsay�lanDilVerileriAnaObje); // di�er t�m itemlar bitince aktifle�tir
        buttonSes.volume = _bellekYonetim.VeriOku<float>("MenuFx");

        _veriY�netimi.Dil_Load();
        _DilVerileriOkunan = _veriY�netimi.DilListeyiAktar();
        _DilVerileriAnaObje.Add(_DilVerileriOkunan[0]);
        DilTercihiY�netimi();
 

    }

    public void DilTercihiY�netimi()
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
        Y�klemeEkrani.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Y�klemeSlider.value = progress;
            yield return null;
        }

    }

    public void C�k�s(bool control)
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
