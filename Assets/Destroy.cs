using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _gameObject;
    
    public void DestroyPrefab()
    {
        Destroy(_gameObject);
    }
}
