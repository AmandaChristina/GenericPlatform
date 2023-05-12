using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    RectTransform cursorTransform;
    Vector2 newCursorPosition;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Fase1");
    }
}
