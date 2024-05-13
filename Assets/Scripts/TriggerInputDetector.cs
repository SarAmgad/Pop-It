using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerInputDetector : MonoBehaviour
{
    private InputData _inputData;
    public static bool rTriggerClicked = false;
    public static bool lTriggerClicked = false;

    public static bool rGripClicked = false;
    public static bool lGripClicked = false;

    public static Vector3 rControllerPos;
    public static Vector3 lControllerPos;
    public GameObject rController, lController;

    public GameObject superBubble;

    public static List<Vector3> positions = new List<Vector3>();


    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float lTriggerValue) && lTriggerValue > 0.1f)
        {
            if (!lTriggerClicked && !SuperBubbles.isMenuOpen){
                lTriggerClicked = true;
                SuperBubbleInstaniate(lController.transform.position);
            }
        }
        else
        {
            lTriggerClicked = false;
        }


        
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.trigger, out float rTriggerValue) && rTriggerValue > 0.1f)
        {
            if (!rTriggerClicked && !SuperBubbles.isMenuOpen){
                rTriggerClicked = true;
                SuperBubbleInstaniate(rController.transform.position);
            }
        }
        else
        {
            rTriggerClicked = false;
        }

        // if (_inputData._leftController.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 lControllerPosition)){
        //     lControllerPos = lControllerPosition;
        // }

        // if (_inputData._rightController.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 rControllerPosition)){
        //     rControllerPos = rControllerPosition;
        // }

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.grip, out float lGripValue) && lGripValue > 0.1f)
        {
            lGripClicked = true;
        }else{
            lGripClicked = false;
        }

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.grip, out float rGripValue) && rGripValue > 0.1f)
        {
            rGripClicked = true;
        }else{
            rGripClicked = false;
        }
    }

    public void SuperBubbleInstaniate(Vector3 pos){
        SuperBubbles.positions.Add(pos);
        Instantiate(superBubble, pos, superBubble.transform.rotation);
    }
}
