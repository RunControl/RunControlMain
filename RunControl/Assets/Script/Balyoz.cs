using UnityEngine;

public class Balyoz : MonoBehaviour
{
    [Header("Balyoz Ayarları")]
    public float vurmaAcisi = -90f; // Z ekseninde ne kadar dönecek
    public float beklemeSuresi = 2f; // Her vuruş arasında ne kadar bekleyecek
    public float vurmaHizi = 500f;  // Aşağıya (vurulan yöne) dönüş hızı
    public float donmeGeriHizi = 100f; // Başlangıç konumuna dönüş hızı

    [Header("Sekme Ayarları")]
    public int sekmeSayisi = 4;          // Kaç kez sekme olacak
    public float sekmeAcisi = 5f;        // Sekme açısı (hafif sallanma)
    public float sekmeHizi = 300f;       // Sekme dönüş hızı

    private float zamanlayici = 0f;
    private bool vuruyor = false;
    private bool geriDonuyor = false;
    private bool sekmeYapiliyor = false;

    private int kalanSekmeler = 0;
    private bool sekmeYonUp = true;

    private Quaternion ilkRotation;
    private Quaternion vurmaRotation;

    void Start()
    {
        ilkRotation = transform.localRotation;
        vurmaRotation = Quaternion.Euler(0f, 0f, vurmaAcisi) * ilkRotation;
    }

    void Update()
    {
        zamanlayici += Time.deltaTime;

        if (!vuruyor && !geriDonuyor && !sekmeYapiliyor && zamanlayici >= beklemeSuresi)
        {
            vuruyor = true;
            zamanlayici = 0f;
        }

        if (vuruyor)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, vurmaRotation, vurmaHizi * Time.deltaTime);

            if (Quaternion.Angle(transform.localRotation, vurmaRotation) < 0.5f)
            {
                vuruyor = false;
                geriDonuyor = true;
            }
        }
        else if (geriDonuyor)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, ilkRotation, donmeGeriHizi * Time.deltaTime);

            if (Quaternion.Angle(transform.localRotation, ilkRotation) < 0.5f)
            {
                geriDonuyor = false;
                // Sekme başlat
                sekmeYapiliyor = true;
                kalanSekmeler = sekmeSayisi * 2; // yukarı-aşağı gidip gelmeler
                sekmeYonUp = true;
            }
        }
        else if (sekmeYapiliyor)
        {
            Quaternion hedefRot;

            if (sekmeYonUp)
            {
                hedefRot = Quaternion.Euler(0f, 0f, sekmeAcisi) * ilkRotation;
            }
            else
            {
                hedefRot = ilkRotation;
            }

            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, hedefRot, sekmeHizi * Time.deltaTime);

            if (Quaternion.Angle(transform.localRotation, hedefRot) < 0.5f)
            {
                sekmeYonUp = !sekmeYonUp;

                if (!sekmeYonUp)
                {
                    kalanSekmeler--;
                }

                if (kalanSekmeler <= 0)
                {
                    sekmeYapiliyor = false;
                    zamanlayici = 0f;  // Bekleme süresi için timer sıfırla
                }
            }
        }
    }
}
