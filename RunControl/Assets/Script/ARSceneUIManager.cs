using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSceneUIManager : MonoBehaviour
{
    // Özelleþtirme sahnenizin tam adýný buraya yazýn
    // Bu, ilk sahnede ARLauncher script'inde kullandýðýnýz sahnenin adý olmalý
    public string customizationSceneName = "OzellestirmeEkrani"; // Örnek bir isim, kendi sahne adýnýzý yazýn

    public void GoToCustomizationScene()
    {
        if (string.IsNullOrEmpty(customizationSceneName))
        {
            Debug.LogError("Özelleþtirme sahnesi adý ARSceneUIManager script'inde belirtilmemiþ!");
            return;
        }

        Debug.Log(customizationSceneName + " sahnesine geri dönülüyor...");
        SceneManager.LoadScene(1);
    }
}