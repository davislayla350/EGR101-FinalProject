using UnityEngine;
using UnityEngine.UI;  // Required to use the Button component
using UnityEngine.SceneManagement;  // Required for SceneManager

public class SceneChanger2 : MonoBehaviour
{
    public Button yourButton; // Reference to the Button in your scene

    // This method is called when the script starts or when the object is created
    void Start()
    {
        // Check if the Button is assigned
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OnButtonClick);  // Add a listener to the button click
        }
        else
        {
            Debug.LogError("Button not assigned in the Inspector!");  // Log an error if the button is not assigned
        }
    }

    // This method is called when the button is clicked
    void OnButtonClick()
    {
        // Load the scene when the button is clicked
        Debug.Log("Button clicked, loading scene...");
        SceneManager.LoadScene("End");  // Replace "End" with the name of the scene you want to load
    }
}
