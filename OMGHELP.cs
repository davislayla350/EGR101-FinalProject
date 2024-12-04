using UnityEngine;
using TMPro; 
using UnityEngine.UI; 

public class OMGHELP : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject choiceUI; 
    public TextMeshProUGUI questionTextUI; 
    public Button nextButton; 
    public TextMeshProUGUI statusText; 

    [Header("Customization")]
    public string QuestionText; // Text to ask the player

    private bool hasMadeChoice = false; // Prevents reusing the trigger by reentering area

    private void Start()
    {
        // Ensure the UI is hidden at the start
        choiceUI.SetActive(false);

        // Hide the Next button initially
        nextButton.gameObject.SetActive(false);

        // Add listener for the Next button to proceed
        nextButton.onClick.AddListener(ProceedToNext);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger and hasn't made a choice
        if (other.CompareTag("Player") && !hasMadeChoice)
        {
            ShowChoices(); // Show choices and question
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If the player leaves the trigger
        if (other.CompareTag("Player"))
        {
            // Hide the entire UI panel (choiceUI) when the player exits the trigger area
            choiceUI.SetActive(false);

            // Optionally log that the UI is hidden
            Debug.Log("Panel hidden as player exited trigger.");
        }
    }

    private void ShowChoices()
    {
        // Show the UI
        choiceUI.SetActive(true);

        // Update the question text
        questionTextUI.text = QuestionText;

        // Hide the Next button at the start
        nextButton.gameObject.SetActive(false);

        // Mark the choice has been made
        hasMadeChoice = true;

        // Debug log to confirm
        Debug.Log("Choices are now displayed!");
    }

    private void MakeChoice(string status)
    {
        // Update the status text based on the choice made
        statusText.text = status;

        // Hide the UI after choice
        choiceUI.SetActive(false);

        // Show the "Next" button to allow player to proceed
        nextButton.gameObject.SetActive(true);

        // Debug log to confirm the button visibility
        Debug.Log("Next button should now be visible!");

        // Optionally, log the choice
        Debug.Log($"Player selected: {status}");

        // Prevent further choices
        hasMadeChoice = true;
    }

    private void ProceedToNext()
    {
        // Here, you can add logic for what happens when the player clicks the Next button
        Debug.Log("Proceeding to next...");

        // Reset the UI and choice for the next interaction
        ResetChoices();
    }

    private void ResetChoices()
    {
        // Hide the Next button
        nextButton.gameObject.SetActive(false);

        // Reset the choice UI
        choiceUI.SetActive(false);

        // Optionally, reset status text
        statusText.text = "";

        // Optionally, reset other UI elements as needed
    }
}
