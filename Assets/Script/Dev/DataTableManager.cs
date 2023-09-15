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
    
    public Dictionary<int, TestDataRows.Row> TestTable;
    
    private void LoadAndBuildTable()
    {
        // TODO: Getter에서 로드하지 말고, 여기서 로드를 미리 하고 Dictionary에 id와 커플링 해서 데이터를 넣어놓는다.
        // 그러면 index가 아니라 id로 row를 찾을 수 있게 된다.
    }
    
    public TestDataRows.Row GetTestData(int id)
    {
        TestDataRows table = Resources.Load("DataTable/TestDataTable", typeof(TestDataRows)) as TestDataRows;
        return table.rows[id];
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
            if (str.IndexOf("/TestDataTable.csv") != -1)
            {
                TextAsset data = AssetDatabase.LoadAssetAtPath<TextAsset>(str);
                string assetfile = str.Replace(".csv", ".asset");
                TestDataRows gm = AssetDatabase.LoadAssetAtPath<TestDataRows>(assetfile);
                if (gm == null)
                {
                    gm = new TestDataRows();
                    AssetDatabase.CreateAsset(gm, assetfile);
                }

                gm.rows = CSVSerializer.Deserialize<TestDataRows.Row>(data.text);

                EditorUtility.SetDirty(gm);
                AssetDatabase.SaveAssets();
#if DEBUG_LOG || UNITY_EDITOR
                Debug.Log("Reimported Asset: " + str);
#endif
            }
        }
    }
}
#endif
