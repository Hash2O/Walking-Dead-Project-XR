using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSoundsManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

    [SerializeField] List<AudioClip> _audioClips;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource.clip = _audioClips[0];
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Car horning loud and furiously");
            _audioSource.PlayOneShot(_audioClips[1]);        }
        }

}
