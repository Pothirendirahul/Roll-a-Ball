using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        // Debug message to check if the button is clicked
        Debug.Log("Restart button clicked!");

        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
