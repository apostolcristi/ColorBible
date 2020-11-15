using UnityEngine;
using UnityEditor;
using System.Collections;
using IndieStudio.DrawingAndColoring.Logic;
using IndieStudio.DrawingAndColoring.Utility;
using UnityEngine.UI;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieStudio.DrawingAndColoring.DCEditor
{
    [CustomEditor(typeof(ShapesManager1))]
    public class ShapesManagerEditor1 : Editor
    {
        private static bool showInstructions = true;
        private Sprite previewSprite;

        public override void OnInspectorGUI()
        {
            ShapesManager1 shapesManager = (ShapesManager1)target;//get the target

            EditorGUILayout.Separator();
            #if !(UNITY_5 || UNITY_2017 || UNITY_2018_0 || UNITY_2018_1 || UNITY_2018_2)
				//Unity 2018.3 or higher
				EditorGUILayout.BeginHorizontal();
				GUI.backgroundColor = Colors.cyanColor;
				EditorGUILayout.Separator();
				if(PrefabUtility.GetPrefabParent(shapesManager.gameObject)!=null)
				if (GUILayout.Button("Apply", GUILayout.Width(70), GUILayout.Height(30), GUILayout.ExpandWidth(false)))
				{
					PrefabUtility.ApplyPrefabInstance(shapesManager.gameObject, InteractionMode.AutomatedAction);
				}
				GUI.backgroundColor = Colors.whiteColor;
				EditorGUILayout.EndHorizontal();
            #endif
            EditorGUILayout.Separator();

            EditorGUILayout.HelpBox("Follow the instructions below on how to add new shape's prefab", MessageType.Info);
            EditorGUILayout.Separator();

            showInstructions = EditorGUILayout.Foldout(showInstructions, "Instructions");
            EditorGUILayout.Separator();

            if (showInstructions)
            {
                EditorGUILayout.HelpBox("- Click on 'Add New Shape' button to add new Shape", MessageType.None);
                EditorGUILayout.HelpBox("- Click on 'Remove Last Shape' button to remove the lastest shape in the list", MessageType.None);
                EditorGUILayout.HelpBox("- Click on ShapesManager1 'Apply' button that located at the top to save your changes ", MessageType.None);
            }

            EditorGUILayout.Separator();

            GUILayout.BeginHorizontal();
            GUI.backgroundColor = Colors.greenColor;

            if (GUILayout.Button("Add New Shape", GUILayout.Width(110), GUILayout.Height(20)))
            {
                shapesManager.shapes.Add(new ShapesManager1.Shape1());
            }

            GUI.backgroundColor = Colors.yellowColor;

            if (GUILayout.Button("More Assets", GUILayout.Width(110), GUILayout.Height(20)))
            {
                Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:9268");
            }

            GUI.backgroundColor = Colors.whiteColor;
            GUILayout.EndHorizontal();

            EditorGUILayout.Separator();

            for (int i = 0; i < shapesManager.shapes.Count; i++)
            {
                shapesManager.shapes[i].showContents1 = EditorGUILayout.Foldout(shapesManager.shapes[i].showContents1, "Shape[" + i + "]");

                if (shapesManager.shapes[i].showContents1)
                {
                    EditorGUILayout.Separator();

                    EditorGUILayout.BeginHorizontal();
                    //EditorGUILayout.Separator();

                    GUI.backgroundColor = Colors.redColor;
                    if (GUILayout.Button("Remove", GUILayout.Width(70), GUILayout.Height(20)))
                    {
                        bool isOk = EditorUtility.DisplayDialog("Confirm Message", "Are you sure that you want to remove the selected shape ?", "yes", "no");

                        if (isOk)
                        {
                            shapesManager.shapes.RemoveAt(i);
                            return;
                        }
                    }
                    GUI.backgroundColor = Colors.whiteColor;
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.Separator();

                    //Shape prefab
                    shapesManager.shapes[i].gamePrefab1 = EditorGUILayout.ObjectField("Shape Prefab", shapesManager.shapes[i].gamePrefab1, typeof(GameObject), true) as GameObject;

                    if (shapesManager.shapes[i].gamePrefab1 != null)
                    {
                        previewSprite = null;

                        if (shapesManager.shapes[i].gamePrefab1.GetComponent<Image>()!=null)
                           previewSprite = shapesManager.shapes[i].gamePrefab1.GetComponent<Image>().sprite;
                        EditorGUILayout.Separator();
                        EditorGUILayout.LabelField("Shape Prefab Preview");

                        EditorGUILayout.ObjectField("", previewSprite, typeof(Sprite), false);
                    }

                    EditorGUILayout.BeginHorizontal();

                    EditorGUI.BeginDisabledGroup(i == shapesManager.shapes.Count - 1);
                    if (GUILayout.Button("▼", GUILayout.Width(22), GUILayout.Height(22)))
                    {
                        MoveDown(i, shapesManager);
                    }
                    EditorGUI.EndDisabledGroup();

                    EditorGUI.BeginDisabledGroup(i - 1 < 0);
                    if (GUILayout.Button("▲", GUILayout.Width(22), GUILayout.Height(22)))
                    {
                        MoveUp(i, shapesManager);
                    }
                    EditorGUI.EndDisabledGroup();

                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.Separator();
                    GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));
                }

                EditorGUILayout.Separator();
            }

            if (GUI.changed)
            {
                DirtyUtil.MarkSceneDirty();
            }
        }

        private void MoveUp(int index, ShapesManager1 sm)
        {
            ShapesManager1.Shape1 shape = sm.shapes[index];
            sm.shapes.RemoveAt(index);
            sm.shapes.Insert(index - 1, shape);
        }

        private void MoveDown(int index, ShapesManager1 sm)
        {
            ShapesManager1.Shape1 shape = sm.shapes[index];
            sm.shapes.RemoveAt(index);
            sm.shapes.Insert(index + 1, shape);
        }
    }
}