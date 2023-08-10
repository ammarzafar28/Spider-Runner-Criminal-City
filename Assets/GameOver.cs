
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private int defeatedEnemyCount = 0;
    private int totalEnemyCount = 2; 
    public string sceneName;


    private void Start()
    {
        defeatedEnemyCount = 0;
    }

    public void EnemyDefeated()
    {
        defeatedEnemyCount++;

        if (defeatedEnemyCount == totalEnemyCount)
        {
            SceneManager.LoadScene(sceneName); 
        }
    }

}

