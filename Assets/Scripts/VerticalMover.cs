using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    public float height = 3f;
    public float speed = 2f;

    private Vector3 startPos;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
    }

    void FixedUpdate()
    {
        float yOffset = Mathf.PingPong(Time.time * speed, height);
        Vector3 targetPos = startPos + Vector3.up * yOffset;

        rb.MovePosition(targetPos);
    }
}
