using UnityEngine;

public class Pervane : MonoBehaviour
{
    [Header("Pervane Ayarlarý")]
    public float donmeHizi = 200f; // Z ekseninde dönme hýzý
    public float donmeSuresi = 3f; // Kaç saniye dönecek
    public float beklemeSuresi = 5f; // Kaç saniyede bir dönmeye baþlasýn

    [Header("Rüzgar Ayarlarý")]
    public float ruzgarGucu = 10f; // Uygulanacak kuvvet
    public float ruzgarEtkiMesafesi = 5f; // Etki alaný mesafesi
    public LayerMask etkilenecekKatman; // Sadece karakter katmanýný seç

    private float zamanlayici = 0f;
    private bool donuyor = false;
    private float donusZamani = 0f;

    void Update()
    {
        zamanlayici += Time.deltaTime;

        if (!donuyor && zamanlayici >= beklemeSuresi)
        {
            donuyor = true;
            donusZamani = 0f;
            zamanlayici = 0f;
        }

        if (donuyor)
        {
            // Pervaneyi döndür
            transform.Rotate(0f, 0f, donmeHizi * Time.deltaTime);

            // Rüzgarla önündeki nesneleri it
            KarakterleriIt();

            // Dönme süresi dolduysa dur
            donusZamani += Time.deltaTime;
            if (donusZamani >= donmeSuresi)
            {
                donuyor = false;
            }
        }
    }

    void KarakterleriIt()
    {
        // Etki alaný içinde olan nesneleri bul
        RaycastHit[] hitler = Physics.SphereCastAll(
            transform.position,
            1f,
            transform.forward,
            ruzgarEtkiMesafesi,
            etkilenecekKatman
        );

        // Rüzgar gücünü zamanla arttýrmak için normalize edilmiþ oran hesapla (0-1 arasý)
        float zamanOrani = Mathf.Clamp01(donusZamani / donmeSuresi); // 0 ? baþlama, 1 ? bitiþ
        float anlikRuzgarGucu = Mathf.Lerp(0, ruzgarGucu, zamanOrani); // Güç zamanla artsýn

        foreach (RaycastHit hit in hitler)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null)
            {
                Vector3 itmeYon = (hit.transform.position - transform.position).normalized;
                rb.AddForce(itmeYon * anlikRuzgarGucu * Time.deltaTime * 50f, ForceMode.Force);
            }
        }
    }

}
