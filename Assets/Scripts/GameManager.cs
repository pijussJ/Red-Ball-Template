using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<string> levels;

    public int hp = 3;
    public int currentLevel;

    // singleton
    public static GameManager instance;
    private void Start()
    {
        if(instance == null)
        { 
        instance = this;
        DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Win()
    {
        currentLevel++;
        Invoke("LoadNextLevel", 0.5f);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(levels[currentLevel]);
    }
    public void Lose()
    {
        if (hp == 0)
        {
            SceneManager.LoadScene(levels[0]);
        }
        hp = 3;
    }
}
