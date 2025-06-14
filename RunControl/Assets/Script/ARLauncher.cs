using UnityEngine;
using UnityEngine.SceneManagement;

public class ARLauncher : MonoBehaviour
{
    // AR sahnesinin ad�n� buraya yaz�n (Ad�m 3'te olu�turaca��m�z sahne)
    public string arSceneName = "ARCharacterScene";

    public void LaunchARMode()
    {
        // Kamera iznini kontrol et (iste�e ba�l� ama iyi bir pratik)
        // Android'de ARCore genellikle izni kendi ister, ama manuel de kontrol edilebilir.
        // if (!Application.HasUserAuthorization(UserAuthorization.WebCam)) {
        //     Application.RequestUserAuthorization(UserAuthorization.WebCam);
        // }

        Debug.Log("AR Sahnesi y�kleniyor: " + arSceneName);
        SceneManager.LoadScene(arSceneName);
    }
}
