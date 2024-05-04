using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using System.IO;

public class ShowKeyboard : MonoBehaviour
{
    private TMP_InputField inputField;

    public int field;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(x => OpenKeyboard());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SaveData data = new SaveData();
        if(field == 0)
            data.Radius = float.Parse(inputField.text);
        else if(field == 1)
            data.Time = float.Parse(inputField.text);
        else if(field == 2)
            data.BadRatio = int.Parse(inputField.text);

    string json = JsonUtility.ToJson(data);
        
    File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public static void LoadParameters()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BubblesSpawn.radius = data.Radius;
            BubblesSpawn.time = data.Time;
            BubblesSpawn.badRatio = data.BadRatio;
        }
    }
}
