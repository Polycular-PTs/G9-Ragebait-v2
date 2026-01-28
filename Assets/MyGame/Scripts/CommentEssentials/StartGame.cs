using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    // Methode zum Laden der nächsten Szene
    public void LoadScene1()
    {
        SceneManager.LoadScene("Szene1"); // Name der Szene
        // Alternativ mit Index: SceneManager.LoadScene(1);
    }
}