using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs;
    [SerializeField] private float SpawnOffset = -10;
    [SerializeField] [Min(0)] private float maxSpawnDistance = 15;
    [SerializeField] [Min(0)] private float spawnStartTimer = 0.5f;
    [SerializeField] [Min(0)] private float spawnRate = 0.25f;
    [SerializeField] [Min(0)] private float launchForce = 150;
    [SerializeField] private float horizontalForce = -5;
    [SerializeField] [Range(0, 10)] private float timeFruitForDestroy = 5;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFruit), spawnStartTimer, spawnRate);
    }

    private void SpawnFruit()
    {
        var prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

        Vector2 vec2D = Random.insideUnitCircle;
        GameObject fruit = Instantiate(prefab, transform.position + SpawnOffset*Vector3.up + maxSpawnDistance*new Vector3(vec2D.x,0,vec2D.y), Random.rotation, transform);

        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        rb.AddForce(launchForce*Vector3.up*Random.Range(0.8f, 1.2f) + horizontalForce*new Vector3(vec2D.x,0,vec2D.y), ForceMode.Impulse);

        Destroy(fruit, timeFruitForDestroy);
    }
    
}
