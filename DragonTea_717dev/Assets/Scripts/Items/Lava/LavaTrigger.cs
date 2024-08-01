using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹Prefab
    public Transform spawnPoint; // 子弹发射位置
    public float bulletSpeed = 5f; // 子弹速度
    public float bulletLifetime = 5f; // 子弹生命周期
    public Vector2 fireDirection = Vector2.left; // 发射方向，默认向右

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = fireDirection.normalized * bulletSpeed; // 使用发射方向
        Destroy(bullet, bulletLifetime); // 在一定时间后销毁子弹
    }
}
