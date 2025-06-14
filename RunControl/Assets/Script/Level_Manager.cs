using UnityEngine;
using UnityEngine.SceneManagement;
using Batu;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;
using System.Collections;
public class Level_Manager : MonoBehaviour
{
    public Button[] Butonlar;
    public Sprite KilitliButon;
    public AudioSource buttonSes;

    BellekYonetim _bellekYonetim = new BellekYonetim();
    VeriY�netimi _veriY�netimi = new VeriY�netimi();

    public List<DilVerileriAnaObje> _DilVerileriOkunan = new List<DilVerileriAnaObje>();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();

    public TextMeshProUGUI[] textObjeleri;

    public GameObject Y�klemeEkrani;
    public Slider Y�klemeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSes.volume = _bellekYonetim.VeriOku<float>("MenuFx");

        int mevcutLevel = _bellekYonetim.VeriOku<int>("SonLevel") - 4;

        int Index = 1;
        for (int i = 0; i < Butonlar.Length; i++)
        {
            if (i + 1 <= mevcutLevel)
            {
                Butonlar[i].GetComponentInChildren<TextMeshProUGUI>().text = Index.ToString();
                int SahneIndex = Index + 4;
                Butonlar[i].onClick.AddListener(delegate { SahneYukle(SahneIndex); });
            }
            else
            {
                Butonlar[i].GetComponent<Image>().sprite = KilitliButon;
                Butonlar[i].enabled = false;
            }
            Index++;
        }

        _veriY�netimi.Dil_Load();
        _DilVerileriOkunan = _veriY�netimi.DilListeyiAktar();
        _DilVerileriAnaObje.Add(_DilVerileriOkunan[2]);
        DilTercihiY�netimi();
    }

    public void DilTercihiY�netimi()
    {
        if (_bellekYonetim.VeriOku<string>("Dil") == "TR")
        {
                textObjeleri[0].text = _DilVerileriAnaObje[0].DilVerileri_TR[2].Metin;
        }
        else
        {
                textObjeleri[0].text = _DilVerileriAnaObje[0].DilVerileri_EN[2].Metin;
        }
    }

    public void SahneYukle(int Index)
    {
        buttonSes.Play();
        SceneManager.LoadScene(Index);
        StartCoroutine(LoadAsync(Index));
    }

    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        Y�klemeEkrani.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Y�klemeSlider.value = progress;
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeriDon()
    {
        buttonSes.Play();
        SceneManager.LoadScene(0);
    }
}
