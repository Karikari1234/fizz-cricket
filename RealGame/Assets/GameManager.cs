using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class GameManager : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject activeMenu;
    public GameObject resumeMenu;
    public GameObject shotText;
    public GameObject bat;
    public GameObject outText;

    public void gameOver()
    {
        OutText();
        activeMenu.SetActive(false);
        controlBall.gameEnded = true;
        pauseMenu.SetActive(true);
       // Debug.Log("Game Over");
    }

    public void gameStateActive()
    {
        TextEditorScript.count = 0;
        controlBall.gameEnded = false;
        resumeMenu.SetActive(false);
        pauseMenu.SetActive(false);
        activeMenu.SetActive(true);
        //shotText.SetActive(false);
    }

    public void playAgainButton()
    {
        gameStateActive();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
       
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(1f);
    }

    public void changeText(string s)
    {
        
        shotText.SetActive(true);
        
        shotText.GetComponent<Text>().text = s + "!";
        Debug.Log(shotText.GetComponent<Text>().text);
        //StartCoroutine(Test());
        //shotText.SetActive(false);
    }

    public void pauseGame()
    {
        resumeMenu.SetActive(true);
        pauseMenu.SetActive(false);
        activeMenu.SetActive(false);
        gamePaused = true;
       
        Time.timeScale = 0f;
        bat.GetComponent<batScript>().enabled = false;
        
    }

    public void resumeGame()
    {
        resumeMenu.SetActive(false);
        pauseMenu.SetActive(false);
        activeMenu.SetActive(true);
        Time.timeScale = 1f;
        bat.GetComponent<batScript>().enabled = true;
    }

    public void OutText()
    {
        outText.GetComponent<Text>().text = "Out on " + TextEditorScript.count;
    }

}
