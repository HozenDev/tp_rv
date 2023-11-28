using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMouvement : MonoBehaviour
{
    //public GameObject _sourceObject;
    private Transform _sourceTransform;

    public float _speed = 10.0f;
    public float _increment;

    // Start is called before the first frame update
    void Start()
    {
        // get source object
        //_sourceObject = GameObject.Find("Eyes");

        _sourceTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        _increment = _speed * Time.deltaTime;

        _sourceTransform.Translate(Input.GetAxis("Horizontal") * _increment, 0, Input.GetAxis("Vertical") * _increment);
    }
}
