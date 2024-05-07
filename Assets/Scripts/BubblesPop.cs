using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubblesPop : MonoBehaviour
{
    public int colour; // 0 for y, 1 for r
    public static int score;
    public static int mistake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopBubble(){
        BubblesSpawn.usedPositions.Remove(gameObject.transform.position);
        Destroy(gameObject);
        if(colour == 0){
            BubblesSpawn.yDestroyed = true;
            score++;
        }
        else if(colour == 1){
            BubblesSpawn.rDestroyed = true;
            mistake++;
        }
    }

    public void PopSuperBubble(){
        Destroy(gameObject);
        BubblesSpawn.superBubblesCount--;
    }

}
