using System;

[Serializable]
public class LevelData
{
    public LevelDataArray[]Data;
}

[Serializable]
public class LevelDataArray
{
    public int[] array;
}