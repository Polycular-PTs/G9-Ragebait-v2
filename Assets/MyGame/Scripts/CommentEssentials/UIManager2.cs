using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public List<Data> dataList;

    [SerializeField] Image Profil;
    [SerializeField] TMP_Text Name;
    [SerializeField] TMP_Text Comment;

    private int currentIndex = 0;

    private void Start()
    {
        LoadData(currentIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextComment();
        }
    }

    private void NextComment()
    {
        // Pick a NEW random index
       //currentIndex = UnityEngine.Random.Range(0, dataList.Count);

        // Load UI
        LoadData(currentIndex);
        Debug.Log("currentIndex = " + currentIndex);
    }

    private void LoadData(int index)
    {
        Profil.sprite = dataList[index].profilePicture;
        Name.text = dataList[index].name;
        Comment.text = dataList[index].comment;
    }
}

[Serializable]
public class Data
{
    public string name;
    public string comment;
    public Sprite profilePicture;
}
