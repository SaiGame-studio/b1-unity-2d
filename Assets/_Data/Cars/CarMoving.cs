using UnityEngine;

public class CarMoving : MonoBehaviour
{
    [SerializeField] protected float speed = 0f;
    [SerializeField] protected float speedMax = 27f;
    [SerializeField] protected float speedUp = 0.5f;

    private void Update()
    {
        this.Moving();
    }

    private void FixedUpdate()
    {
        //this.SpeedUp();
    }

    protected virtual void Moving()
    {
        transform.parent.Translate(Vector3.up * this.speed * Time.deltaTime);
    }

    protected virtual void SpeedUp()
    {
        this.speed += this.speedUp;
        if (this.speed > this.speedMax) this.speed = speedMax;
    }
}
