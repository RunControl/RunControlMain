using UnityEngine;
using UnityEngine.SceneManagement;

public class ARSceneUIManager : MonoBehaviour
{
    // �zelle�tirme sahnenizin tam ad�n� buraya yaz�n
    // Bu, ilk sahnede ARLauncher script'inde kulland���n�z sahnenin ad� olmal�
    public string customizationSceneName = "OzellestirmeEkrani"; // �rnek bir isim, kendi sahne ad�n�z� yaz�n

    public void GoToCustomizationScene()
    {
        if (string.IsNullOrEmpty(customizationSceneName))
        {
            Debug.LogError("�zelle�tirme sahnesi ad� ARSceneUIManager script'inde belirtilmemi�!");
            return;
        }

        Debug.Log(customizationSceneName + " sahnesine geri d�n�l�yor...");
        SceneManager.LoadScene(1);
    }
}