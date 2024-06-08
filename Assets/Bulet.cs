using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bulet : MonoBehaviour 
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 direction)
    {
        transform.up = direction;
       _rigidbody.velocity = direction * _speed;
    }
}