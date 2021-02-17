using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy1 : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        gameManager.HideLars();
    }
}
