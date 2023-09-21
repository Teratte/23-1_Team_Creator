using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
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
    
    private Dictionary<int, CharacterTableRows.Row> CharacterTable;
    private Dictionary<int, SentenceTableRows.Row> SentenceTable;
    
    private void LoadAndBuildTable()
    {
        CharacterTable = new Dictionary<int, CharacterTableRows.Row>();
        CharacterTableRows characterTable = Resources.Load("DataTable/CharacterTable", typeof(CharacterTableRows)) as CharacterTableRows;
        foreach (var row in characterTable.rows)
        {
            CharacterTable.Add(row.id, row);
        }

        SentenceTable = new Dictionary<int, SentenceTableRows.Row>();
        SentenceTableRows sentenceTable = Resources.Load("DataTable/SentenceTable", typeof(SentenceTableRows)) as SentenceTableRows;
        foreach (var row in sentenceTable.rows)
        {
            SentenceTable.Add(row.id, row);
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
        if (SentenceTable.ContainsKey(id))
        {
            return SentenceTable[id];
        }
        return null;
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
            
            if (str.IndexOf("/SentenceTable.csv") != -1)
            {
                TextAsset data = AssetDatabase.LoadAssetAtPath<TextAsset>(str);
                string assetfile = str.Replace(".csv", ".asset");
                SentenceTableRows gm = AssetDatabase.LoadAssetAtPath<SentenceTableRows>(assetfile);
                if (gm == null)
                {
                    gm = new SentenceTableRows();
                    AssetDatabase.CreateAsset(gm, assetfile);
                }

                gm.rows = CSVSerializer.Deserialize<SentenceTableRows.Row>(data.text);

                EditorUtility.SetDirty(gm);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
#endif
