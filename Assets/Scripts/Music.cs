using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music intance;
    private void Awake()
    {
        if (intance != null)
            Destroy(gameObject);
        else
        {
            intance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        
        
    }
}
