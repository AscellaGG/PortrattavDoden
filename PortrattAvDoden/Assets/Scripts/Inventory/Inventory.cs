using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Animator animator;

    public GameObject[] inventorySlots;

    public GameObject tabletButton;

    // Start is called before the first frame update
    void Start()
    {
        inventorySlots[0].GetComponent<InventorySlot>().isSlotFilled = true;

        Instantiate(tabletButton, inventorySlots[0].transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(GameObject item)
    {
        int emptyInventorySlot = FindEmptyInventorySlot();
        //inventorySlots[emptyInventorySlot].itemImage.gameObject.SetActive(true);
        //inventorySlots[emptyInventorySlot].itemImage.sprite = item.icon;

        Instantiate(item, inventorySlots[emptyInventorySlot].transform);

        inventorySlots[emptyInventorySlot].GetComponent<InventorySlot>().isSlotFilled = true;

        //item.GetComponent<Button>().onClick.AddListener(item.GetComponent<IInventoryItem>().UseItem);

        animator.SetBool("IsInventoryOpen", true);
    }

    int FindEmptyInventorySlot()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].GetComponent<InventorySlot>().isSlotFilled == false)
            {
                return i;
            }
        }
        Debug.LogError("Inventory full");
        return 10;
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
