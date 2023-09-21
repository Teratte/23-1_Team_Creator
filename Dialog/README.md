# Dialog

## __How to use?__
### 테이블 소개
Dialog를 위한 CharacterTable, SentenceTable이 존재한다.
- __CharacterTable__
    - __id__: `integer`, unique key
    - __name__: `string`, character name
    - __characterimage__: `path` character image

_e.g._
|id|name|characterimage|
|-|-|-|
|1|Bono|Assets/Sprite/Character/Bono.png|
|2|OnoB|Assets/Sprite/Character/OnoB.png|

- __SentenceTable__
    - __id__: `integer`, unique key
    - __characterId__: `integer`, foreign key of character table
    - __sentence__: `string`, sentence
    - __branch__: `array` of `branchInfo`, increase by how many branch you want
        - __branchInfo__: 
            - __nextSentenceId__: `integer`, if -1, end of dialog
            - __answer__: `string`, answer to branch

_e.g._
|id|characterId|sentence|branch|
|-|-|-|-|
|1|1|"이게 뭔지 알아?"|2,아니 모르겠어|
|2|1|과일이야. 둘 중 하나 선택해 봐|3,사과를 선택한다.,4,포도를 선택한다.|
|3|2|"하하! 사과를 선택했네"|5,그런가 보다.|
|4|2|"헐? 포도를 선택했네?"|5,그런가 보다.|
|5|3|"어쩌라는 걸까..."|-1,대화를 종료한다.|

### 테이블 업데이트 방법
    1. Resources/DataTable 폴더의 csv파일을 수정한다.
    2. 엔진에서 csv파일을 Reimport를 한다.
    3. Rows 객체가 업데이트 되었는지 확인한다.

### 코드 예시
DataTableManager라는 클래스를 통해 접근한다.
Assets/Script/Tester.cs에 예시가 있다.
```csharp
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
``````