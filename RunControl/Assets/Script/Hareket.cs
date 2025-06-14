using UnityEngine;

public class Hareket : MonoBehaviour
{
    [Header("�tme Ayarlar�")]
    public float itmeGucu = 10f; // Karakterin ne kadar kuvvetle itilece�i
    public ForceMode itmeTipi = ForceMode.Impulse; // �tme kuvvetinin nas�l uygulanaca�� (Impulse ani bir itme sa�lar)

    [Header("Hedef Tag'leri")]
    public string anaKarakterTag = "anakarakter";
    public string altKarakterTag = "altkarakter";

    // Bu script'in ba�l� oldu�u obje ba�ka bir obje ile �arp��t���nda bu fonksiyon �al���r.
    void OnCollisionEnter(Collision collision)
    {
        // �arp��an nesnenin tag'ini kontrol et
        if (collision.gameObject.CompareTag(anaKarakterTag) || collision.gameObject.CompareTag(altKarakterTag))
        {
            // �arp��an nesnenin Rigidbody bile�enini al
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            // E�er Rigidbody varsa (yani fiziksel bir nesneyse)
            if (rb != null)
            {
                // �tme y�n�n� bu objenin ileri (local Z) y�n� olarak belirle
                Vector3 itmeYon = transform.forward; // Bu objenin bakt��� y�n (kendi Z ekseni)

                // Rigidbody'e kuvvet uygula
                rb.AddForce(itmeYon * itmeGucu, itmeTipi);

                Debug.Log(collision.gameObject.name + " adl� obje, " + gameObject.name + " taraf�ndan itildi!");
            }
            else
            {
                Debug.LogWarning(collision.gameObject.name + " �zerinde Rigidbody bulunamad�. �tme i�lemi yap�lamad�.");
            }
        }
    }


    // �tme y�n�n� g�rselle�tirmek i�in (Scene view'da g�r�n�r)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        // Bu objenin pozisyonundan ba�layarak ileri (local Z) y�n�nde bir �izgi �iz
        // �izginin uzunlu�u itmeGucu / 5f (sadece g�rsel bir referans, de�eri ayarlayabilirsiniz)
        Gizmos.DrawRay(transform.position, transform.forward * (itmeGucu / 5f));
    }
}