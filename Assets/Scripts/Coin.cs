using UnityEngine;

public class Coin : MonoBehaviour
{
    #region @Properties
    /*
     * A reference to the Game Manager.
     * This GameObject is assigned via the Inspector.
     */
    [SerializeField]
    private GameObject _gameManager;

    public GameObject GameManager
    {
        get { return _gameManager; }
    }

    #endregion

    #region @Public Methods

    /*
     * Collects the coin, increasing the player's score and playing the collection sound.
     * This method is typically called when the player collides with the coin.
     * 
     * @param void - This method does not take any parameters.
     * @returns void - This method does not return any value.
     */
    public void Collect()
    {
        // Increase the score by 1 in the ScoreManager component of GameManager
        GameManager.GetComponent<ScoreManager>().Score += 1;

        // Destroy the coin object after collection
        Destroy(gameObject);

        // Play the sound for coin collection
        GameManager.GetComponent<SoundManager>().CoinCollectSound();
    }

    #endregion
}
