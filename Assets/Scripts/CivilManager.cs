using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivilManager : MonoBehaviour
{
    private NavMeshAgent _citizenAgent;

    //[SerializeField] private Transform _destination;

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _zombie;
    [SerializeField] private Transform _nearestExit;
    [SerializeField] private AudioSource _citizenAudioSource;
    [SerializeField] private List<AudioClip> _citizenPochette;

    private Animator _animatorCitizen;

    // Start is called before the first frame update
    void Start()
    {
        _citizenAgent = GetComponent<NavMeshAgent>();
        _citizenAudioSource = GetComponent<AudioSource>();
        _nearestExit = GameObject.Find("Nearest Exit").transform;
        _player = GameObject.FindWithTag("Player").transform;
        _zombie = GameObject.FindWithTag("Zombie").transform;
        _animatorCitizen = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        keepYourDistance();
        callForHelp();
        //GoToDestination();
       
    }

    private void GoToDestination()
    {
        Debug.Log(_citizenAgent.velocity.magnitude);    //Afficher la vitesse de l'agent
        _nearestExit.position = transform.position + (transform.position - _player.position);
        _citizenAgent.isStopped = false;
        _citizenAgent.SetDestination(_nearestExit.position);
    }

    void keepYourDistance()
    {
        var safeDist = Vector3.Distance(transform.position, _player.position);
        var riskyDist = Vector3.Distance(transform.position, _zombie.position);

        //Si le player s'approche trop
        if (safeDist < 25.0f)
        {
            //Pour que le civil court vers le joueur quand celui-ci arrive à une certaine distance de lui
            //_citizenAgent.SetDestination(_player.position);

            //Ici, le civil court vers la plus proche sortie
            _citizenAgent.SetDestination(_nearestExit.position);
            _animatorCitizen.SetBool("isRunning", true);
            _citizenAudioSource.clip = _citizenPochette[1];
            StopFleeing();
        }
        else
        {
           // _animatorCitizen.SetBool("isRunning", false);
            _animatorCitizen.SetBool("isIdle", true);
            _citizenAudioSource.clip = _citizenPochette[0];

        }

        //Si le zombie s'approche trop
        if (riskyDist < 25.0f)
        {

            //_citizenAgent.SetDestination(_player.position);

            _citizenAgent.isStopped = false;
            _citizenAgent.SetDestination(_nearestExit.position);
            _animatorCitizen.SetBool("isRunning", true);
            _citizenAudioSource.clip = _citizenPochette[1];
        }
        else
        {
            _animatorCitizen.SetBool("isIdle", true);
            _citizenAudioSource.clip = _citizenPochette[0];     //Monologue
            StopFleeing();
        }


    }

    void callForHelp()
    {
        var safeDist = Vector3.Distance(transform.position, _player.position);
        if (safeDist < 35.0f)
        {
     
            //_citizenAudioSource.PlayDelayed(0.1f);
            if (!_citizenAudioSource.isPlaying)
            {
                int aleatoire = Random.Range(1, 100);

                if (aleatoire > 90)
                {
                    Debug.Log("HELP !");
                    _citizenAudioSource.Play(); //ici, le cri
                }
            }
        }
    }

    private void StopFleeing()
    {
        _citizenAgent.isStopped = true;
    }

    private void ChangeAudioClip(int index)
    {
        //Si aucun audioclip n'est joué, ou si c'est le monologue, on interrompt pour activer celui qu'on a choisi
        if(!_citizenAudioSource.isPlaying || _citizenAudioSource.clip == _citizenPochette[0])
        {
            _citizenAudioSource.clip = _citizenPochette[index];
        }
    }
}
