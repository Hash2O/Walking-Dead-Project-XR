using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    [SerializeField] private Transform _torchHoldPoint;

    [SerializeField] private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /**********************************************
             * 
             * Mecanique de base
             * 
             *********************************************/

            _audioSource.Play();

            //Position et rotation
            transform.position = _torchHoldPoint.position;
            transform.rotation = _torchHoldPoint.rotation;
            //Attacher l'objet au player
            transform.parent = _torchHoldPoint;

            /*******************************
            transform.parent = other.transform.GetChild(0);
            transform.position = other.transform.GetChild(1).position;
            transform.rotation = other.transform.GetChild(0).rotation;

            *******************************/

        }
    }
}
