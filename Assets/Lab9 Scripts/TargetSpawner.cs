using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public Target targetPrefab; 
    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnTarget();
            timer = 0f;
        }
    }

    void SpawnTarget()
    {
        ITargetBuilder builder = new SmallTargetBuilder(targetPrefab);
        TargetDirector director = new TargetDirector(builder);
        Target target = director.Construct();

        target.transform.position = transform.position;
    }
}