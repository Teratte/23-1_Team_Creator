using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public int currentDialogID;
    private DataTableManager dataTableManager;

    private void Start()
    {
        // DataTableManager�ʱ�ȭ
        dataTableManager = DataTableManager.Instance();
    }

    private void OnMouseDown()
    {
        StartDialog(currentDialogID);
        Debug.Log("���� Ȯ��");
    }
    public void StartDialog(int dialogID)
    {
        // ��ȭ ID�� DataTableManager���� ������ ��������
        SentenceTableRows.Row dialogData = dataTableManager.GetSentenceData(dialogID);
        if (dialogData != null)
        {
            // ��ȭ�� ȭ�鿡 ǥ��
            Debug.Log("ĳ������ ID: " + dialogData.characterid);
            Debug.Log("���� ���: " + dialogData.sentence);

            // ���� ��� ǥ�� �� ������ ǥ��
            foreach (var branchInfo in dialogData.branch)
            {
                Debug.Log("���� ���� ID: " + branchInfo.next_sentence_id);
                Debug.Log("��: " + branchInfo.answer);
            }
        }
        else
        {
            // ������ ������ ���
            Debug.LogWarning("��ȭ ������ ����: " + dialogID);
        }
    }
}
