using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * A class representing a door that can be locked and unlocked.
 * The door's lock state controls its physical constraints.
 */
public class Door : MonoBehaviour
{
    #region @Properties
    /*
     * A reference to the Button to enable.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _enableButton;

    public GameObject EnableButton
    {
        get { return _enableButton; }
    }


    /*
     * A reference to the lock associated with this door.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _lock;
    public GameObject Lock
    {
        get { return _lock; }
    }

    [SerializeField]
    /*
     * A variable to check if it is a chest (open vertically).
     * Set via the Inspector.
     */
    private bool _isChest;

    public bool IsChest
    {
        get { return _isChest; }
    }


    /*
     * A private field to store the current lock state of the door.
     */
    private bool _isLocked;
    public bool IsLocked
    {
        get { return _isLocked; }
        /*
         * When set, it updates the Rigidbody constraints to reflect the lock state.
         */
        set
        {
            if (value) // If locking
            {
                // Freeze all Rigidbody movements and rotations
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            else // If unlocking
            {
                if (IsChest)
                {
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX
                                      | RigidbodyConstraints.FreezeRotationX
                                      | RigidbodyConstraints.FreezeRotationY;
                }
                else
                {
                    SaveAndExitEnabled();
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY
                                                              | RigidbodyConstraints.FreezeRotationX
                                                              | RigidbodyConstraints.FreezeRotationZ;
                }
            }
            _isLocked = value; // Update the internal lock state
        }
    }

    #endregion
    #region @Private Methods
    /*
     * Enables the interactable property of the SaveAndExitButton if the button is assigned and valid.
     * Checks if the SaveAndExitButton has a Button component and logs an error if it does not.
     * Handles any unexpected exceptions to avoid runtime crashes.
     * @returns void - This method does not return a value.
     */
    private void SaveAndExitEnabled()
    {
        if (EnableButton != null)
        {
            try
            {
                Button buttonComponent = EnableButton.GetComponent<Button>();
                buttonComponent.interactable = true;
            }
            catch (Exception ex)
            {
                Debug.LogError("Error enabling SaveAndExitButton: " + ex.Message);
            }
        }
        else
        {
            Debug.LogError("SaveAndExitButton is null. Ensure it is assigned in the Inspector.");
        }
    }

    #endregion
}
