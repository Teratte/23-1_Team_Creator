using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    private int currentDialogID; // ���� ��ȭ ID
    private DataTableManager dataTableManager;
    int j = 0;
    private void Start()
    {
        // DataTableManager �ʱ�ȭ
        dataTableManager = DataTableManager.Instance();

        // ��ȭ ����
        ShowNextDialog();
    }

    private void Update()
    {
        // Ŭ�� �� ���� ��ȭ�� �̵�
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextDialog();
        }
    }
    // ���� ��ȭ�� �̵��ϰ� ����ϴ� �Լ�
    private void ShowNextDialog()
    {
        j++;
        SentenceTableRows.Row b = DataTableManager.Instance().GetSentenceData(j); //���嵥���� �޾ƿ���
        Debug.Log("ID : "+b.id);
        Debug.Log("ĳ���� : "+b.characterid);
        Debug.Log("���� : "+b.sentence);
        for (int i = 0; i < b.branch.Length; i++)
        {
            Debug.Log("���� : "+b.branch[i].next_sentence_id);
            Debug.Log("�� : "+b.branch[i].answer);
        }
    }
}
