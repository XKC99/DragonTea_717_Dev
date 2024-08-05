using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    public static PlayerPositionManager Instance { get; private set; }
    private Vector3 savedPosition;
    private bool hasSavedPosition = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 确保这个管理器在场景加载中不被销毁
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerPosition(Vector3 position)
    {
        savedPosition = position;
        hasSavedPosition = true;
    }

    public Vector3 GetSavedPlayerPosition()
    {
        return savedPosition;
    }

    public bool HasSavedPosition()
    {
        return hasSavedPosition;
    }

    public void ClearSavedPosition()
    {
        hasSavedPosition = false;
    }
}
