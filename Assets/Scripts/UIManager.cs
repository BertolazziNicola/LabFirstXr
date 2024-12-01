using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region @Properties

    /*
     * Reference to the laundry door GameObject.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _doorLaundry;

    public GameObject DoorLaundry
    {
        get { return _doorLaundry; }
    }

    /*
     * Reference to the garden door GameObject.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _doorGarden;

    public GameObject DoorGarden
    {
        get { return _doorGarden; }
    }

    /*
     * Reference to the garden door lock GameObject.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _doorGardenLock;

    public GameObject DoorGardenLock
    {
        get { return _doorGardenLock; }
    }

    /*
     * Reference to the garden chest GameObject.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _chestGarden;

    public GameObject ChestGarden
    {
        get { return _chestGarden; }
    }

    /*
     * Reference to the garden chest lock GameObject.
     * Set via the Inspector.
     */
    [SerializeField]
    private GameObject _chestGardenLock;

    public GameObject ChestGardenLock
    {
        get { return _chestGardenLock; }
    }

    #endregion

    #region @Public Methods

    /*
     * Unlocks all doors and chests by setting their IsLocked property to false.
     * Also removes the locks from the garden door and chest by destroying their lock GameObjects.
     * @returns void - This method does not return any value.
     */
    public void UnlockAll()
    {
        // Unlock the laundry door, garden door, and garden chest
        DoorLaundry.GetComponent<Door>().IsLocked = false;
        DoorGarden.GetComponent<Door>().IsLocked = false;
        ChestGarden.GetComponent<Door>().IsLocked = false;

        // Destroy the garden door lock and garden chest lock objects
        Destroy(DoorGardenLock);
        Destroy(ChestGardenLock);
    }

    #endregion
}
