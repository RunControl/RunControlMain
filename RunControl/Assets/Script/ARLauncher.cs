using UnityEngine;
using UnityEngine.SceneManagement;

public class ARLauncher : MonoBehaviour
{
    // AR sahnesinin adýný buraya yazýn (Adým 3'te oluþturacaðýmýz sahne)
    public string arSceneName = "ARCharacterScene";

    public void LaunchARMode()
    {
        // Kamera iznini kontrol et (isteðe baðlý ama iyi bir pratik)
        // Android'de ARCore genellikle izni kendi ister, ama manuel de kontrol edilebilir.
        // if (!Application.HasUserAuthorization(UserAuthorization.WebCam)) {
        //     Application.RequestUserAuthorization(UserAuthorization.WebCam);
        // }

        Debug.Log("AR Sahnesi yükleniyor: " + arSceneName);
        SceneManager.LoadScene(arSceneName);
    }
}
