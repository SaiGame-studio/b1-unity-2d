using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] protected RoadManager roadManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger: "+ other.name);
        this.roadManager.CreateRoad();
    }
}
