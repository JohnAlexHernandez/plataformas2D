using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;

    private void Update()
    {
        AllFruitCollected();
    }
    public void AllFruitCollected()
    {
        if(transform.childCount == 0)
        {
            Debug.Log("No quedan frutas, Ganaste!");
            levelCleared.gameObject.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
