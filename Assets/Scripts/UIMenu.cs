using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject menu;
    public void Menu(){
        SceneManager.LoadScene(0);
    }

    public void TherapistScene(){
        SuperBubbles.isMenuOpen = false;
        SceneManager.LoadScene(1);
    }

    public void StartGame(){
        SceneManager.LoadScene(2);
    }

    public void CloseMenu(){
        menu.SetActive(false);
        BubblesSpawn.pauseGame = false;
    }
}
