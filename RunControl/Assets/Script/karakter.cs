using UnityEngine;
using Batu;
using Unity.VisualScripting;
public class karakter : MonoBehaviour
{


    public GameManager _gameManager;
    public GameObject _kamera;
    public bool SonaGeldikMi;
    public GameObject GidecegiYer;
    public Rigidbody _rigidbody;

    Hesaplama hesaplama = new Hesaplama();

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    private void FixedUpdate()
    {
        if(!SonaGeldikMi)
        transform.Translate(Vector3.forward * .5f * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (SonaGeldikMi)
        {
            // Hedefe yaklaþýrken hareket
            transform.position = Vector3.Lerp(transform.position, GidecegiYer.transform.position, 0.015f);

            // Eðer hedefe yeterince yaklaþtýysa hareketi durdur
            if (Vector3.Distance(transform.position, GidecegiYer.transform.position) < 0.01f)
            {
                transform.position = GidecegiYer.transform.position; // Kesin hizalama
                enabled = false; // Update metodunu durdurmak için (isteðe baðlý)
            }
        }
        else
        {
            if(Time.timeScale != 0)
            {
              if (Input.GetKey(KeyCode.Mouse0))
              {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
                }
              }
            }
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("geçit"))
        {
            hesaplama.AdamYönetimi(other.name, other.transform, _gameManager.Karakterler, ref _gameManager.AnlikKarakterSayisi);
        }
        if (other.CompareTag("sontetikleyici")) 
        {
            _kamera.GetComponent<Kamera2>().SonaGeldikMi = true;
            _gameManager.DusmanlariTetikle();
            SonaGeldikMi = true;
        }
        if (other.CompareTag("hareket"))
        {
            Vector3 itmeYon = other.transform.forward;
            _rigidbody.AddForce(itmeYon * 10f, ForceMode.Impulse);
            Debug.Log(gameObject.name + ", " + other.gameObject.name + " trigger'ý tarafýndan itildi!");
        }

    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("direk") || collision.gameObject.CompareTag("igneliKutuAna") || collision.gameObject.CompareTag("igneliKutu")
            || collision.gameObject.CompareTag("testereAna") || collision.gameObject.CompareTag("dikenliDuvar"))
        {
            if(transform.position.x > 0 )
            transform.position = new Vector3(transform.position.x - .2f,transform.position.y, transform.position.z);
            else
            transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
        }
    }
}
