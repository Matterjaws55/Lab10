using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public PlayerData player;
    public List<TargetData> targets;
}

[Serializable]
public class PlayerData
{
    public float x, y, z;
    public int score;
}

[Serializable]
public class TargetData
{
    public float x, y, z;
}