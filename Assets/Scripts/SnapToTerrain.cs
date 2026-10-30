using UnityEngine;

public class SnapToTerrain : MonoBehaviour
{
    public float heightOffset = 0f;

    void Awake()
    {
        Terrain terrain = Terrain.activeTerrain;
        if (terrain == null)
        {
            return;
        }
        Vector3 pos = transform.position;
        pos.y = terrain.SampleHeight(pos) + terrain.transform.position.y + heightOffset;
        transform.position = pos;
    }
}