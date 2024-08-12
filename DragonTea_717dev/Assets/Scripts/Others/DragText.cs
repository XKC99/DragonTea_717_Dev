using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragTextWithDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    // 目标区域的引用
    public RectTransform targetArea;
    
    // 定义一个速度因子
    public float speedFactor = 1.0f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta * speedFactor / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        // 检查Text的RectTransform是否与目标区域的RectTransform重叠
        if (IsOverlapping(rectTransform, targetArea))
        {
            // 触发成功放置事件
            OnDropSuccess();
        }
        else
        {
            Debug.Log("Text未放置在目标区域内。");
        }
    }

    private bool IsOverlapping(RectTransform rect1, RectTransform rect2)
    {
        // 获取两个矩形在屏幕空间中的世界矩形（World Rect）
        Rect rect1WorldRect = RectTransformToScreenSpace(rect1);
        Rect rect2WorldRect = RectTransformToScreenSpace(rect2);

        // 检查两个矩形是否重叠
        return rect1WorldRect.Overlaps(rect2WorldRect);
    }

    private Rect RectTransformToScreenSpace(RectTransform transform)
    {
        Vector3[] corners = new Vector3[4];
        transform.GetWorldCorners(corners);
        return new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);
    }

    private void OnDropSuccess()
    {
        Debug.Log("Text成功拖拽到目标区域！");
        // 在这里你可以加入更多的逻辑，如播放动画、更新UI等。
    }
}
