using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    private int currentDialogID = -1;

    private void DrawDialog()
    {
        if (currentDialogID == -1)
        {
            Debug.LogWarning("Should Initialize currentDialogID");
            return;
        }
        
        SentenceTableRows.Row Data = DataTableManager.Instance().GetSentenceData(currentDialogID);
        Debug.Log("ID : "+Data.id);
        Debug.Log("캐릭터 : "+Data.characterid);
        Debug.Log("문장 : "+Data.sentence);
        for (int i = 0; i < Data.branch.Length; i++)
        {
            Debug.Log("다음문장ID : "+Data.branch[i].next_sentence_id);
            Debug.Log("대답 : "+Data.branch[i].answer);
        }
        //TODO: 여기서 UI를 그려준다.
    }
    public void StartDialog(int SentenceId)
    {
        currentDialogID = SentenceId; //TODO: 네이밍 통일하면 좋을듯.
        DrawDialog();
    }

    public void Next(int BranchIndex)
    {
        //이 함수 없이 그냥 next_sentence_id로 StartDialog 불러줘도 될 듯?
    }
}
