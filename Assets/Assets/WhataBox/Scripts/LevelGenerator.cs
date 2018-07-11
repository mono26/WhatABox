using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [System.Serializable]
    public class SpawningObject
    {
        public SpawnableObject objectToSpawn;
        public int numberOfSpawns;
    }

    [Header("Level Generator settings")]
    [SerializeField]
    protected float heightBounds = 30;
    [SerializeField]
    protected int maxSpawnTries = 10;
    [SerializeField]
    protected float maxSpaceBetweenObstacle = 1;
    [SerializeField]
    protected float minSpaceBetweenObstacle = 1;
    [SerializeField]
    protected float minSpaceBetweenPickable = 0.5f;
    [SerializeField]
    protected SpawningObject[] obstaclesToSpawn;
    [SerializeField]
    protected SpawningObject[] pickablesToSpawn;
    [SerializeField]
    protected float widthBounds = 8;

    protected RaycastHit2D freeSpotHit;

    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(widthBounds, heightBounds));

        return;
    }

    void Start ()
    {
        SpawnObstacles();
        SpawnPickables();

        return;
	}

    protected void SpawnObstacles()
    {
        if(obstaclesToSpawn.Length == 0){ return; }

        foreach (SpawningObject obj in obstaclesToSpawn)
        {
            for(int i = 0; i < obj.numberOfSpawns; i++)
            {
                Vector2 objSize = CalculateObjectToSpawnSize(obj.objectToSpawn);

                for (int j = 0; j < maxSpawnTries; j++)
                {
                    Vector2 position = CalculateRandomPosition();

                    freeSpotHit = Physics2D.BoxCast(position, objSize, 0, Vector2.zero, 0);
                    //DebugExtension.DebugBounds(new Bounds(position, objSize), Color.red, 10);
                    if (freeSpotHit.collider == null)
                    {
                        SpawnObject(obj.objectToSpawn, position);
                        break;
                    }
                }
            }
        }

        return;
    }

    protected void SpawnPickables()
    {
        if (pickablesToSpawn.Length == 0) { return; }

        foreach (SpawningObject obj in pickablesToSpawn)
        {
            for (int i = 0; i < obj.numberOfSpawns; i++)
            {
                Vector2 objSize = CalculateObjectToSpawnSize(obj.objectToSpawn);

                for (int j = 0; j < maxSpawnTries; j++)
                {
                    Vector2 position = CalculateRandomPosition();

                    freeSpotHit = Physics2D.BoxCast(position, objSize, 0, Vector2.zero, 0);
                    //DebugExtension.DebugBounds(new Bounds(position, objSize), Color.red, 10);
                    if (freeSpotHit.collider == null)
                    {
                        SpawnObject(obj.objectToSpawn, position);
                        break;
                    }
                }
            }
        }

        return;
    }

    protected void SpawnObject(SpawnableObject _objectToSpawn, Vector2 _position)
    {
        SpawnableObject obj = Instantiate(_objectToSpawn, _position, Quaternion.identity);
        obj.transform.SetParent(transform);

        return;
    }

    protected Vector2 CalculateObjectToSpawnSize(SpawnableObject _objectToSpawn)
    {
        return new Vector2(
                        _objectToSpawn.Width + Random.Range(minSpaceBetweenObstacle, maxSpaceBetweenObstacle) * 2,
                        _objectToSpawn.Height + Random.Range(minSpaceBetweenObstacle, maxSpaceBetweenObstacle) * 2
                        );
    }

    protected Vector2 CalculateRandomPosition()
    {
        float x = Random.Range(
            transform.position.x - widthBounds / 2,
            transform.position.x + widthBounds / 2
            );
        float y = Random.Range(
            transform.position.y - heightBounds / 2,
            transform.position.y + heightBounds / 2
            );

        return new Vector2(x, y);
    }
}
