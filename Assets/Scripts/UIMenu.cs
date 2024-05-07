using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(2);
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }

    public void TherapistScene(){
        SceneManager.LoadScene(1);
    }
}
