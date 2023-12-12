using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Transform _backupTransform; // get source parent transform before trigger
    private Transform _srcTransform;
    private GameObject _srcObject;
    private Rigidbody _srcRigidBody;

    public GameObject _trigger;
    private Transform _triggerTransform;
    private bool _isBound;
    private bool _spacePressed;

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("deb");
        if (other.gameObject.name == "Sword" && Input.GetKey("space") && !_spacePressed)
        {
            _spacePressed = true;
            Debug.Log("in");
            if (!_isBound)
            {
                _srcTransform.SetParent(_triggerTransform,true);
                _srcRigidBody.isKinematic = true;
                _isBound = true;
            }
            else
            {
                _srcTransform.SetParent(_backupTransform,true);
                _srcRigidBody.isKinematic = false;
                _isBound = false;
            }
        }
        else if (!Input.GetKey("space"))
        {
            _spacePressed=false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void Animation()
    {
        // todo
    }

    // Start is called before the first frame update
    void Start()
    {
        _srcObject = gameObject;
        _srcTransform = GetComponent<Transform>();
        _srcRigidBody = GetComponent<Rigidbody>();

        _trigger = GameObject.Find("Sword");
        _triggerTransform = _trigger.GetComponent<Transform>();

        _backupTransform = GetComponent<Transform>().parent;

        _isBound = false;
        _spacePressed = false;

        Debug.Log(_srcObject);
        Debug.Log(_trigger);
    }

    // Update is called once per frame
    void Update()
    {
        Animation();

    }
}
