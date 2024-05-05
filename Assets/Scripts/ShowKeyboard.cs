using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using System.IO;

public class ShowKeyboard : MonoBehaviour
{
    public TMP_InputField radiusField;
    public TMP_InputField timeField;
    public TMP_InputField ratioField;

    public int field;

    public static float radius, time;
    public static int badRatio;
    // Start is called before the first frame update
    void Start()
    {
        radiusField = GetComponent<TMP_InputField>();
        radiusField.onSelect.AddListener(x => OpenKeyboard());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenKeyboard(){
        NonNativeKeyboard.Instance.InputField = radiusField;
        NonNativeKeyboard.Instance.PresentKeyboard(radiusField.text);
    }

    [Serializable]
    class SaveData
    {
        public float Radius;
        public float Time;
        public int BadRatio;
    }

    // public void SaveData2(){
    //     radius = float.Parse(radiusField.text);
    //     time = float.Parse(timeField.text);
    //     badRatio = int.Parse(ratioField.text);
    //     Debug.Log("line 55data: " +radius+"  "+time+"  "+badRatio);  
    // }

    public void SaveParameters(){
        SaveData data = new SaveData
        {
            Radius = float.Parse(radiusField.text),
            Time = float.Parse(timeField.text),
            BadRatio = int.Parse(ratioField.text)
        };

        string json = JsonUtility.ToJson(data);
        Debug.Log("line 72 "); 
        Debug.Log("data: " +data.Radius+"  "+data.Time+"  "+data.BadRatio); 
        
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);

    }

    public static void LoadParameters()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            Debug.Log("file exist" + path );
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("line 74 data: " +data.Radius+"  "+data.Time+"  "+data.BadRatio);
            BubblesSpawn.radius = data.Radius;
            BubblesSpawn.time = data.Time;
            BubblesSpawn.badRatio = data.BadRatio;
        }
    }
}
