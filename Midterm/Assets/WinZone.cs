using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    private Timer timer;
    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        timer.TimePause = true;
        //GameObject.Find("Player").SendMessage("Your timer is: ");
    }
}
