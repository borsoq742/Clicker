using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newScriptDEL : MonoBehaviour
{

    public  newScriptDEL intance;
    public AudioSource audioPirat;

    public void Awake()
    {
        audioPirat = GetComponent<AudioSource>();
        if (intance != null)
            Destroy(gameObject);
        else
        {
            intance = this;
            DontDestroyOnLoad(transform.gameObject);
        }

    }
    
}
