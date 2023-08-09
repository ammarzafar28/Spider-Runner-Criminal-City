using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int fullHealth = 50;
    private int currentHealth;
    public string sceneName;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
    }

    public void LoseHealth(int damage) 
    {
        currentHealth -= damage;
        if(currentHealth <= 0) {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        LoadScene();
    }

    public void LoadScene()
    {
        if(!string.IsNullOrEmpty(sceneName)) {
            SceneManager.LoadScene(sceneName);
        } 
    }
}
