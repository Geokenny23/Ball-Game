using UnityEngine;

public class BlockMovement : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    private bool isFrozen;
    public Vector3 moveDirection = Vector3.right;
    public float speed = 5f;
    private Rigidbody rb;
    private int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        gameManager.OnGameOver += Freeze;
        gameManager.OnStageCleared += Freeze;
    }

    private void OnDisable()
    {
        gameManager.OnGameOver -= Freeze;
        gameManager.OnStageCleared -= Freeze;
    }

    void FixedUpdate()
{
    if (isFrozen) return;

    rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
}

private void OnCollisionEnter(Collision collision)
{
    Vector3 normal = collision.contacts[0].normal;
    moveDirection = Vector3.Reflect(moveDirection, normal);
}

private void Freeze()
{
    rb.constraints = RigidbodyConstraints.FreezeAll;
}


}
