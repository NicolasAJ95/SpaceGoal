using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        GameManager.Instance.ActivateGameOverUI(true);
    }
}
