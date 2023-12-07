using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    public Text highScoreText;
    float time = 15.0f;
    int point = 0;
    int highScore;
    GameObject generator;

    public void GetApple()
    {
        this.point += 300;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");
        // highScore = PlayerPrefs.GetInt("HighScore");
        SaveData saveData = Load();
        highScore = saveData != null ? saveData.highScore : 0;
        highScoreText.text = $"HighScore:{highScore}";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Save(new SaveData(point));

        }

        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
            if (point > highScore)
            {
                PlayerPrefs.SetInt("HighScore", point);  // 第一引数で保存名、第2引数で保存する中身を指定（今回はpointの中身）
            }
        }
        else if (0 <= this.time && this.time < 4)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.3f, -0.06f, 0);
        }
        else if (4 <= this.time && this.time < 12)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
        }
        else if (12 <= this.time && this.time < 23)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        }
        else if (23 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
    }

    void Save(SaveData data)
    {
        string path = Application.dataPath + "/save.json";
        StreamWriter sw = new StreamWriter(path);
        string json = JsonUtility.ToJson(data);
        sw.WriteLine(json);
        sw.Close();
        Debug.Log("セーブしました");
    }
    SaveData Load()
    {
        string path = Application.dataPath + "/save.json";
        SaveData saveData = null;
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            saveData = JsonUtility.FromJson<SaveData>(line);
            sr.Close();
        }
        return saveData;
    }

    [Serializable]
    class SaveData
    {
        public int highScore;

        public SaveData(int highScore)
        {
            this.highScore = highScore;
        }
    }
}