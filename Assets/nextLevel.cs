using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{

    private Scene scene;
    public Enemy enemy;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        enemy = FindObjectOfType<Enemy>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemy.heal <= 0)
        {
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
