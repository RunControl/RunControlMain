using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; // AR Foundation i�in
using UnityEngine.XR.ARSubsystems; // TrackableType i�in

[RequireComponent(typeof(ARRaycastManager))] // Bu scriptin oldu�u objeye ARRaycastManager eklenmesini zorunlu k�lar
public class PlaceObjectOnPlane : MonoBehaviour
{
    public GameObject objectToPlacePrefab; // Yerle�tirilecek karakter prefab�
    private GameObject placedObject;       // Sahneye yerle�tirilmi� obje �rne�i
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>(); // Raycast hitlerini saklamak i�in

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        if (objectToPlacePrefab == null)
        {
            Debug.LogError("Object to Place Prefab atanmam��!");
            enabled = false; // Prefab yoksa scripti devre d��� b�rak
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            // Ekrana dokunulan noktadan bir ���n g�nder ve alg�lanan d�zlemlerle kesi�ip kesi�medi�ini kontrol et
            if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                // �lk kesi�en d�zlemi al
                Pose hitPose = hits[0].pose;

                if (placedObject == null) // E�er daha �nce obje yerle�tirilmemi�se
                {
                    // Prefab'� d�zlemin �zerinde olu�tur
                    placedObject = Instantiate(objectToPlacePrefab, hitPose.position, hitPose.rotation);
                    Debug.Log("Karakter yerle�tirildi!");

                    // �ste�e ba�l�: Modeli kameraya do�ru d�nd�r (sadece Y ekseninde)
                    Vector3 lookAtPosition = Camera.main.transform.position;
                    lookAtPosition.y = placedObject.transform.position.y; // Y ekseninde ayn� hizada kalmas�n� sa�la
                    placedObject.transform.LookAt(lookAtPosition);

                }
                else // E�er obje zaten varsa, pozisyonunu g�ncelle
                {
                    placedObject.transform.position = hitPose.position;
                    // �ste�e ba�l�: Rotasyonu da g�ncelleyebilirsin veya sabit b�rakabilirsin
                    // placedObject.transform.rotation = hitPose.rotation;

                    // �ste�e ba�l�: Modeli kameraya do�ru d�nd�r (sadece Y ekseninde)
                    Vector3 lookAtPosition = Camera.main.transform.position;
                    lookAtPosition.y = placedObject.transform.position.y;
                    placedObject.transform.LookAt(lookAtPosition);

                    Debug.Log("Karakterin yeri g�ncellendi!");
                }
            }
        }
    }
}