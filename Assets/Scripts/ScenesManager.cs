using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    RectTransform cursorTransform;
    Vector2 newCursorPosition;
    float mouseX, mouseY;

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        newCursorPosition = new Vector2(mouseX, mouseY);

        cursorTransform.localPosition = newCursorPosition;

        print(newCursorPosition);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}
