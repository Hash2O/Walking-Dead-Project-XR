using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //Objet � instancier
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<GameObject> _zombiePrefabs;

    //Pour d�terminer la position de spawn
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private List<Transform> _spawnPoints;

    //[SerializeField] private Transform _secondarySpawnPoint;

    //Wave of zombies
    [SerializeField] private int _nombreDeZombies;

    [SerializeField] private GameObject _projectilePrefab;

    [SerializeField] private InputActionReference _actionSpawnZombies; //Pour �couter la nouvelle map GameInputs dans Starter Assets

    //private float spawnRangeX = 50;

    //private float startDelay = 2.0f;
    //private float repeatRate = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //InstantiateXobjectsRandomly();
        //InvokeRepeating("InstantiateXobjectsAtTwoSpawnPoints", startDelay, repeatRate);
        //SpawnRandomZombie();

        /*
        _actionSpawnZombies.action.Enable(); //On active la fonction
        _actionSpawnZombies.action.performed += OnSpawnZombie;
        */

        InvokeRepeating("InstantiateXObjectsAtRandomSpawnPoint", 5.0f, 5.0f);
    }

    //Action qui tient compte du contexte de l'input
    private void OnSpawnZombie(InputAction.CallbackContext obj)
    {
        InstantiateXObjectsAtRandomSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateObject()
    {
        //Instancier un zombie dans la sc�ne
        GameObject.Instantiate(_prefab);
    }

    public void InstantiateXobjectsAtSpawnPoint()
    {
        for (int i = 0; i < _nombreDeZombies; i++)
        {
            InstantiateObjectAtSpawnPoint();
        }
    }

    public void InstantiateObjectAtSpawnPoint()
    {
        //Instancier un zombie dans la sc�ne
        Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
    }

    public void InstantiateXObjectsAtRandomSpawnPoint()
    {
        for(int i = 0; i < _nombreDeZombies; i++)
        {
            int aleatoire = Random.Range(0, _spawnPoints.Count); //Nbre max jamais atteint puisque int
            int zombieRandom = Random.Range(0, _zombiePrefabs.Count);
            _prefab = _zombiePrefabs[zombieRandom];
            _spawnPoint = _spawnPoints[aleatoire]; //On d�signe le spawn point choisi al�atoirement
            InstantiateObjectAtSpawnPoint(); //Fonction juste au dessus
        }
    }



    public void InstantiateObjectAtPosition(int x, int z)
    {
        //Instancier un zombie dans la sc�ne
        GameObject.Instantiate(_prefab, new Vector3(x, 0.04999924f, z), Quaternion.identity);
    }

    public void InstantiateObjectAtPositionWithRandomDirection(int x, int z)
    {
        //Instancier un zombie dans la sc�ne
        GameObject.Instantiate(_prefab, new Vector3(x, 0.04999924f, z), Quaternion.identity);
    }

    public void InstantiateXobjectsRandomly()
    {
        for(int i = 0; i < _nombreDeZombies; i++)
        {
            int a, b;
            a = Random.Range(-50, 51); 
            b = Random.Range(-50, 51);
            InstantiateObjectAtPosition(a, b);
        }
    }

    /*
    void SpawnRandomZombie()
    {
 
        int zombieIndex = Random.Range(0, zombiePrefabs.Length);

        for (int i = 0; i < _nombreDeZombies; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeX, spawnRangeX));
            Instantiate(zombiePrefabs[zombieIndex], spawnPos, zombiePrefabs[zombieIndex].transform.rotation);
        }
    }
    */

    private void OnSpawnZombies()
    {
        InstantiateObjectAtSpawnPoint();
    }

        /*
    public void InstantiateXobjectsAtTwoSpawnPoints()
    {
        for (int i = 0; i < _nombreDeZombies; i++)
        {
            InstantiateObjectAtTwoSpawnPoints();
        }
    }
    */

        /*
    public void InstantiateObjectAtTwoSpawnPoints()
    {
        //Instancier un zombie dans la sc�ne
        GameObject.Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
        GameObject.Instantiate(_prefab, _secondarySpawnPoint.position, _secondarySpawnPoint.rotation);
    }
    */

}
