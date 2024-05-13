using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubblesPop : MonoBehaviour
{
    public int colour; // 0 for y, 1 for r
    public static int score;
    public static int mistake;

    public void OnCollisionEnter() {
        
        
        Destroy(gameObject);
        if(colour == 0){
            BubblesSpawn.usedPositions.Remove(gameObject.transform.position);
            BubblesSpawn.yDestroyed = true;
            score++;
        }
        else if(colour == 1){
            BubblesSpawn.usedPositions.Remove(gameObject.transform.position);
            BubblesSpawn.rDestroyed = true;
            mistake++;
        }
        else if(colour == 2){
            // Destroy(gameObject);
            BubblesSpawn.superBubblesCount--;
        }
    }

    public void PopSuperBubble(){
        Destroy(gameObject);
        BubblesSpawn.superBubblesCount--;
    }

}
