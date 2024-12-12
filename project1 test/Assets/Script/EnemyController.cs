using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;
    public AudioClip hit1;
    public AudioClip hit2;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    /*
    public virtual void ChasePlayer(float speed)
    {
        if (player == null) return;

        Vector2 targetPosition = new Vector2(player.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    */

    public void Shoot()
    {
        if (bulletPrefab == null || bulletSpawnPoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        /*
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            // Set the bullet's velocity
            float direction = isFacingRight ? 1f : -1f;
            bulletRb.velocity = new Vector2(direction * bulletSpeed, 0f);
        }
        */
    }
}
