using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    public Transform _sourceTransform;
    public Transform _hitTransform;

    public Vector3 _forwardDirection;

    public Renderer _sourceRenderer;
    public Renderer _hitRenderer;

    public RaycastHit _hit;
    public GameObject _hitObject;
    public GameObject _sourceObject;
    public LineRenderer _sourceLR; 
    
    public int _maxLength;

    public bool _isDebugRayVisible;

    void DrawLine()
    {
        _sourceLR.positionCount = 2;
        _sourceLR.SetPosition(0, _sourceTransform.position);
        _sourceLR.SetPosition(1, _forwardDirection * _maxLength + _sourceTransform.position);
    }

    public void DrawDebugHitRay()
    {
        if (_hitObject != null && _isDebugRayVisible)
        {
            Debug.DrawRay(_sourceTransform.position, _sourceTransform.TransformDirection(_forwardDirection * _hit.distance), Color.red);
        }
    }

    public void getHitObject()
    {
        if (Physics.Raycast(_sourceTransform.position, _forwardDirection, out _hit, _maxLength))
        {
            _hitObject = _hit.collider.gameObject;
            _hitTransform = _hitObject.GetComponent<Transform>();
            _hitRenderer = _hitObject.GetComponent<Renderer>();

            DrawDebugHitRay();
            Debug.Log("Object detected: " + _hitObject.name);
        }
    }

    public void removeHitObject()
    {
        _hitObject = null;
        _hitTransform = null;
        _hitRenderer = null;
    }

    public void modifyHitRendererColor(Color color)
    {
        if (_hitObject != null)
        {
            _hitRenderer.material.color = color;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // set max ray length
        _maxLength = 100;

        _isDebugRayVisible = true;

        // get source object
        _sourceObject = gameObject;

        // get source transform
        _sourceTransform = GetComponent<Transform>();
        _forwardDirection = _sourceTransform.forward;

        // get source renderer
        _sourceRenderer = GetComponent<Renderer>();

        _sourceLR = _sourceObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
        _sourceLR.startWidth = 0f;
        _sourceLR.endWidth = 0.4f;
        _sourceLR.material = new Material(Shader.Find("Sprites/Default"));
        _sourceLR.startColor = Color.green;
        _sourceLR.endColor = Color.blue;

        //getHitObject();
        //DrawDebugHitRay();
    }

    // Update is called once per frame
    void Update()
    {
        _forwardDirection = _sourceTransform.forward;

        if (Input.GetMouseButtonDown(0))
        {
            //modifyHitRendererColor(Color.white);
            getHitObject();
            DestroyIngredient();
            //modifyHitRendererColor(Color.red);
            //_isDebugRayVisible = !_isDebugRayVisible;
        }
        if (Input.GetMouseButtonDown(1))
        {  
            //modifyHitRendererColor(Color.white);
            removeHitObject();
        }
        DrawDebugHitRay();
        DrawLine();
        
    }

    private void OnApplicationQuit()
    {
        Destroy(_sourceLR);
    }

    private void DestroyIngredient()
    {
        if (_hitObject.tag == "Ingredient"){
            Destroy(_hitObject);
        }
    }
}
