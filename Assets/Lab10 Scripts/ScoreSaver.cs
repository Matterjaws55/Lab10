using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ScoreSaver
{
    private static string binaryPath;

    static ScoreSaver()
    {
        binaryPath = Application.persistentDataPath + "/score.dat";
    }

    public static void SaveScore(int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(binaryPath, FileMode.Create))
        {
            formatter.Serialize(stream, score);
        }
    }

    public static int LoadScore()
    {
        if (File.Exists(binaryPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(binaryPath, FileMode.Open))
            {
                return (int)formatter.Deserialize(stream);
            }
        }
        return 0;
    }
}