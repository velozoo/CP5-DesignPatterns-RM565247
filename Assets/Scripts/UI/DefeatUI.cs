using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DefeatUI : MonoBehaviour
{
    [SerializeField] private GameObject defeatPanel;

    public void ShowDefeat()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}