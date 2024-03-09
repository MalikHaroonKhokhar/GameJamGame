using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnDelay = 2f;
    public Vector2 spawnAreaSize;
    public float moveSpeed = 1f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(2f); 

        while (true)
        {
           
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
            );

      
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            StartCoroutine(MoveObject(spawnedObject));

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator MoveObject(GameObject obj)
    {
        while (obj != null)
        {
            obj.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
