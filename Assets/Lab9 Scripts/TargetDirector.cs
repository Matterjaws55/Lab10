using UnityEngine;

public class TargetDirector
{
    private ITargetBuilder builder;

    public TargetDirector(ITargetBuilder builder)
    {
        this.builder = builder;
    }

    public Target Construct()
    {
        builder.SetSpeed();
        builder.SetSize();
        builder.SetPoints();
        return builder.GetResult();
    }
}