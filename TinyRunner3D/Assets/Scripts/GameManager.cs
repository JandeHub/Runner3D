using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
   
    public Transform[] dialogCommon;
    public Transform[] dialogCharacters;
    public Transform dialogText;
    
    [System.Serializable]
    public struct DialogData
    {
        public int character;
        public string text;

    };

    public DialogData[] dialogsData;

    private bool showingDialog;

    private Text dialogTextC;

    private int dialogIndex;

    
    void Start()
    {
        showingDialog = false;
        dialogIndex = 0;
        

        dialogTextC = dialogText.GetComponent<Text>();
    }


    void Update()
    {
      
        if (showingDialog)
        {
            
            for (int i = 0; i < dialogCommon.Length; i++) { dialogCommon[i].gameObject.SetActive(true); }
            for (int i = 0; i < dialogCharacters.Length; i++) { dialogCharacters[i].gameObject.SetActive(false); }

            int character = dialogsData[dialogIndex].character;
            string text = dialogsData[dialogIndex].text;

            dialogCharacters[character].gameObject.SetActive(true);
            dialogTextC.text = text;

            if (Input.GetKeyDown(KeyCode.L))
            {
                
                showingDialog = false;
            }

        }
        else
        {
            for (int i = 0; i < dialogCommon.Length; i++) { dialogCommon[i].gameObject.SetActive(false); }
            for (int i = 0; i < dialogCharacters.Length; i++) { dialogCharacters[i].gameObject.SetActive(false); }

        }


    }

    public void OnTriggerDialog(int index)
    {
        showingDialog = true;
        dialogIndex = index;
    }

    public bool IsShowingDialog()
    {
        return showingDialog;
    }


}
