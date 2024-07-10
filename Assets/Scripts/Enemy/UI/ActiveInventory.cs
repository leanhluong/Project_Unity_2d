using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlotIndexNum = -1; // -1 indicates no weapon equipped
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        // Register the callback for the keyboard input
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());

        ToggleActiveSlot(1);

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void ToggleActiveSlot(int numValue)
    {
        // Adjust numValue to match the 0-based index of the inventory slots
        int indexNum = numValue - 1;

        // Check if the same slot is toggled to disable the weapon
        if (activeSlotIndexNum == indexNum)
        {
            activeSlotIndexNum = -1; // No weapon equipped
        }
        else
        {
            activeSlotIndexNum = indexNum;
        }

        ToggleActiveHighlight(activeSlotIndexNum);
    }

    private void ToggleActiveHighlight(int indexNum)
    {
        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        if (indexNum >= 0)
        {
            this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);
        }
    }
}
