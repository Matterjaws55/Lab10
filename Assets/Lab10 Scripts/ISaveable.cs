using UnityEngine;

public interface ISaveable
{
    SaveData Save();
    void Load(SaveData data);
}
