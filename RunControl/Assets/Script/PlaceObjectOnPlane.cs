using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; // AR Foundation için
using UnityEngine.XR.ARSubsystems; // TrackableType için

[RequireComponent(typeof(ARRaycastManager))] // Bu scriptin olduðu objeye ARRaycastManager eklenmesini zorunlu kýlar
public class PlaceObjectOnPlane : MonoBehaviour
{
    public GameObject objectToPlacePrefab; // Yerleþtirilecek karakter prefabý
    private GameObject placedObject;       // Sahneye yerleþtirilmiþ obje örneði
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>(); // Raycast hitlerini saklamak için

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        if (objectToPlacePrefab == null)
        {
            Debug.LogError("Object to Place Prefab atanmamýþ!");
            enabled = false; // Prefab yoksa scripti devre dýþý býrak
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            // Ekrana dokunulan noktadan bir ýþýn gönder ve algýlanan düzlemlerle kesiþip kesiþmediðini kontrol et
            if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                // Ýlk kesiþen düzlemi al
                Pose hitPose = hits[0].pose;

                if (placedObject == null) // Eðer daha önce obje yerleþtirilmemiþse
                {
                    // Prefab'ý düzlemin üzerinde oluþtur
                    placedObject = Instantiate(objectToPlacePrefab, hitPose.position, hitPose.rotation);
                    Debug.Log("Karakter yerleþtirildi!");

                    // Ýsteðe baðlý: Modeli kameraya doðru döndür (sadece Y ekseninde)
                    Vector3 lookAtPosition = Camera.main.transform.position;
                    lookAtPosition.y = placedObject.transform.position.y; // Y ekseninde ayný hizada kalmasýný saðla
                    placedObject.transform.LookAt(lookAtPosition);

                }
                else // Eðer obje zaten varsa, pozisyonunu güncelle
                {
                    placedObject.transform.position = hitPose.position;
                    // Ýsteðe baðlý: Rotasyonu da güncelleyebilirsin veya sabit býrakabilirsin
                    // placedObject.transform.rotation = hitPose.rotation;

                    // Ýsteðe baðlý: Modeli kameraya doðru döndür (sadece Y ekseninde)
                    Vector3 lookAtPosition = Camera.main.transform.position;
                    lookAtPosition.y = placedObject.transform.position.y;
                    placedObject.transform.LookAt(lookAtPosition);

                    Debug.Log("Karakterin yeri güncellendi!");
                }
            }
        }
    }
}