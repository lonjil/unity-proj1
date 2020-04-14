using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
    [SerializeField] private Text endtext;
    [SerializeField] private Canvas endui;
    private void Start() {
        endui.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone")) {
            Cursor.lockState = CursorLockMode.None;
            endui.enabled = true;
            endtext.text = "You lose!";
        } else if (other.CompareTag("WinZone")) {
            Cursor.lockState = CursorLockMode.None;
            endui.enabled = true;
            endtext.text = "You win!";
        }
    }
    public void Reset() {
        SceneManager.LoadScene("Scenes/Övning");
    }
}