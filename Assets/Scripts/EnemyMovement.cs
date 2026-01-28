using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent navMeshAgent;
    private bool isFrozen;
    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        gameManager.OnGameOver += EnemyFreeze;
        gameManager.OnStageCleared += EnemyFreeze;
    }

    private void OnDisable()
    {
        gameManager.OnGameOver -= EnemyFreeze;
        gameManager.OnStageCleared -= EnemyFreeze;
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen) return;
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void EnemyFreeze()
    {
        isFrozen = true;

        if (navMeshAgent != null)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }
    }
}
