using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    #region @Public Methods

    /*
     * Save the provided score into a JSON file in the user's Documents folder.
     * This method serializes the score and writes it to a file.
     * @param string bestScore - The score to be saved in the JSON file.
     */
    public static void SavePlayerData(int bestScore)
    {
        try
        {
            PlayerData data = new PlayerData { bestScore = bestScore };

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(GetJsonPath(), json);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error saving data: " + ex.Message);
        }
    }

    /*
     * Retrieve the best score from the saved JSON file.
     * @returns int - The best score or 0 if not found.
     */
    public static int GetBestScore()
    {
        try
        {
            string json = File.ReadAllText(GetJsonPath());

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            return data.bestScore;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error reading data: " + ex.Message);
            return 0;
        }
    }

    /*
     * Saves the current score and exits to the menu scene.
     * If the current score is higher than the previously saved best score, the new score is saved.
     * Then, it loads the "Menu" scene.
     * @returns void - This method does not return a value.
     */
    public void SaveAndExit()
    {
        int bestScore = GetBestScore();
        int actualScore = GetComponent<ScoreManager>().Score;

        if(actualScore > bestScore)
        {
            SavePlayerData(actualScore);
        }
        SceneManager.LoadScene("Menu");
    }
    #endregion

    #region @Private Methods

    /*
     * Constructs and returns the full file path for the JSON data file in the user's Documents folder.
     * If the target directory does not exist, it creates the directory.
     * @returns string - The full path to the JSON data file.
     */
    private static string GetJsonPath()
    {
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        string directoryPath = Path.Combine(documentsPath, "NicolaVrGame");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        return Path.Combine(directoryPath, "data.json");
    }
    #endregion

    #region @Classes

    [Serializable]
    public class PlayerData
    {
        public int bestScore;
    }

    #endregion
}
