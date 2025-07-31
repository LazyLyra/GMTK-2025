using UnityEditor.Tilemaps;
using UnityEngine;

public class RatScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject target;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float RadiusOfVision = 4f;
    [SerializeField] bool Seen =false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Target");
    }
    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        if (direction.magnitude <= RadiusOfVision)
        {
            RaycastHit2D Hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
            if (Hit.collider == null)
            {
                Debug.Log("collider is null");
                return;
            }
            if(Hit.collider.gameObject == player)
            {
                Seen = true;
            }
        }
        if (Seen)
        {
            moveToTarget();
        }
    }

    void moveToTarget()
    {
        Vector3 moveDirection = target.transform.position - transform.position;
        transform.position += moveSpeed * moveDirection * Time.deltaTime;
    }
}
