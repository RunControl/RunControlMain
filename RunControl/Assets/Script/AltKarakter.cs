using System;
using UnityEngine;
using UnityEngine.AI;
using Batu;
using UnityEngine.UIElements;
public class AltKarakter : MonoBehaviour
{
    GameObject target;
    NavMeshAgent _navMesh;
    GameManager _gameManager;
    EfektY�netimi efektY�netimi = new EfektY�netimi();
    private bool temasBalyozlaOldu = false;
    public Rigidbody _rigidbody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().VarisNoktasi;
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        _navMesh.SetDestination(target.transform.position);
    }

    private void OnDisable()
    {
        if (temasBalyozlaOldu)
        {
            efektY�netimi.EfektOlustur(transform, _gameManager.AdamLekesiEfektleri, true);
        }
        else
        {
            efektY�netimi.EfektOlustur(transform, _gameManager.YokolmaEfektleri);
        }

        temasBalyozlaOldu = false; // Resetle
    }


    private void OnEnable()
    {
        efektY�netimi.EfektOlustur(transform, GameObject.FindWithTag("GameManager").GetComponent<GameManager>().OlusmaEfektleri);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
            temasBalyozlaOldu = false;

            if (_gameManager.AnlikKarakterSayisi > 1)
                _gameManager.AnlikKarakterSayisi--;

            gameObject.SetActive(false);
        }

        if (other.CompareTag("balyoz"))
        {
            temasBalyozlaOldu = true;

            if (_gameManager.AnlikKarakterSayisi > 1)
                _gameManager.AnlikKarakterSayisi--;

            gameObject.SetActive(false);
        }
        if (other.CompareTag("dusman"))
        {

            if (_gameManager.AnlikKarakterSayisi > 1)
                _gameManager.AnlikKarakterSayisi--;

            gameObject.SetActive(false);
            if(!_gameManager.OyunBittiMi)
                _gameManager.SavasDurumu();
        }
        if(other.CompareTag("hareket"))
        {
            Vector3 itmeYon = other.transform.forward;
            _rigidbody.AddForce(itmeYon * 10f, ForceMode.Impulse);
            Debug.Log(gameObject.name + ", " + other.gameObject.name + " trigger'� taraf�ndan itildi!");
        }

    }


}
