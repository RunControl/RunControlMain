using UnityEngine;

public class Testere : MonoBehaviour
{
    [Header("Genel Ayarlar")]
    public int donmeHizi = 100;             // D�nme h�z�
    public float hareketHizi = 2f;          // X ekseninde ileri-geri hareket h�z�
    public float hareketUzunlugu = 3f;      // Ne kadar ileri geri gidecek

    [Header("Davran�� Kontrolleri")]
    public bool sadeceDonmeAktif = true;    // Sadece d�nme aktif mi?
    public bool donmeVeHareketAktif = false;// D�nme + hareket aktif mi?

    [Header("D�n�� Eksenleri")]
    public bool donX = false;               // X ekseninde d�ns�n m�?
    public bool donY = false;               // Y ekseninde d�ns�n m�?
    public bool donZ = true;                // Z ekseninde d�ns�n m�? (Varsay�lan)

    private Vector3 baslangicKonumu;        // Ba�lang�� pozisyonunu sakla

    void Start()
    {
        baslangicKonumu = transform.position;
    }

    void Update()
    {
        // Davran�� �nceli�i: E�er hem 'sadeceDonmeAktif' hem de 'donmeVeHareketAktif' true ise,
        // 'donmeVeHareketAktif' �ncelikli �al���r.
        // E�er ikisi de false ise, hi�bir �ey olmaz.
        // Genellikle bu iki bool'dan sadece biri true olmal�d�r.

        if (donmeVeHareketAktif)
        {
            TesterePlatformHareket();
        }
        else if (sadeceDonmeAktif)
        {
            TestereDon();
        }
    }

    void TestereDon()
    {
        float xRotation = 0f;
        float yRotation = 0f;
        float zRotation = 0f;

        if (donX)
        {
            xRotation = donmeHizi * Time.deltaTime;
        }
        if (donY)
        {
            yRotation = donmeHizi * Time.deltaTime;
        }
        if (donZ)
        {
            zRotation = donmeHizi * Time.deltaTime;
        }

        // Belirlenen eksenlerde d�nd�r
        transform.Rotate(xRotation, yRotation, zRotation);
    }

    void TesterePlatformHareket()
    {
        // D�nme i�lemini merkezi fonksiyona devret
        TestereDon();

        // X ekseninde ileri-geri hareket: Ping-pong �eklinde
        // baslangicKonumu.x'e g�re hareket eder. E�er hareketin ortas� ba�lang�� konumu olsun isterseniz
        // hesaplama biraz de�i�ir: baslangicKonumu.x - (hareketUzunlugu / 2f) + Mathf.PingPong(...)
        float yeniX = baslangicKonumu.x + Mathf.PingPong(Time.time * hareketHizi, hareketUzunlugu);
        transform.position = new Vector3(yeniX, transform.position.y, transform.position.z);
    }
}