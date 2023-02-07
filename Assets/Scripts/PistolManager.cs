using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolManager : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] GameObject _projectileSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShoot()
    {
        Instantiate(_projectilePrefab, _projectileSpawnPoint.transform.position, _projectileSpawnPoint.transform.rotation);
    }
}
