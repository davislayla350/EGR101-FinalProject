using UnityEngine;
using TMPro; 
using System.Collections;

public class TextboxTrigger : MonoBehaviour
{
    public GameObject textbox; 
    public string message = "Default message"; 
    public float displayDuration = 3f; 

    private TMP_Text textComponent;

    void Start()
    {
        Debug.Log("TextboxTrigger script is running"); //wasn't triggering

        if (textbox == null)
        {
            Debug.LogError("Textbox GameObject is not assigned!");
            return;
        }

        textComponent = textbox.GetComponentInChildren<TMP_Text>();
        if (textComponent == null)
        {
            Debug.LogError("No TMP_Text component found in the textbox or its children!");
            return;
        }

        textbox.SetActive(false); // Hide the textbox at the start
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter fired! Triggered by: " + other.name);

        if (other.CompareTag("Player")) //Frog has tag Player 
        {
            textComponent.text = message; // Set the message
            StartCoroutine(ShowTextbox());
        }
    }

    IEnumerator ShowTextbox()
    {
        textbox.SetActive(true); // Show the textbox

        // Wait for the display duration
        yield return new WaitForSeconds(displayDuration);

        textbox.SetActive(false); // Hide the textbox
    }
}
