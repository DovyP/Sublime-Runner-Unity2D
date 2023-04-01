using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
