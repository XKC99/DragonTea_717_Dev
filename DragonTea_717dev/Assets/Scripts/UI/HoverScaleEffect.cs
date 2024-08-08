using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverScaleEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float hoverScale = 1.2f;
    [SerializeField] private Color hoverColor = Color.yellow;

    private Image _image;
    private RectTransform _rectTransform;
    private Vector3 _originalScale;
    private Color _originalColor;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        _originalScale = _rectTransform.localScale;
        _originalColor = _image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayOneShot("UIyiru");
        // 当鼠标进入时，改变颜色和缩放
        _image.color = hoverColor;
        _rectTransform.localScale = _originalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 当鼠标离开时，恢复原始颜色和缩放
        _image.color = _originalColor;
        _rectTransform.localScale = _originalScale;
    }
}