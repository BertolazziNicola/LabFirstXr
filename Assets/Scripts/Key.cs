using UnityEngine;

/*
 * A class representing a key that can interact with a door by locking or unlocking it.
 * Implements the IKey interface.
 */
public class Key : MonoBehaviour, IKey
{
    #region @Properties
    /*
     * A reference to the door associated with this key.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _door;

    public GameObject Door
    {
        get { return _door; }
    }

    #endregion

    #region @Public Methods
    /*
     * Unlocks the door associated with this key.
     * Changes the door's lock status to unlocked, removes the lock component, 
     * and destroys the key GameObject after use.
     */
    public void UnlockDoor()
    {
        Door.GetComponent<Door>().IsLocked = false;
        Destroy(Door.GetComponent<Door>().Lock);
        Destroy(gameObject);
    }

    /*
     * Locks the door associated with this key.
     * Sets the door's lock status to locked.
     */
    public void LockDoor()
    {
        Door.GetComponent<Door>().IsLocked = true;
    }

    #endregion

    #region @Unity Methods
    /*
     * A Unity event method triggered when the GameObject collides with another object.
     * Checks if the collided object is the associated door and unlocks it.
     * @param Collision collision - Contains information about the collision event.
     */
    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (Door == obj) // Verify if the collided object is the associated door
        {
            UnlockDoor();
        }
    }

    /*
     * A Unity lifecycle method called when the script instance is being initialized.
     * Locks the associated door to ensure it starts in a locked state.
     */
    private void Awake()
    {
        LockDoor();
    }
    #endregion
}
