using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Batu;
using System.Collections.Generic;
using TMPro;
public class Ayarlar_Manager : MonoBehaviour
{
    public AudioSource buttonSes;
    public Slider MenuSes;
    public Slider MenuFx;
    public Slider OyunSes;
    BellekYonetim _bellekYonetimi = new BellekYonetim();
    VeriYönetimi _veriYönetimi = new VeriYönetimi();

    public List<DilVerileriAnaObje> _DilVerileriOkunan = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();

    public TextMeshProUGUI[] textObjeleri;
    public TextMeshProUGUI DilText;
    int aktifDilIndex;

    public Button[] DilButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSes.volume = _bellekYonetimi.VeriOku<float>("MenuFx");

        MenuSes.value = _bellekYonetimi.VeriOku<float>("MenuSes");
        MenuFx.value = _bellekYonetimi.VeriOku<float>("MenuFx");
        OyunSes.value = _bellekYonetimi.VeriOku<float>("OyunSes");

        _veriYönetimi.Dil_Load();
        _DilVerileriOkunan = _veriYönetimi.DilListeyiAktar();
        _DilVerileriAnaObje.Add(_DilVerileriOkunan[4]);
        DilTercihiYönetimi();
        DilDurumunuKontrolEt();
    }

    public void DilTercihiYönetimi()
    {
        if (_bellekYonetimi.VeriOku<string>("Dil") == "TR")
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

    public void GeriDon()
    {
        buttonSes.Play();
        SceneManager.LoadScene(0);
    }

    void DilDurumunuKontrolEt()
    {
        if(_bellekYonetimi.VeriOku<string>("Dil") == "TR")
        {
            aktifDilIndex = 0;
            DilText.text = "Turkish";
            DilButton[0].interactable = false;
        }
        else
        {
            aktifDilIndex = 1;
            DilText.text = "English";
            DilButton[1].interactable = false;
        }

    }
    public void SesAyarla(string HangiAyar)
    {
        switch (HangiAyar)
        {
            case "MenuSes":
                PlayerPrefs.SetFloat("MenuSes", MenuSes.value);
                break;
            case "MenuFx":
                PlayerPrefs.SetFloat("MenuFx", MenuFx.value);
                break;
            case "OyunSes":
                PlayerPrefs.SetFloat("OyunSes", OyunSes.value);
                break;
        }
    }
    public void DilDegistir(string yon)
    {
        buttonSes.Play();
        if (yon == "ileri")
        {
            aktifDilIndex = 1;
            DilText.text = "English";
            DilButton[1].interactable = false;
            DilButton[0].interactable = true;
            _bellekYonetimi.VeriKaydet("Dil", "EN");
            DilTercihiYönetimi();
        }
        else
        {
            aktifDilIndex = 0;
            DilText.text = "Turkish";
            DilButton[0].interactable = false;
            DilButton[1].interactable = true;
            _bellekYonetimi.VeriKaydet("Dil", "TR");
            DilTercihiYönetimi();
        }
    }
}
