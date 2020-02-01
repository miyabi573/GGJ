﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParts : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabList = new GameObject[0];
    private List<GameObject> _objectList;
    [SerializeField, Tooltip("1つ当たりの生成上限数")]
    private int _count = 1;
    [SerializeField]
    private bool _active = false;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        List<GameObject>_list = new List<GameObject>();
        _objectList = new List<GameObject>();
        foreach (GameObject prefab in _prefabList)
        {
            for (int i = 0; i < _count; i++)
            {
                GameObject obj = Instantiate(prefab,transform.position,prefab.transform.rotation);
                obj.SetActive(_active);
                obj.name = prefab.name;
                _list.Add(obj);
            }
        }
        for (int i = 0; i < _list.Count;)
        {
            int rad = Random.Range(0, _list.Count);
            Debug.Log(rad);
            if (_list[rad] != null)
            {
                i++;
                _objectList.Add(_list[rad]);
                _list[rad] = null;
            }
        }
    }

    public void SetParts()
    {
        if(_objectList.Count <= 0)
        {
            return;
        }
        GameObject obj = _objectList[0];
        obj.SetActive(true);
        //_objectList.Remove(obj);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SetParts();
        }
    }
}