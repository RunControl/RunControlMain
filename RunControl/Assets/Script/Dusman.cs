using Batu;
using UnityEngine;
using UnityEngine.AI;
public class Dusman : MonoBehaviour
{

    public GameObject SaldiriHedefi;
    NavMeshAgent _navMesh;
    bool SaldiriBasladiMi;
    GameManager _gameManager;
    EfektYönetimi efektYönetimi = new EfektYönetimi();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnDisable()
    {
        efektYönetimi.EfektOlustur(transform, GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokolmaEfektleri);
    }


    private void OnEnable()
    {
        efektYönetimi.EfektOlustur(transform, GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokolmaEfektleri);
    }
    public void AnimasyonTetikle()
    {
        GetComponent<Animator>().SetBool("Saldýr", true);
        SaldiriBasladiMi = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(SaldiriBasladiMi)
        _navMesh.SetDestination(SaldiriHedefi.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("altkarakter"))
        {
            _gameManager.KacDusmanOlsun--;
            gameObject.SetActive(false);
            if (!_gameManager.OyunBittiMi)
                _gameManager.SavasDurumu();
        }
    }
}
