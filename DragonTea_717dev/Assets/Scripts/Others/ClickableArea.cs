using UnityEngine;

public class ClickableArea : MonoBehaviour
{
    // 在Inspector面板中可以设置的方法
    public UnityEngine.Events.UnityEvent OnClick;

    void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            // 将鼠标点击位置从屏幕坐标转换为世界坐标
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 检查点击位置是否在该物体的碰撞体范围内
            Collider2D collider = GetComponent<Collider2D>();
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                // 调用事件
                OnClick.Invoke();
            }
        }
    }
}
