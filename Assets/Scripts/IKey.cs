/*
 * An interface that defines the behavior for keys or similar objects
 * that can lock or unlock doors.
 */
public interface IKey
{
    /*
     * Unlocks the door associated with this key.
     * Should implement logic to set the door's state to unlocked.
     */
    void UnlockDoor();

    /*
     * Locks the door associated with this key.
     * Should implement logic to set the door's state to locked.
     */
    void LockDoor();
}
