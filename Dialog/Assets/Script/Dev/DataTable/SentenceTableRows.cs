using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BranchInfo
{
    public int next_sentence_id;
    public string answer;
}
public class SentenceTableRows : ScriptableObject
{
    //필드명은 모두 소문자여야 한다.
    //불필요한 띄어쓰기가 있으면 안 된다.
    [System.Serializable]
    public class Row
    {
        public int id;
        public int characterid;
        public string sentence;
        //TODO: 커스텀타입 파싱 구현 필요
        public BranchInfo[] branch;
    }

    public Row[] rows;
}
