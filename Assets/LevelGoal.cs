using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        GameManager.Instance.ActivateLevelOverUI(true);
    }
}
