using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour

{

    [SerializeField] GameObject canvas;
    [SerializeField] int enemigos;
    [SerializeField] spaceship player;
    bool gamePaused = false;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
            PauseGame();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void PauseGame()
    {
        gamePaused = gamePaused ? false : true;
        player.gamePaused = gamePaused;
        canvas.SetActive(gamePaused);
          Time.timeScale = gamePaused? 0 : 1 ;
    }
    public void reducirnumenemigos()
    {
        enemigos = enemigos - 1;
        if (enemigos < -1)
        {
            ganar();
        }
        void ganar()
        {
            gameOver = true;
            Time.timeScale = 0;
            player.gamePaused = true;
            Debug.Log("ganaste");
        }

    }


}
