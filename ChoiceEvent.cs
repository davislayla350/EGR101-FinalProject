using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceEvent : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject choiceUI; // UI panel to show choices
    public Button choice1Button; // Button for choice 1
    public Button choice2Button; // Button for choice 2
    public Button choice3Button; // Button for choice 3
    public TextMeshProUGUI statusText; // Where the status will display
    public TextMeshProUGUI questionTextUI; // Text component for the question

    [Header("Customization")]
    public string QuestionText; // Text to ask the player
    public string choice1Text; // Text for choice 1 button
    public string choice2Text; // Text for choice 2 button
    public string choice3Text; // Text for choice 3 button
    public string choice1Status; // Status update for choice 1
    public string choice2Status; // Status update for choice 2
    public string choice3Status; // Status update for choice 3

    private bool hasMadeChoice = false; // Prevents reusing the trigger

    private void Start()
    {
        // Ensure the UI is hidden at the start
        choiceUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasMadeChoice)
        {
            ShowChoices();
        }
    }

    private void ShowChoices()
    {
        // Show the UI
        choiceUI.SetActive(true);

        // Update the question text
        questionTextUI.text = QuestionText;

        // Set the button texts
        choice1Button.GetComponentInChildren<TextMeshProUGUI>().text = choice1Text;
        choice2Button.GetComponentInChildren<TextMeshProUGUI>().text = choice2Text;
        choice3Button.GetComponentInChildren<TextMeshProUGUI>().text = choice3Text;

        // Assign button functions
        choice1Button.onClick.AddListener(() => MakeChoice(choice1Status));
        choice2Button.onClick.AddListener(() => MakeChoice(choice2Status));
        choice3Button.onClick.AddListener(() => MakeChoice(choice3Status));
    }

    private void MakeChoice(string status)
    {
        // Update the status text
        statusText.text = status;

        // Hide the UI and mark the choice as complete
        choiceUI.SetActive(false);
        hasMadeChoice = true;

        Debug.Log($"Player selected: {status}");
    }
}
