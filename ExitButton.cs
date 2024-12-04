using UnityEngine;

public class ExitButton : MonoBehaviour

{
    // This method is called when the button is clicked
    public void ExitApplication()
    {
        // Exits the application
        Debug.Log("Exiting the application...");
        Application.Quit();
    }
}


