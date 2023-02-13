using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreObject; 
    public TextMeshProUGUI highScoreText;

    public int score;
    public bool gameStarted;

    private void Awake(){

        highScoreText.text="Highscore: "+GetHighScore().ToString();
    }
    
    public void StartGame(){
        gameStarted=true;
        FindObjectOfType<Road>().StartBuilding();  
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            StartGame();
        }
    }

    public void EndGame(){
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore(){
        score++;
        scoreObject.text=score.ToString();

        if(score>GetHighScore()){
            PlayerPrefs.SetInt("Highscore",score);
            highScoreText.text="Highscore: "+score.ToString();
        }
    }

    public int GetHighScore(){
        int i=PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
