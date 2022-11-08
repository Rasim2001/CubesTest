using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoaderService
{
    public PrefabsData Prefabs;

    public ResourceLoaderService()
    {
        Prefabs = Resources.Load<PrefabsData>("ScriptableObjects/PrefabsData");
    }
}
