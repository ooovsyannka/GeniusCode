using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlacesPoint;

    private Transform[] _arrayPlaces;
    private int _indexPlace;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform _pointByIndex = _arrayPlaces[_indexPlace];
        transform.position = Vector3.MoveTowards(transform.position, _pointByIndex.position, _speed * Time.deltaTime);

        if (transform.position == _pointByIndex.position)
            GetNewPlace();
    }

    private Vector3 GetNewPlace()
    {
        _indexPlace++;

        if (_indexPlace == _arrayPlaces.Length)
            _indexPlace = 0;

        Vector3 pointVector = _arrayPlaces[_indexPlace].transform.position;
        transform.forward = pointVector - transform.position;

        return pointVector;
    }
}
