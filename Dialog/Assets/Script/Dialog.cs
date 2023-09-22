using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    private int currentDialogID; // ���� ��ȭ ID
    private DataTableManager dataTableManager;
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
        currentDialogID++;//ID�� ���� 1�� �������� ���� �������� ��ȯ
        SentenceTableRows.Row b = DataTableManager.Instance().GetSentenceData(currentDialogID); //���嵥���� �޾ƿ���
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
