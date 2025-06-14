using UnityEngine;
using UnityEngine.UIElements;

public class CharacterCustomizer : MonoBehaviour
{
    // Inspector'dan atanacak þapka objeleri dizisi
    public GameObject[] hats;
    // Inspector'dan atanacak sopa objeleri dizisi
    public GameObject[] sticks;
    // Inspector'dan atanacak sopa objeleri dizisi
    public Material[] skins;
    public Material defaulSkin;
    public SkinnedMeshRenderer _Renderer;

    // PlayerPrefs anahtarlarý (Özelleþtirme ekranýnda kullandýklarýnýzla ayný olmalý)
    private string hatIndexKey = "AktifSapka";
    private string stickIndexKey = "AktifSopa";
    private string skinIndexKey = "AktifTema";

    void Awake() // veya Start() - obje aktif olduðunda çalýþýr
    {
        ApplyCustomization();
    }

    public void ApplyCustomization()
    {
        // PlayerPrefs'ten seçili indexleri oku
        // Ýkinci parametre, anahtar bulunamazsa dönecek varsayýlan deðerdir (-1, "hiçbiri seçili deðil" anlamýna gelebilir)
        int selectedHatIndex = PlayerPrefs.GetInt(hatIndexKey, -1);
        int selectedStickIndex = PlayerPrefs.GetInt(stickIndexKey, -1);
        int selectedSkinIndex = PlayerPrefs.GetInt(skinIndexKey, -1);


        // Tüm þapkalarý devre dýþý býrak
        for (int i = 0; i < hats.Length; i++)
        {
            if (hats[i] != null)
            {
                hats[i].SetActive(false);
            }
        }

        // Tüm sopalarý devre dýþý býrak
        for (int i = 0; i < sticks.Length; i++)
        {
            if (sticks[i] != null)
            {
                sticks[i].SetActive(false);
            }
        }

        // Seçili þapkayý aktif et (eðer geçerli bir index ise)
        if (selectedHatIndex >= 0 && selectedHatIndex < hats.Length && hats[selectedHatIndex] != null)
        {
            hats[selectedHatIndex].SetActive(true);
        }


        // Seçili sopayý aktif et (eðer geçerli bir index ise)
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