using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tablet : MonoBehaviour, IInventoryItem
{
    public Collider2D mapApp;

    public Image home;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UseItem()
    {
        Debug.Log("using " + this.name);
    }
}
