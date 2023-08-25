using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float minSpeed = 10;
    public float maxSpeed = 14;
    public float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -1;
    private float zSpawnPos = 0;

    public int pointValue;
    public ParticleSystem explosioParticle;

    private GameManager manager;

    private Rigidbody targetRb;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, zSpawnPos);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        if (!manager.gameOver)
        {
            Instantiate(explosioParticle, transform.position, explosioParticle.transform.rotation);

            if (gameObject.CompareTag("Good"))
            {
                manager.UpdateScore(pointValue);
            }
            else if (gameObject.CompareTag("Bad"))
            {
                manager.UpdateScore(pointValue);
            }

            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            manager.GameOver();
        }
        Destroy(gameObject);   
    }
}
