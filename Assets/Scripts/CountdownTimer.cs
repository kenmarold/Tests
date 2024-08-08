using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public int countdownTime = 10; // Set the countdown time in seconds
    public int bonusTime = 5; // Set the bonus time in seconds
    public TMP_Text countdownDisplay; // Reference to the TMP_Text element to display the countdown

    private int currentTime;

    private void Start()
    {
        currentTime = countdownTime;
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        while (currentTime > 0)
        {
            countdownDisplay.text = currentTime.ToString(); // Update the TMP_Text with the current time
            yield return new WaitForSeconds(1); // Wait for 1 second
            currentTime--; // Decrease the current time by 1
        }

        countdownDisplay.text = "Time's Up!"; // Display "Time's Up!" when the countdown reaches zero

        // Add any additional logic you want to execute when the countdown is finished
    }

    public void AddTime(int seconds)
    {
        currentTime += seconds;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("duck"))
        {
            AddTime(bonusTime); // Add bonusTime to the timer
            Debug.Log("Jeep collided with Duck. Added" + bonusTime +" seconds to the timer.");
        }
    }
}