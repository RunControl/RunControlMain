using Batu;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BosKarakter : MonoBehaviour
{

    public GameManager _gameManager;
    public Material yeniMaterial; // Inspector �zerinden atanacak yeni material
    public Animator _animator;
    public SkinnedMeshRenderer _meshRenderer;
    public RuntimeAnimatorController yeniController;
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("altkarakter") || other.CompareTag("anakarakter"))
        {
            _gameManager.Karakterler.Add(gameObject);
            _gameManager.AnlikKarakterSayisi++;

            Material[] mats = _meshRenderer.materials;
            mats[0] = yeniMaterial;
            _meshRenderer.materials = mats;

            _animator.SetBool("Kat�l", true);
            _animator.runtimeAnimatorController = yeniController;

            gameObject.tag = "altkarakter";

            if (!gameObject.GetComponent<AltKarakter>())
            {
                gameObject.AddComponent<AltKarakter>();
            }

            _animator.SetBool("Sald�r", true);

            Destroy(this); // BosKarakter scripti objeden kald�r�l�r
        }
    }
}
