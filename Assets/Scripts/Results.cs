using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI mistakes;

    void Start(){
        score.text = $"Score: {BubblesPop.score} bubble in {BubblesSpawn.time} sec"; // Yellow only
        mistakes.text = $"Mistakes: {BubblesPop.mistake} red bubble";
    }

}
