using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeInventoryState()
    {
        if(animator.GetBool("IsInventoryOpen") == false)
        {
            animator.SetBool("IsInventoryOpen", true);
        }
        else if (animator.GetBool("IsInventoryOpen") == true)
        {
            animator.SetBool("IsInventoryOpen", false);
        }
    }
}
