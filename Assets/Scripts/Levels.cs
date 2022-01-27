using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public Readouts Readouts;
    public List<GameObject> levels;
    private GameObject levelGameObject;
    private int currentLevel = 0;

    void Start()
    {
        levelGameObject = CreateLevel();
        UpdateReadout();

    }
    public void GoToNextLevel()
    {
        currentLevel++;
        if (IsGameOver())
            return;
        LoadNextLevel();
    }

    public bool IsGameOver()
    {
        if (currentLevel == levels.Count)
        {
            return true;
        }
        return false;
    }

    private void LoadNextLevel()
    {
        if (levelGameObject != null)
        {
            Destroy(levelGameObject);
        }

        levelGameObject = CreateLevel();

        UpdateReadout();
    }

    private void UpdateReadout()
    {
        Readouts.ShowLevel(currentLevel + 1);
    }

    private GameObject CreateLevel()
    {
        return Instantiate(levels[currentLevel], levels[currentLevel].transform.position, Quaternion.identity);
    }
}
