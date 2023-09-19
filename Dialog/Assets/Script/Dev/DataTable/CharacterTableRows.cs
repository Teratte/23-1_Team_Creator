using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTableRows : ScriptableObject
{
    //필드명은 모두 소문자여야 한다.
    //불필요한 띄어쓰기가 있으면 안 된다.
    [System.Serializable]
    public class Row
    {
        public int id;
        public string name;
        public Sprite characterimage;
        //TODO: 만약 감정표현같이 여러 캐릭터 이미지가 필요하면, Dictionary사용해서 Enum과 바인딩하면 될 듯
    }

    public Row[] rows;
}
