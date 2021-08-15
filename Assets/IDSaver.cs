using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDSaver : MonoBehaviour
{
    public string id;
    private static IDSaver idsaverInstance;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(idsaverInstance == null)
        {
            idsaverInstance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void setId(string x)
    {
        id = x;
        Debug.Log("ID: " + id + " tallennettu");
        //Destroy(this.gameObject);
    }

    public string getId()
    {
        return id;
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
