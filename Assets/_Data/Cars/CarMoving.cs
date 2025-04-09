using UnityEngine;

public class CarMoving : SaiBehaviour
{
    [SerializeField] protected InputManager inputManager;

    [Header("Vertical")]
    [SerializeField] protected float speed = 0f;
    [SerializeField] protected float speedMin = 0.5f;
    [SerializeField] protected float speedMax = 27f;
    [SerializeField] protected float speedUp = 0.2f;
    [SerializeField] protected float speedDown = 0.4f;

    [Header("Horizontal")]
    [SerializeField] protected float speedHorizontal = 0f;
    [SerializeField] protected float speedHorMin = 0.1f;
    [SerializeField] protected float speedHorMax = 5f;
    [SerializeField] protected float speedHorUp = 0.1f;
    [SerializeField] protected float speedHorDown = 0.4f;

    [Header("Road Info")]
    [SerializeField] protected float leftLimit = -3f;
    [SerializeField] protected float rightLimit = 3f;
    [SerializeField] protected float roadPumping = 0.1f;

    private void Update()
    {
        this.Moving();
    }

    private void FixedUpdate()
    {
        this.SpeedVerticalUp();
        this.SpeedHorizontalUp();
        this.KeepCarOnRoad();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInputManager();
    }

    protected virtual void LoadInputManager()
    {
        if (this.inputManager != null) return;
        this.inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        Debug.LogWarning(transform.name + ": LoadInputManager", gameObject);
    }

    protected virtual void Moving()
    {
        transform.parent.Translate(Vector3.up * this.speed * Time.deltaTime);

        float inputHorizontal = this.inputManager.InputHorizontal;
        transform.parent.Translate(Vector3.right * inputHorizontal * this.speedHorizontal * Time.deltaTime);
    }

    protected virtual void SpeedVerticalUp()
    {
        if (this.inputManager.GetInputVertical() > 0)
        {
            this.speed += this.speedUp;
        }

        if (this.inputManager.InputVertical < 1)
        {
            this.speed -= this.speedDown;
        }

        if (this.speed > this.speedMax) this.speed = speedMax;
        if (this.speed < this.speedMin) this.speed = this.speedMin;
    }

    protected virtual void SpeedHorizontalUp()
    {
        if (this.speed > 0)
        {
            this.speedHorizontal += this.speedHorUp;
        }

        if (this.speed < 10)
        {
            this.speedHorizontal -= this.speedHorDown;
        }

        if (this.speedHorizontal > this.speedHorMax) this.speedHorizontal = speedHorMax;
        if (this.speedHorizontal < this.speedHorMin) this.speedHorizontal = this.speedHorMin;
    }

    protected virtual void KeepCarOnRoad()
    {
        Vector3 carPosition = transform.parent.position;

        if (carPosition.x < this.leftLimit)
        {
            carPosition.x += this.roadPumping;
        }

        if (carPosition.x > this.rightLimit)
        {
            carPosition.x -= this.roadPumping;
        }

        transform.parent.position = carPosition;
    }
}
