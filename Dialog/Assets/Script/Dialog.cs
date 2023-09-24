using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    private int currentDialogID = -1;

    // bool check_mouse = false;

    public Text Chat;
    public Text Char_name;
    public Image Char_Image;

    private void DrawDialog()
    {
        if (currentDialogID == -1)
        {
            Debug.LogWarning("Should Initialize currentDialogID");
            return;
        }

        SentenceTableRows.Row Data = DataTableManager.Instance().GetSentenceData(currentDialogID);
        CharacterTableRows.Row CharData = DataTableManager.Instance().GetCharacterData(Data.characterid);
       
        Debug.Log("ID : "+Data.id);
        Debug.Log("캐릭터 : "+Data.characterid);          // 캐릭터 csv id
        Debug.Log("문장 : "+Data.sentence);               // 문장


        for (int i = 0; i < Data.branch.Length; i++)
        {
            Debug.Log("다음문장ID : " + Data.branch[i].next_sentence_id);
            Debug.Log("대답 : " + Data.branch[i].answer);
        }

        /* if (check_mouse == true) // 마우스 좌 클릭시 다음문장 실행
         {
             for (int i = 0; i < Data.branch.Length; i++)
             {
                 Debug.Log("다음문장ID : " + Data.branch[i].next_sentence_id);
                 Debug.Log("대답 : " + Data.branch[i].answer);
             }
         }*/
        //TODO: 여기서 UI를 그려준다

        Chat.text = Data.sentence;                          // 문장 출력용 텍스트 레거시
        Char_name.text = CharData.name;                     // 캐릭터 이름 출력용 레거시
        Char_Image.sprite = CharData.characterimage;        // 캐릭터 이미지
    }

    public void Start()
    {
        StartDialog(1);
    }

   /*public void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌 클릭시
        {
            check_mouse = true;
        }
        else if (Input.GetMouseButtonUp(0)) // 좌 클릭업
        {
            check_mouse = false;
        }
    }*/

    public void StartDialog(int SentenceId)
    {
        currentDialogID = SentenceId; //TODO: 네이밍 통일하면 좋을듯.
        DrawDialog();
    }

    /*public void Next(int BranchIndex)
    {
        //이 함수 없이 그냥 next_sentence_id로 StartDialog 불러줘도 될 듯?
    }*/
}
