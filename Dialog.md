# Dialog
### Property
- __character table__
    - __id__: `integer`, unique key
    - __name__: `string`, character name
    - __image__: `path` character image

_e.g._
|id|name|image|
|-|-|-|
|1|John| /images/John.png
|2|Mary| /images/Mary.png
|3|Tom| /images/Tom.png

- __sentence table__
    - __id__: `integer`, unique key
    - __characterId__: `integer`, foreign key of character table
    - __sentence__: `string`, sentence
    - __branch__: `array` of `branchInfo`, increase by how many branch you want
        - __branchInfo__: 
            - __nextSentenceId__: `integer`, if -1, end of dialog
            - __answer__: `string`, answer to branch

_e.g._
|id|characterId|sentence|nextSentenceId|
|-|-|-|-|
|1|1|"이게 뭔지 알아?"|{2, "아니 모르겠어"}|
|2|1|과일이야. 둘 중 하나 선택해 봐|{3, "사과를 선택한다."}, {4, "포도를 선택한다."}|
|3|2|"하하! 사과를 선택했네"|{5, "그런가 보다."}|
|4|2|"헐? 포도를 선택했네?"|{5, "그런가 보다."}|
|5|3|"어쩌라는 걸까..."|{-1, "대화를 종료한다."}|

### Object
- __Dialog__: `class`
    - __Variables__
        - CurrentSentenceId: `integer`
    - __Methods__
        - void DrawDialog()
            `CurrentSentenceId로 테이블을 읽어 UI를 그린다.`
        - void StartDialog(int SentenceId)
            `CurrentSentenceId를 SentenceId로 초기화하고 DrawDialog()를 호출한다.`
        - void Next(int BranchIndex)
            `CurrentSentenceId를 BranchIndex에 해당하는 branch의 nextSentenceId로 초기화하고 DrawDialog()를 호출한다.`