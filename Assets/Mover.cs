using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlacesPoint;

    private Transform[] _wayPoint;
    private int _currentIndex = 0;

    private void Start()
    {
        _wayPoint = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _wayPoint[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform pointByIndex = _wayPoint[_currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, pointByIndex.position, _speed * Time.deltaTime);

        if (transform.position == pointByIndex.position)
            ChangeTargetPosition();
    }

    private void ChangeTargetPosition()
    {
        _currentIndex = (++_currentIndex) % _wayPoint.Length;
        Vector3 pointVector = _wayPoint[_currentIndex].position;
        transform.forward = pointVector - transform.position;
    }
}
