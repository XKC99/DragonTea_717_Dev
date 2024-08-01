using System.Collections;
using UnityEngine;

public class LavaAutoTrigger : MonoBehaviour
{
    public GameObject bulletPrefab;    // 子弹预制件
    public float fireRate = 1f;        // 发射频率
    public float bulletSpeed = 5f;     // 子弹速度
    public float bulletLifeTime = 5f;  // 子弹寿命（秒）
    public Vector2 fireDirection = Vector2.right; // 发射方向

    void Start()
    {
        StartCoroutine(FireBullets());
    }

    IEnumerator FireBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = fireDirection.normalized * bulletSpeed;
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeTime));
    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (bullet != null)
        {
            Destroy(bullet);
        }
    }
}
