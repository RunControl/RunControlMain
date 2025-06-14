using UnityEngine;

public class Kamera2 : MonoBehaviour
{
    // Transform position,rotation ve scale gibi bilgileri tutar
    public Transform target;
    // 3 boyutlu uzaydaki konum, yön ve hýz gibi vektörel deðerleri
    public Vector3 target_offset;
    public bool SonaGeldikMi;
    public GameObject gidecegiYer;
    void Start()
    {
        target_offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if(!SonaGeldikMi)
           transform.position = Vector3.Lerp(transform.position, target.position + target_offset,.125f);
        else
           transform.position = Vector3.Lerp(transform.position, gidecegiYer.transform.position, .015f);
    }
}
