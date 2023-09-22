using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    private int currentDialogID; // 현재 대화 ID
    private DataTableManager dataTableManager;
    private void Start()
    {
        // DataTableManager 초기화
        dataTableManager = DataTableManager.Instance();

        // 대화 시작
        ShowNextDialog();
    }

    private void Update()
    {
        // 클릭 시 다음 대화로 이동
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextDialog();
        }
    }
    // 다음 대화로 이동하고 출력하는 함수
    private void ShowNextDialog()
    {
        currentDialogID++;//ID의 값을 1씩 증가시켜 다음 문장으로 전환
        SentenceTableRows.Row b = DataTableManager.Instance().GetSentenceData(currentDialogID); //문장데이터 받아오기
        Debug.Log("ID : "+b.id);
        Debug.Log("캐릭터 : "+b.characterid);
        Debug.Log("문장 : "+b.sentence);
        for (int i = 0; i < b.branch.Length; i++)
        {
            Debug.Log("문장 : "+b.branch[i].next_sentence_id);
            Debug.Log("답 : "+b.branch[i].answer);
        }
    }
}
