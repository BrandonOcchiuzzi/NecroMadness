using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed;

    public GameObject player;

    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        initialPosition = player.transform.position;

        Debug.Log (initialPosition);
    }

    void Update()
    {
        transform.position =
            Vector2
                .MoveTowards(transform.position,
                initialPosition,
                speed * Time.deltaTime);

        float distance =
            Vector2.Distance(initialPosition, this.transform.position);

        Debug.Log("distance " + distance);
        if (distance < 0.01)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMover>().TakeDamage(2);
        }
        else if (other.gameObject.tag == "enemy")
        {
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
