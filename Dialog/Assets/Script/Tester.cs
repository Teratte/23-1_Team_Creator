using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterTableRows.Row a = DataTableManager.Instance().GetCharacterData(1); //캐릭터 데이터 받아오기
        Debug.Log(a.id);
        Debug.Log(a.name);
        Debug.Log(a.characterimage);
        
        Debug.Log("===================================");
        
        SentenceTableRows.Row b = DataTableManager.Instance().GetSentenceData(1); //문장데이터 받아오기
        Debug.Log(b.id);
        Debug.Log(b.characterid);
        Debug.Log(b.sentence);
        for (int i = 0; i < b.branch.Length; i++)
        {
            Debug.Log(b.branch[i].next_sentence_id);
            Debug.Log(b.branch[i].answer);
        }

        Debug.Log("===================================");
        
        b = DataTableManager.Instance().GetSentenceData(2); //문장데이터 받아오기
        Debug.Log(b.id);
        Debug.Log(b.characterid);
        Debug.Log(b.sentence);
        for (int i = 0; i < b.branch.Length; i++)
        {
            Debug.Log(b.branch[i].next_sentence_id);
            Debug.Log(b.branch[i].answer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
