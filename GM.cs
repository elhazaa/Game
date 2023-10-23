using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//Administrador del juego o nivel
//Administra puntuacion, vidas, estado del nivel
//etc.
public class GM : MonoBehaviour
{
    // Start is called before the first frame update
    //public static int score = 0;
    public static int lives = 3;
    public bool playing = true;
    public float timeout = 20;
    //public int target_score = 50;
    int level_target_score;
    [Header("Campos de texto de UI")]
    //public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text timeoutText;
    [Header("Canvas para estados del juego")]
    public GameObject loose_canvas;
    public GameObject win_canvas;
    public GameObject gameover_canvas;
    public GameObject getready_canvas;
    public static GM gm; //Singleton
    void Start()
    {
        if (gm == null)
            gm = this;
        //level_target_score = score + target_score;

    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            timeout = timeout - Time.deltaTime;
            if (timeout <= 0)
            {
                LooseLevel();
            }

            timeoutText.text = "" + Mathf.Ceil(timeout);
        }
        livesText.text = "Lives: " + lives;
        //scoreText.text = "Score: " + score;
    }

    public void Reset()
    {
        //score = 0;
        lives = 3;
    }
    public void LooseLevel()
    {
        lives--;
        DisablePlaying();
        if (lives > 0)
        {
            loose_canvas.SetActive(true);
            //score = 0;
        }
        else
        {
            gameover_canvas.SetActive(true);
        }
        //verificamos si aun hay vidas.
        //livesText.text = "Lives: " + lives;
        // Debug.Log("Ya perdiste! vida: " + lives);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Vuelve a cargar esta escena
    }
    public void WinLevel()
    {
        win_canvas.SetActive(true);
        DisablePlaying();
    }
    public void EnablePlaying()
    {
        playing = true;
    }
    public void DisablePlaying()
    {
        playing = false;
    }

    public bool CanPlay()
    {
        return playing;
    }
   /* public void IncreaseScore(int amount)
    {
        score += amount;
        if (score >= level_target_score)
        {
            WinLevel();
        }
    }*/
}
