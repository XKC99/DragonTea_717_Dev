// CreateCustomClipAsset.cs

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class CreateCustomClipAsset
{
    [MenuItem("Assets/Create/CustomClip")]
    public static void CreateAsset()
    {
        CustomClip asset = ScriptableObject.CreateInstance<CustomClip>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/CustomClip.asset");
        AssetDatabase.SaveAssets();
    }
}
#endif
