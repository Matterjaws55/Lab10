using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed;
    public int pointValue;
    public Vector3 size;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    public void Hit()
    {
        ScoreManager.Instance.UpdateScore(pointValue);
        Destroy(gameObject);
    }

    public SaveData Save()
    {
        SaveData data = new SaveData();
        data.targets = new List<TargetData>();
        data.targets.Add(new TargetData
        {
            x = transform.position.x,
            y = transform.position.y,
            z = transform.position.z
        });
        return data;
    }
}