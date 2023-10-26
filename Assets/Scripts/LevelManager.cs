using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    #region Inspector Variables
    [SerializeField]
    private List<Level> levelPrefabsList;
    #endregion

    #region Private Variables
    private int currentLevelIndex = 0;
    private Level currentLevel;
    #endregion

    void Start()
    {
        currentLevelIndex = PlayerPrefs.GetInt("Level", 0);
        InstantiateLevel();
    }

    private void InstantiateLevel()
    {
        if (currentLevelIndex >= levelPrefabsList.Count)
        {
            currentLevelIndex = 0;
        }
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = Instantiate(levelPrefabsList[currentLevelIndex], transform);

    }

    public void OnLevelComplete()
    {
        currentLevelIndex++;
        PlayerPrefs.SetInt("Level", currentLevelIndex);
        InstantiateLevel();
    }

    public void OnLevelFailed()
    {
        InstantiateLevel();
    }

    public void OnStartLevelFailed()
    {
        currentLevel.OnLevelFailed();
    }
}
