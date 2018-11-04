using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Sctipt/FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController _charController;
    public float speed = 6.0f;
    public float baseSpeed = 6.0f;
    public float gravity = -9.8f;

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void Start ()
    {
        _charController = GetComponent<CharacterController>();
    }
	
	void Update ()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
	}

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}
