using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 存档要求对象的初始位置的(x,y,z)位置在两位小数精度内不得重叠。
/// </summary>
public class DataSerializerBase : MonoBehaviour 
{
    public bool saveActive;
    public bool saveTransform;

    private int _sceneIndex;
    private int _hashId;

    public int GetSceneId()
    {
        return _sceneIndex;
    }

    public int GetHashId()
    {
        return _hashId;
    }

    public SerializableData Serialize()
    {
        SerializableData res = new();
        InternalSerialize(res);
        //Debug.Log("序列化: " + res);
        return res;
    }

    protected virtual void InternalSerialize(SerializableData data)
    {
        if (saveActive)
        {
            data.active = gameObject.activeSelf;
        }

        if (saveTransform)
        {
            data.position = transform.position;
            data.rotation = transform.rotation;
            data.scale = transform.localScale;
        }
    }

    public virtual void Deserialize(SerializableData data)
    {
        //Debug.Log("反序列化: " + data);
        InternalDeserialize(data);
    }

    protected virtual void InternalDeserialize(SerializableData data)
    {
        if (saveTransform)
        {
            transform.position = data.position;
            transform.rotation = data.rotation;
            transform.localScale = data.scale;
        }
        
        if (saveActive)
        {
            gameObject.SetActive(data.active);
        }
    }

    
    protected virtual void Awake()
    {
        _sceneIndex = gameObject.scene.buildIndex;
        _hashId = transform.position.GetHashCode();
        //Debug.Log($"标识:[{_sceneIndex}, {_hashId}]");
        DataManager.Instance.LoadData(this);
    }

    protected virtual void OnDestroy()
    {
        DataManager.Instance.SaveData(this);
    }
}
