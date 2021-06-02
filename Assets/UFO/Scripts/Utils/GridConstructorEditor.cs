#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Utils
{
    [CustomEditor(typeof(GridConstructor))]
    public class GridConstructorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GridConstructor gridConstructor = (GridConstructor)target;
            if (GUILayout.Button("Create From Start Point"))
            {
                EditorUtility.SetDirty(gridConstructor);
                gridConstructor.Create();
            }
            if (GUILayout.Button("Set Center Parent Coord"))
            {
                EditorUtility.SetDirty(gridConstructor);
                gridConstructor.SetCenterParentCoord();
            }
            if (GUILayout.Button("Clear"))
            {
                EditorUtility.SetDirty(gridConstructor);
                gridConstructor.Clear();
            }            
        }
    }
}
#endif