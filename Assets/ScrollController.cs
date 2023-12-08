using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform content;
    int count = 1;


    public void CreateText()
    {
        GameObject text = Instantiate(textPrefab, content);
        text.GetComponent<Text>().text = $"テキスト{count}";
        count++;
    }


}
