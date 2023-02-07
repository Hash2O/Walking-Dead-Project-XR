using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{
    private NavMeshAgent _agent;

    //[SerializeField] private Transform _destination;

    [SerializeField] private Transform _player;

    [SerializeField] private GameObject _ragdollPrefab;

    [SerializeField] private ParticleSystem _explosionParticle;

    [SerializeField] private List<AudioClip> _pochette;

    private Animator _animatorAnim;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _player = GameObject.FindWithTag("Player").transform;

        _animatorAnim = GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();

        //_agent.SetDestination(_player.position);

        //G�re le d�calage dans les animations des zombies
        _animatorAnim.SetFloat("offset", Random.Range(0.0f, 1.0f)); //G�n�ration al�atoire du d�calage (offset) pour chaque zombie

        //G�re la playlist des sons associ�s aux zombies
        _audioSource.clip = _pochette[Random.Range(0, _pochette.Count)];

    }

    // Update is called once per frame
    void Update()
    {
        
        var dist = Vector3.Distance(transform.position, _player.position);

            if (dist > 2.0f)
            {
                //Au del� de deux m�tres, le zombie marche vers lui
                _agent.SetDestination(_player.position);
                _animatorAnim.SetBool("isAttacking", false);
            }
            else
            {
                //_agent.isStopped = true;
                //Moins de deux m�tres, le zombie enclenche l'anim d'attaque
                _animatorAnim.SetBool("isAttacking", true);
            }

            //Penser au frameRate, environ 60 par secondes
            //Ici, on fait grogner les zombies de fa�on al�atoire
            if (!_audioSource.isPlaying)
            {
                int aleatoire = Random.Range(1, 100);

                if (aleatoire > 90)
                {
                    _audioSource.Play();
                }
            }

        }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Projectile"))
        {
            Debug.Log("Zombie hit !");
            //GetComponent<BoxCollider>().enabled = false;
            
            Instantiate(_ragdollPrefab, gameObject.transform.position, gameObject.transform.rotation);

            Instantiate(_explosionParticle, transform.position, transform.rotation);

            Destroy(gameObject);
        }


    }

}
