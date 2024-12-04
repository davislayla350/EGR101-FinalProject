using UnityEngine;
using UnityEngine.UI;  // Required to use the Button component
using UnityEngine.SceneManagement;  // Required for SceneManager

public class hi2 : MonoBehaviour
{
    public Button yourButton; // Reference to the Button in your scene

    void Start()
    {
        // Ensure that the Button is assigned and hook up the listener
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        // Load the scene when the button is clicked
        Debug.Log("Button clicked, loading scene...");
        SceneManager.LoadScene("SampleScene");
    }
}
