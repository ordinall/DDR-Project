using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletControllerPooled : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _bulletLifeTime = 2f;
    [SerializeField] private TextMeshProUGUI _DestroyedTextMesh;
    [SerializeField] private TextMeshProUGUI _BulletCountTextMesh;
    private int bulletCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _BulletCountTextMesh.text = $"Active Bullet Count: {bulletCount}";
    }
    
    void FixedUpdate()
    {
        // if space is pressed
        if (Input.GetKey(KeyCode.Space))
        {

            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = _bulletSpawnPoint.position;
                bullet.transform.rotation = _bulletSpawnPoint.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * _bulletSpeed;
                bulletCount++;
                //Destroy(bullet, _bulletLifeTime);
                StartCoroutine(destroyBullet(bullet));
            }
            
        }
    }

    IEnumerator destroyBullet(GameObject bullet) {
        yield return new WaitForSeconds(_bulletLifeTime);
        _DestroyedTextMesh.text = $"Deactivating";
        bullet.SetActive(false);
        bulletCount--;
        Invoke("setToBlank", 0.1f);
    }

    void setToBlank() {
        _DestroyedTextMesh.text = "";
    }
}
