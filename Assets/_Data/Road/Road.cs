using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] protected Car car;
    [SerializeField] protected float carDistance;
    [SerializeField] protected float limitDistance = 50;

    protected void Update()
    {
        this.CheckCarPosition();
    }

    protected void CheckCarPosition()
    {
        this.carDistance = Vector3.Distance(transform.position, this.car.transform.position);
        if (this.carDistance > this.limitDistance) Destroy(gameObject);
    }
}
