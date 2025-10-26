using UnityEngine;

public interface ITargetBuilder
{
    void SetSpeed();
    void SetSize();
    void SetPoints();
    Target GetResult();
}