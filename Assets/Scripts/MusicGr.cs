using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGr : MonoBehaviour
{
    private static MusicGr intance;
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
