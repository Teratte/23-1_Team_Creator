using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataTableManager
{
    private static DataTableManager instance;
    public static DataTableManager Instance()
    {
        if (instance == null)
        {
            instance = new DataTableManager();
            instance.LoadAndBuildTable();
        }
        return instance;
    }
    /***/
    
    public Dictionary<int, CharacterTableRows.Row> CharacterTable;
    
    private void LoadAndBuildTable()
    {
        CharacterTableRows table = Resources.Load("DataTable/CharacterTable", typeof(CharacterTableRows)) as CharacterTableRows;
        foreach (var row in table.rows)
        {
            CharacterTable.Add(row.id, row);
        }
    }
    
    public CharacterTableRows.Row GetCharacterData(int id)
    {
        if (CharacterTable.ContainsKey(id))
        {
            return CharacterTable[id];
        }
        return null;
    }
    
    public SentenceTableRows.Row GetSentenceData(int id)
    {
        SentenceTableRows.Row tmpData = new SentenceTableRows.Row();
        tmpData.id = id;
        tmpData.characterid = 1;
        tmpData.sentence = "이것은 임시 텍스트입니다. 입력된 ID는 " + id + "입니다.";
        tmpData.branch = new BranchInfo[2];
        tmpData.branch[0].answer = "ID 2번 호출";
        tmpData.branch[0].next_sentence_id = 2;
        tmpData.branch[1].answer = "ID 3번 호출";
        tmpData.branch[1].next_sentence_id = 3;
        return tmpData;
    }
}

#if UNITY_EDITOR
public class CSVImportPostprocessor : AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            // TODO: 테이블 개수 늘어나면 여기 중복코드 늘어날 것 같은데. 함수나 매크로로 묶어보자.
            // 파라미터는 테이블 이름, 클래스 두개면 될 듯
            // 테이블 네이밍 규칙을 만드는게 편할것이다.
            if (str.IndexOf("/CharacterTable.csv") != -1)
            {
                TextAsset data = AssetDatabase.LoadAssetAtPath<TextAsset>(str);
                string assetfile = str.Replace(".csv", ".asset");
                CharacterTableRows gm = AssetDatabase.LoadAssetAtPath<CharacterTableRows>(assetfile);
                if (gm == null)
                {
                    gm = new CharacterTableRows();
                    AssetDatabase.CreateAsset(gm, assetfile);
                }

                gm.rows = CSVSerializer.Deserialize<CharacterTableRows.Row>(data.text);

                EditorUtility.SetDirty(gm);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
#endif
