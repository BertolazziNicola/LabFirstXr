using System.Collections;
using UnityEngine;

/*
 * A class representing a keycard used to unlock a door via a reader device.
 * Implements the IKey interface.
 */
public class Keycard : MonoBehaviour, IKey
{
    #region @Properties
    /*
     * A reference to the door that this keycard can unlock.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _door;
    public GameObject Door
    {
        get { return _door; }
    }

    /*
     * A reference to the reader device associated with the door.
     * The reader is used to verify the keycard and trigger the unlock mechanism.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _reader;
    public GameObject Reader
    {
        get { return _reader; }
    }

    /*
     * A reference to the reader display device.
     * Used to change display color when a keycard interact.
     */
    [SerializeField]
    private GameObject _readerDisplay;
    public GameObject ReaderDisplay
    {
        get { return _readerDisplay; }
    }

    #endregion

    #region @Public Methods


    /*
     * Unlocks the door associated with this keycard.
     * Changes the door's lock status to unlocked.
     */
    public void UnlockDoor()
    {
        Door.GetComponent<Door>().IsLocked = false;
    }

    /*
     * Locks the door associated with this keycard.
     * Changes the door's lock status to locked.
     */
    public void LockDoor()
    {
        Door.GetComponent<Door>().IsLocked = true;
    }

    #endregion

    #region @Coroutines
    /*
     * A coroutine that temporarily changes the color of the reader display based on the validity of an action.
     * If the action is valid, the reader display turns green; otherwise, it turns red.
     * After 3 seconds, the display color resets to its default state.
     * 
     * @param bool isValid - Indicates whether the action is valid (true for valid, false for invalid).
     * @returns IEnumerator - Used to control the coroutine's execution over time.
     */
    IEnumerator ReaderColor(bool isValid)
    {
        if (isValid)
        {
            ReaderDisplay.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            ReaderDisplay.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        yield return new WaitForSeconds(3);
        ReaderDisplay.GetComponent<MeshRenderer>().material.color = new Color(17f / 255f, 51f / 255f, 82f / 255f);
    }
    #endregion

    #region @Unity Methods
    /*
     * A Unity event method triggered when this keycard collides with another object.
     * If the object is the associated reader, the door is unlocked.
     * @param Collision collision - Contains information about the collision event.
     */
    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (Reader == obj) // Check if the collided object is the associated reader
        {
            UnlockDoor();
            StartCoroutine(ReaderColor(true));
        }
    }

    /*
     * A Unity lifecycle method called when the script instance is being initialized.
     * Ensures that the door starts in a locked state.
     */
    private void Awake()
    {
        LockDoor();
    }
    #endregion
}
