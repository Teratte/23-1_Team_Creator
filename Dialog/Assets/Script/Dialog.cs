using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public int currentDialogID;
    private DataTableManager dataTableManager;

    private void Start()
    {
        // DataTableManager초기화
        dataTableManager = DataTableManager.Instance();
    }

    private void OnMouseDown()
    {
        StartDialog(currentDialogID);
        Debug.Log("실행 확인");
    }
    public void StartDialog(int dialogID)
    {
        // 대화 ID를 DataTableManager에서 데이터 가져오기
        SentenceTableRows.Row dialogData = dataTableManager.GetSentenceData(dialogID);
        if (dialogData != null)
        {
            // 대화를 화면에 표시
            Debug.Log("캐릭터의 ID: " + dialogData.characterid);
            Debug.Log("문장 출력: " + dialogData.sentence);

            // 다음 대사 표시 및 선택지 표시
            foreach (var branchInfo in dialogData.branch)
            {
                Debug.Log("다음 문장 ID: " + branchInfo.next_sentence_id);
                Debug.Log("답: " + branchInfo.answer);
            }
        }
        else
        {
            // 데이터 없으면 출력
            Debug.LogWarning("대화 데이터 없음: " + dialogID);
        }
    }
}
