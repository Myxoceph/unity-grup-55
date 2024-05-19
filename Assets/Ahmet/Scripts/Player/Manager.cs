using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Player player;

    [SerializeField] private Slider slider;
    [SerializeField] private GameObject deathScreen;
    
    private int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        slider.value = player.heal;
        if (player.death)
        {
            deathScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
