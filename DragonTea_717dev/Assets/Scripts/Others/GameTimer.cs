using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public Transform startPoint; // 起点
    public Transform endPoint; // 终点
    public float countdownTime = 10f; // 倒计时持续时间
    public TextMeshProUGUI countdownText; // 倒计时文本UI
    public Color normalColor = Color.white; // 正常倒计时时的颜色
    public Color warningColor = Color.red; // 警告倒计时时的颜色
    public float warningThreshold = 3f; // 颜色变化的时间阈值

    private bool isCountingDown = false;
    private float timer;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        countdownText.text = countdownTime.ToString("F2"); // 初始化文本
        countdownText.color = normalColor; // 初始化颜色
    }

    void Update()
    {
        if (isCountingDown)
        {
            timer -= Time.deltaTime;
            countdownText.text = Mathf.Max(timer, 0).ToString("F2"); // 更新倒计时文本

            // 根据剩余时间更改颜色
            if (timer <= warningThreshold)
            {
                countdownText.color = warningColor;
            }
            else
            {
                countdownText.color = normalColor;
            }

            if (timer <= 0)
            {
                CheckPlayerPosition();
                isCountingDown = false; // 停止计时
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<DragonController>().ChangeReviePos(startPoint.position);
            if (other.transform == playerTransform && this.transform == startPoint)
            {
                StartCountdown();
            }
        }
    }

    public void StartCountdown()
    {
        timer = countdownTime;
        isCountingDown = true;
    }


    public void StopCountdown()
    {
        isCountingDown = false;
        this.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        // countdownText.color = normalColor; // 复位文本颜色
        // countdownText.text = "Success!"; // 显示成功信息
    }

    void CheckPlayerPosition()
    {
        if (Vector2.Distance(playerTransform.position, endPoint.position) > 0.5f)
        {
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        playerTransform.position = startPoint.position;
    }
}
