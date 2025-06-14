using UnityEngine;

public class Hareket : MonoBehaviour
{
    [Header("Ýtme Ayarlarý")]
    public float itmeGucu = 10f; // Karakterin ne kadar kuvvetle itileceði
    public ForceMode itmeTipi = ForceMode.Impulse; // Ýtme kuvvetinin nasýl uygulanacaðý (Impulse ani bir itme saðlar)

    [Header("Hedef Tag'leri")]
    public string anaKarakterTag = "anakarakter";
    public string altKarakterTag = "altkarakter";

    // Bu script'in baðlý olduðu obje baþka bir obje ile çarpýþtýðýnda bu fonksiyon çalýþýr.
    void OnCollisionEnter(Collision collision)
    {
        // Çarpýþan nesnenin tag'ini kontrol et
        if (collision.gameObject.CompareTag(anaKarakterTag) || collision.gameObject.CompareTag(altKarakterTag))
        {
            // Çarpýþan nesnenin Rigidbody bileþenini al
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            // Eðer Rigidbody varsa (yani fiziksel bir nesneyse)
            if (rb != null)
            {
                // Ýtme yönünü bu objenin ileri (local Z) yönü olarak belirle
                Vector3 itmeYon = transform.forward; // Bu objenin baktýðý yön (kendi Z ekseni)

                // Rigidbody'e kuvvet uygula
                rb.AddForce(itmeYon * itmeGucu, itmeTipi);

                Debug.Log(collision.gameObject.name + " adlý obje, " + gameObject.name + " tarafýndan itildi!");
            }
            else
            {
                Debug.LogWarning(collision.gameObject.name + " üzerinde Rigidbody bulunamadý. Ýtme iþlemi yapýlamadý.");
            }
        }
    }


    // Ýtme yönünü görselleþtirmek için (Scene view'da görünür)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        // Bu objenin pozisyonundan baþlayarak ileri (local Z) yönünde bir çizgi çiz
        // Çizginin uzunluðu itmeGucu / 5f (sadece görsel bir referans, deðeri ayarlayabilirsiniz)
        Gizmos.DrawRay(transform.position, transform.forward * (itmeGucu / 5f));
    }
}