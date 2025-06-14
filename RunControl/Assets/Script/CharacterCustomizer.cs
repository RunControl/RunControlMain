using UnityEngine;
using UnityEngine.UIElements;

public class CharacterCustomizer : MonoBehaviour
{
    // Inspector'dan atanacak �apka objeleri dizisi
    public GameObject[] hats;
    // Inspector'dan atanacak sopa objeleri dizisi
    public GameObject[] sticks;
    // Inspector'dan atanacak sopa objeleri dizisi
    public Material[] skins;
    public Material defaulSkin;
    public SkinnedMeshRenderer _Renderer;

    // PlayerPrefs anahtarlar� (�zelle�tirme ekran�nda kulland�klar�n�zla ayn� olmal�)
    private string hatIndexKey = "AktifSapka";
    private string stickIndexKey = "AktifSopa";
    private string skinIndexKey = "AktifTema";

    void Awake() // veya Start() - obje aktif oldu�unda �al���r
    {
        ApplyCustomization();
    }

    public void ApplyCustomization()
    {
        // PlayerPrefs'ten se�ili indexleri oku
        // �kinci parametre, anahtar bulunamazsa d�necek varsay�lan de�erdir (-1, "hi�biri se�ili de�il" anlam�na gelebilir)
        int selectedHatIndex = PlayerPrefs.GetInt(hatIndexKey, -1);
        int selectedStickIndex = PlayerPrefs.GetInt(stickIndexKey, -1);
        int selectedSkinIndex = PlayerPrefs.GetInt(skinIndexKey, -1);


        // T�m �apkalar� devre d��� b�rak
        for (int i = 0; i < hats.Length; i++)
        {
            if (hats[i] != null)
            {
                hats[i].SetActive(false);
            }
        }

        // T�m sopalar� devre d��� b�rak
        for (int i = 0; i < sticks.Length; i++)
        {
            if (sticks[i] != null)
            {
                sticks[i].SetActive(false);
            }
        }

        // Se�ili �apkay� aktif et (e�er ge�erli bir index ise)
        if (selectedHatIndex >= 0 && selectedHatIndex < hats.Length && hats[selectedHatIndex] != null)
        {
            hats[selectedHatIndex].SetActive(true);
        }


        // Se�ili sopay� aktif et (e�er ge�erli bir index ise)
        if (selectedStickIndex >= 0 && selectedStickIndex < sticks.Length && sticks[selectedStickIndex] != null)
        {
            sticks[selectedStickIndex].SetActive(true);
        }

        if (selectedSkinIndex >= 0 && selectedSkinIndex < sticks.Length && sticks[selectedSkinIndex] != null)
        {
            Material[] mats = _Renderer.materials;
            mats[0] = skins[selectedSkinIndex];
            _Renderer.materials = mats;
        }
        else
        {
            Material[] mats = _Renderer.materials;
            mats[0] = defaulSkin;
            _Renderer.materials = mats;
        }
            

    }
}