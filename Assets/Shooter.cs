using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bulet _bulletPrefab;
    [SerializeField] private Transform _shotPosiiton;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(DelayShoot());
    }

    private IEnumerator DelayShoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        Rigidbody rigidbodyBullet;
        bool isWork = true;

        while (isWork)
        {
            Vector3 direction = (_shotPosiiton.position - transform.position).normalized;
            Bulet currentBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            rigidbodyBullet = currentBullet.GetComponent<Rigidbody>();

            rigidbodyBullet.transform.up = direction;
            rigidbodyBullet.velocity = direction * _speed;

            yield return wait;
        }
    }
}