using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapApp : MonoBehaviour
{
    public Tablet tablet;

    public Sprite map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //open app
        Debug.Log("ipad stuff");
        tablet.home.sprite = map;
    }
}
