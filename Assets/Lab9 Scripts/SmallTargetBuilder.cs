using UnityEngine;

public class SmallTargetBuilder : ITargetBuilder
{
    private Target target;
    private Target prefab;

    public SmallTargetBuilder(Target prefab)
    {
        this.prefab = prefab;
        target = Object.Instantiate(prefab);
    }

    public void SetSpeed() { target.speed = 2f; }
    public void SetSize() { target.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); }
    public void SetPoints() { target.pointValue = 10; }
    public Target GetResult() { return target; }
}