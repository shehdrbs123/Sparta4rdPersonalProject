using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemManager))]
public class ItemManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        ItemManager manager = target as ItemManager;
        if (GUILayout.Button("테스트 아이템 생성"))
        {
            GameObject obj = manager.GetItem("TestItem");
            obj.SetActive(true);
        }
        base.OnInspectorGUI();
        
    }
}
