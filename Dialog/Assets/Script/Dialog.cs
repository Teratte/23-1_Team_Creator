using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    private int currentDialogID = -1;

    public Text TXT_CharacterName;
    public Text TXT_Sentence;
    public Image IMG_CharacterImage;

    public GameObject BranchRoot;
    public GameObject BranchButton;

    private void DrawDialog()
    {
        if (currentDialogID == -1)
        {
            Debug.LogWarning("Should Initialize currentDialogID");
            return;
        }

        SentenceTableRows.Row Data = DataTableManager.Instance().GetSentenceData(currentDialogID);
        CharacterTableRows.Row CharData = DataTableManager.Instance().GetCharacterData(Data.characterid);

        TXT_CharacterName.text = CharData.name;
        TXT_Sentence.text = Data.sentence;
        IMG_CharacterImage.sprite = CharData.characterimage;
        
        for (int i = 0; i < Data.branch.Length; i++)
        {
            var NewButton =Instantiate(BranchButton, BranchRoot.transform);
            var rt = NewButton.GetComponent<RectTransform>();
            var ButtonText = NewButton.GetComponentInChildren<Text>();
            ButtonText.text = Data.branch[i].answer;
            Vector3 LocalPos = Vector3.zero;
            LocalPos.y = i * 100;
            rt.SetLocalPositionAndRotation(LocalPos, Quaternion.identity);
        }
    }

    public void Start()
    {
        StartDialog(2);
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
