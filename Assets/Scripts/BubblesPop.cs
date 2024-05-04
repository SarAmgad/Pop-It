using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubblesPop : MonoBehaviour
{
    public int colour; // 0 for y, 1 for r
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(){
        BubblesSpawn.usedPositions.Remove(gameObject.transform.position);
        Destroy(gameObject);
        if(colour == 0){
            BubblesSpawn.yDestroyed = true;
        }
        else if(colour == 1){
            BubblesSpawn.rDestroyed = true;
        }
    }

    // void OnTriggerEnter(){
    //     BubblesSpawn.usedPositions.Remove(gameObject.transform.position);
    //     Destroy(gameObject);
    //     BubblesSpawn.destroyed = true;
    //     Debug.Log("Trigger");
    // }
}
