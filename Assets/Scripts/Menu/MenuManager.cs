using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region @Properties
    /*
     * A reference to the TextMeshProUGUI component displaying the best score.
     * Set via the Inspector.
     */
    [SerializeField]
    private Object TextBestScore;

    #endregion
    #region @Private Methods

    #endregion
    #region @Public Methods
    void Start()
    {
        TextBestScore.GetComponent<TextMeshProUGUI>().text = "Best score: " + SaveManager.GetBestScore();
    }

    /**
     * Start the game (basic scene)
     */
    public void StartGame()
    {
        SceneManager.LoadScene("BasicScene");
    }

    /**
     * Close the game
     */
    public void CloseGame()
    {
        Application.Quit();
    }
    #endregion
}
