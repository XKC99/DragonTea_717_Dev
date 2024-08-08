#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
//using UnityEngine.Timeline;
using UnityEditor.Timeline;


[CustomEditor(typeof(CustomClip))]
public class CustomClipEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CustomClip clip = (CustomClip)target;

        if (GUILayout.Button("Set From Scene"))
        {
            if (TimelineEditor.inspectedDirector != null)
            {
                GameObject go = TimelineEditor.inspectedDirector.gameObject;
                if (go != null)
                {
                    Transform t = go.GetComponent<Transform>();
                    if (t != null)
                    {
                        clip.template.position = t.position;
                        clip.template.scale = t.localScale;
                        clip.template.initialized = true;
                        EditorUtility.SetDirty(clip);
                    }
                }
            }
        }
    }
}
#endif