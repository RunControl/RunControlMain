using UnityEngine;

public class Testere : MonoBehaviour
{
    [Header("Genel Ayarlar")]
    public int donmeHizi = 100;             // Dönme hýzý
    public float hareketHizi = 2f;          // X ekseninde ileri-geri hareket hýzý
    public float hareketUzunlugu = 3f;      // Ne kadar ileri geri gidecek

    [Header("Davranýþ Kontrolleri")]
    public bool sadeceDonmeAktif = true;    // Sadece dönme aktif mi?
    public bool donmeVeHareketAktif = false;// Dönme + hareket aktif mi?

    [Header("Dönüþ Eksenleri")]
    public bool donX = false;               // X ekseninde dönsün mü?
    public bool donY = false;               // Y ekseninde dönsün mü?
    public bool donZ = true;                // Z ekseninde dönsün mü? (Varsayýlan)

    private Vector3 baslangicKonumu;        // Baþlangýç pozisyonunu sakla

    void Start()
    {
        baslangicKonumu = transform.position;
    }

    void Update()
    {
        // Davranýþ önceliði: Eðer hem 'sadeceDonmeAktif' hem de 'donmeVeHareketAktif' true ise,
        // 'donmeVeHareketAktif' öncelikli çalýþýr.
        // Eðer ikisi de false ise, hiçbir þey olmaz.
        // Genellikle bu iki bool'dan sadece biri true olmalýdýr.

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

        // Belirlenen eksenlerde döndür
        transform.Rotate(xRotation, yRotation, zRotation);
    }

    void TesterePlatformHareket()
    {
        // Dönme iþlemini merkezi fonksiyona devret
        TestereDon();

        // X ekseninde ileri-geri hareket: Ping-pong þeklinde
        // baslangicKonumu.x'e göre hareket eder. Eðer hareketin ortasý baþlangýç konumu olsun isterseniz
        // hesaplama biraz deðiþir: baslangicKonumu.x - (hareketUzunlugu / 2f) + Mathf.PingPong(...)
        float yeniX = baslangicKonumu.x + Mathf.PingPong(Time.time * hareketHizi, hareketUzunlugu);
        transform.position = new Vector3(yeniX, transform.position.y, transform.position.z);
    }
}