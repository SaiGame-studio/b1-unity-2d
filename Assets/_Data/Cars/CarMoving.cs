using UnityEngine;

public class CarMoving : MonoBehaviour
{
    [SerializeField] protected InputManager inputManager;
    [SerializeField] protected float speed = 0f;
    [SerializeField] protected float speedMin = 0.5f;
    [SerializeField] protected float speedMax = 27f;
    [SerializeField] protected float speedUp = 0.2f;
    [SerializeField] protected float speedDown = 0.4f;

    private void Update()
    {
        this.Moving();
    }

    private void FixedUpdate()
    {
        this.SpeedUp();
    }

    protected virtual void Moving()
    {
        transform.parent.Translate(Vector3.up * this.speed * Time.deltaTime);
    }

    protected virtual void SpeedUp()
    {
        if (this.inputManager.GetInputVertical() > 0)
        {
            this.speed += this.speedUp;
        }

        if(this.inputManager.InputVertical < 1)
        {
            this.speed -= this.speedDown;
        }

        if (this.speed > this.speedMax) this.speed = speedMax;
        if (this.speed < this.speedMin) this.speed = this.speedMin;
    }
}
