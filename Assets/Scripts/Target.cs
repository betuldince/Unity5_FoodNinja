using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private float minSpeed=12;
    private float maxSpeed=16;

    private float maxTorque=10;
    private float xRange=4;

    private float ySpawnPos=-2;

    public int pointValue;
    public ParticleSystem explosion;

    Rigidbody rb;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame

    Vector3 RandomForce()
    {
        return Random.Range(minSpeed, maxSpeed) * Vector3.up;
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    private void OnMouseDown()
    {
        if (gameManager.isActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameManager.UpdateScore(pointValue);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    void Update()
    {
        
    }
}
