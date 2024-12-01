using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*
 * A class responsible for managing the player's score, including the actual score and the best score.
 * Updates the UI dynamically as the score changes.
 */
public class ScoreManager : MonoBehaviour
{
    #region @Properties
    /*
     * A reference to the TextMeshProUGUI component displaying the best score.
     * Set via the Inspector.
     */
    [SerializeField]
    private Object TextBestScore;

    /*
     * A reference to the TextMeshProUGUI component displaying the actual score.
     * Set via the Inspector.
     */
    [SerializeField]
    private Object TextActualScore;

    /*
     * A private field to store the current score.
     */
    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            // Update the actual score text in the UI.
            TextActualScore.GetComponent<TextMeshProUGUI>().text = "Actual Score: " + _score;
        }
    }

    #endregion
    #region @Private Methods

    /*
     * A Unity lifecycle method called when the script instance is initialized.
     * Initializes the score and updates the UI with the initial values for actual and best scores.
     */
    private void Awake()
    {
        Score = 0; // Initialize the score to zero.

        TextBestScore.GetComponent<TextMeshProUGUI>().text = "Best Score: " + SaveManager.GetBestScore();
    }
    #endregion
}
