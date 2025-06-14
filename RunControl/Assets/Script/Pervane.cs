using UnityEngine;

public class Pervane : MonoBehaviour
{
    [Header("Pervane Ayarlar�")]
    public float donmeHizi = 200f; // Z ekseninde d�nme h�z�
    public float donmeSuresi = 3f; // Ka� saniye d�necek
    public float beklemeSuresi = 5f; // Ka� saniyede bir d�nmeye ba�las�n

    [Header("R�zgar Ayarlar�")]
    public float ruzgarGucu = 10f; // Uygulanacak kuvvet
    public float ruzgarEtkiMesafesi = 5f; // Etki alan� mesafesi
    public LayerMask etkilenecekKatman; // Sadece karakter katman�n� se�

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
            // Pervaneyi d�nd�r
            transform.Rotate(0f, 0f, donmeHizi * Time.deltaTime);

            // R�zgarla �n�ndeki nesneleri it
            KarakterleriIt();

            // D�nme s�resi dolduysa dur
            donusZamani += Time.deltaTime;
            if (donusZamani >= donmeSuresi)
            {
                donuyor = false;
            }
        }
    }

    void KarakterleriIt()
    {
        // Etki alan� i�inde olan nesneleri bul
        RaycastHit[] hitler = Physics.SphereCastAll(
            transform.position,
            1f,
            transform.forward,
            ruzgarEtkiMesafesi,
            etkilenecekKatman
        );

        // R�zgar g�c�n� zamanla artt�rmak i�in normalize edilmi� oran hesapla (0-1 aras�)
        float zamanOrani = Mathf.Clamp01(donusZamani / donmeSuresi); // 0 ? ba�lama, 1 ? biti�
        float anlikRuzgarGucu = Mathf.Lerp(0, ruzgarGucu, zamanOrani); // G�� zamanla arts�n

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
