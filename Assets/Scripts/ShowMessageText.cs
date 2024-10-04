using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMessageText : MonoBehaviour
{
    [SerializeField] private TMP_Text introductionField;
    [SerializeField] private TMP_Text messageField;
    [SerializeField] private float displayTime;
    [SerializeField] private string message = "Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.";
    void Start()
    {
        StartText(displayTime, message);
    }
    public void StartText(float displayTime, string message)
    {
        StartCoroutine(ShowMessage(message, displayTime));
    }
    IEnumerator ShowMessage(string message, float displayTime)
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(displayTime);
        messageField.enabled = false;
    }
}
