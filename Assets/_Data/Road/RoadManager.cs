using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] protected float roadOffset = 26;
    [SerializeField] protected Transform currentRoad;

    public void CreateRoad()
    {
        Vector3 pos = this.currentRoad.position;
        pos.y += this.roadOffset;
        Transform newRoad = Instantiate(this.currentRoad, pos, Quaternion.identity);
        this.currentRoad = newRoad;
    }
}
