using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using System.IO;
using Unity.Mathematics;

public class ShowKeyboard : MonoBehaviour
{

    private TMP_InputField inputField;
    public TMP_InputField radiusField;
    public TMP_InputField timeField;
    public TMP_InputField ratioField;

    public static string radiusText;
    public static string timeText;
    public static string ratioText;
    public GameObject head;

    public static float radius, time;
    public static int badRatio;
    // Start is called before the first frame update
    void Start()
    {
        head.transform.rotation = Quaternion.identity;
        inputField = GetComponent<TMP_InputField>();
        if(SuperBubbles.therapistScene){
            SuperBubbles.therapistScene = false;
            LoadParameters(1);
            radiusField.text = radiusText;
            timeField.text = timeText;
            ratioField.text = ratioText;
        }
        inputField.onSelect.AddListener(x => OpenKeyboard());
    }

    public void OpenKeyboard(){
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(inputField.text);
    }

    [Serializable]
    class SaveData
    {
        public float Radius;
        public float Time;
        public int BadRatio;
    }

    public void SaveParameters(){
        SaveData data = new SaveData
        {
            Radius = float.Parse(radiusField.text),
            Time = float.Parse(timeField.text),
            BadRatio = int.Parse(ratioField.text)
        };

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);

    }

    public static void LoadParameters(int scene)
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if(scene == 1){
                radiusText = $"{data.Radius}";
                timeText = $"{data.Time}";
                ratioText = $"{data.BadRatio}";
            }
            else if(scene == 2){
                BubblesSpawn.radius = data.Radius;
                BubblesSpawn.time = data.Time;
                BubblesSpawn.badRatio = data.BadRatio;
            }
        }
    }
}
