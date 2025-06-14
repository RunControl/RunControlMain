using UnityEngine;

public class MenuSes : MonoBehaviour
{
    private static GameObject instance;
    public AudioSource ses;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         ses.volume = PlayerPrefs.GetFloat("MenuSes");  // buraya geleceðiz
        DontDestroyOnLoad(gameObject);

        if(instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ses.volume = PlayerPrefs.GetFloat("MenuSes");
    }
}
