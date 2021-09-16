using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject restartMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Obstacle.isCollided == true)
        {
            restartMenu.SetActive(true);
            Time.timeScale = 0;
        }
       
    }
}
