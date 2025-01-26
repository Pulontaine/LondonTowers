using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public List<Ring> rings = new List<Ring>();
    public Transform[] ringSlots;
    public bool[] availableRingSlots;
    public struct isPickedStruct{
        public bool Flag;
        public Ring Ring;
        public isPickedStruct(bool flag, Ring ring){
            Flag = flag;
            Ring = ring;
        }
    }
    public isPickedStruct isPicked;
    public Ring pickedRing;

    [SerializeField] private TextMeshProUGUI scoreText;
    public int availableMoves;
    public GameObject lose;
    public int score;
    [SerializeField] public TextMeshProUGUI scoreRes;


    private void Start() {
        for(int i = 0; i < rings.Count; i++){
            rings[i].transform.position = ringSlots[i].position;
        }
        if(lose != null)
            lose.SetActive(false);
        score = PlayerPrefs.GetInt("score", 0);
        if(SceneManager.GetActiveScene().buildIndex == 4){
            PrintRes();
        }
    }

    public void isLevelCompleted(){
        Moves();

        if(SceneManager.GetActiveScene().buildIndex == 2){
            if((ringSlots[0].position == rings[0].transform.position || ringSlots[0].position == rings[4].transform.position) &&
            (ringSlots[1].position == rings[1].transform.position || ringSlots[1].position == rings[8].transform.position) &&
            (ringSlots[2].position == rings[2].transform.position || ringSlots[2].position == rings[5].transform.position) &&
            (ringSlots[5].position == rings[2].transform.position || ringSlots[5].position == rings[5].transform.position) &&
            (ringSlots[7].position == rings[1].transform.position || ringSlots[7].position == rings[8].transform.position) &&
            (ringSlots[8].position == rings[0].transform.position || ringSlots[8].position == rings[4].transform.position)
            ){
                NextLevel();
                return;
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3){
            if(((ringSlots[2].position == rings[2].transform.position) || ringSlots[2].position == rings[4].transform.position) &&
            (ringSlots[3].position == rings[5].transform.position) &&
            (ringSlots[4].position == rings[1].transform.position) &&
            (ringSlots[5].position == rings[2].transform.position || ringSlots[5].position == rings[4].transform.position)
            ){
                NextLevel();
                return;
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1){
            
            if((ringSlots[2].position == rings[8].transform.position) &&
            (ringSlots[4].position == rings[5].transform.position || ringSlots[4].position == rings[4].transform.position) &&
            (ringSlots[5].position == rings[5].transform.position || ringSlots[5].position == rings[4].transform.position) &&
            (ringSlots[8].position == rings[7].transform.position)
            ){
                NextLevel();
                return;
            }
        }

        if(availableMoves == 0){
            lose.SetActive(true);
        }
        
    }

    public void NextLevel(){
        score+=1;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Level(int lev){
        SceneManager.LoadScene(lev);
    }
    public void Quit() {
        Application.Quit();
    }
    public void Moves(){
        availableMoves -= 1;
        scoreText.text = "Available moves: " + availableMoves;
    }
    public void PrintRes(){
        score = PlayerPrefs.GetInt("score", 0);
        scoreRes.text = "Result: " + score + "/3";
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.Save();
    }

}
