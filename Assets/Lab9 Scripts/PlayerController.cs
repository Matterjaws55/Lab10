using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public int score;

    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Fire.performed += ctx => Fire();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    void Fire()
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
    }

    public SaveData Save()
    {
        return new SaveData
        {
            player = new PlayerData
            {
                x = transform.position.x,
                y = transform.position.y,
                z = transform.position.z,
                score = score
            }
        };
    }

    public void Load(SaveData data)
    {
        transform.position = new Vector3(data.player.x, data.player.y, data.player.z);
        score = data.player.score;
    }
}