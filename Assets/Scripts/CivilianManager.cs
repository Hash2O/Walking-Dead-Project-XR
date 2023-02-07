using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivilianManager : MonoBehaviour
{
    


    [SerializeField] private Transform _destination;

    [SerializeField] private GameObject _civilianRagdoll;

    [SerializeField] private List<AudioClip> _pochette;

    private Transform _player;

    private Transform _enemy;
    
    private NavMeshAgent _agent;
    
    private Animator _animator;

    private AudioSource _audioSource;

    [SerializeField] private GameObject[] _enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _player = GameObject.FindWithTag("Player").transform;
        // = GameObject.FindWithTag("Zombie").transform;
        _enemies = GameObject.FindGameObjectsWithTag("Player");
        _enemy = _enemies[0].transform;
    }

    // Update is called once per frame
    void Update()
    {

        float dist; //= Vector3.Distance(transform.position, _enemy.position);

        float disttozombie;
        
        float closestzombie = 100.0f;
        
        foreach (GameObject z in _enemies)
        {
            if (z)
            {
                disttozombie = Vector3.Distance(transform.position, z.transform.position);

                if (disttozombie < closestzombie)
                {
                    closestzombie = disttozombie;
                    _enemy.position = z.transform.position;
                }
            }

            
            
        }
        
        dist = closestzombie;
        
        
        if (dist < 5f) //si trop pres
        {
            print("Run Away");
            GoToDestination();
            ChangeAudioClip(1);
            _animator.SetBool("isRunning", true);
        }
        
        else if( dist < 4.0f)
        {
            print("Oh no, I must run ");
            ChangeAudioClip(2);
            _animator.SetBool("isRunning", false);
        }
        
        else
        {
            print("Ok, I feel safer here");
            ChangeAudioClip(0);
            Stopfleeing();
            _animator.SetBool("isRunning", false);
        }
        
        
        GererLAudio();


    }

    private void ChangeAudioClip(int index)
    {
        if(!_audioSource.isPlaying || _audioSource.clip == _pochette[0])
            _audioSource.clip = _pochette[index];
    }

    private void Stopfleeing()
    {
        _agent.isStopped = true;
    }

    private void GoToDestination()
    {
        _destination.position = transform.position + (transform.position - _enemy.position); // a l'opposé du joueur 
        _agent.isStopped = false;
        _agent.SetDestination(_destination.position);
    }

    private void GererLAudio()
    {
        int rand;
        rand = Random.Range(1, 5);
        if (rand == 2 && ! _audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}
