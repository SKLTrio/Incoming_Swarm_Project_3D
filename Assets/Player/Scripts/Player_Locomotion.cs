using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player_Locomotion : MonoBehaviour
{
    public Rigidbody Player_Rigid_Body;
    public GameObject Camera_Container;

    public float Speed;
    public float Sprint_Speed;
    public float Jump_Height;
    public float Mouse_Sensitivity;
    public float Gravity;
    public float Max_Force;

    private float Look_Rotation;

    private Vector2 Move_Direction = Vector3.zero;
    private Vector2 Look_Direction = Vector3.zero;

    public bool Is_Grounded;
    private bool Is_Sprinting;

    public void On_Move(InputAction.CallbackContext Context)
    {
        Move_Direction = Context.ReadValue<Vector2>();
    }

    public void On_Look(InputAction.CallbackContext Context)
    {
        Look_Direction = Context.ReadValue<Vector2>();
    }

    public void On_Jump(InputAction.CallbackContext Context)
    {
        Jump();
    }

    public void On_Sprint(InputAction.CallbackContext Context)
    {
        Is_Sprinting = Context.ReadValueAsButton();
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Move();
        Apply_Gravity();
    }

    private void LateUpdate()
    {
        Look();
    }

    private void Move()
    {
        Vector3 Current_Velocity = Player_Rigid_Body.velocity;
        Vector3 Target_Velocity = new Vector3(Move_Direction.x, 0, Move_Direction.y);

        if (Is_Sprinting)
        {
            Target_Velocity *= Sprint_Speed;
        }

        else
        {
            Target_Velocity *= Speed;
        }

        Target_Velocity = transform.TransformDirection(Target_Velocity);

        Vector3 Velocity_Change = (Target_Velocity - Current_Velocity);
        Velocity_Change = new Vector3(Velocity_Change.x, 0, Velocity_Change.z);

        Vector3.ClampMagnitude(Velocity_Change, Max_Force);

        Player_Rigid_Body.AddForce(Velocity_Change, ForceMode.VelocityChange);
    }

    public void Look()
    {
        transform.Rotate(Vector3.up * Look_Direction.x * Mouse_Sensitivity);

        Look_Rotation += (-Look_Direction.y * Mouse_Sensitivity);

        Look_Rotation = Mathf.Clamp(Look_Rotation, -80, 80);

        Camera_Container.transform.eulerAngles = new Vector3(Look_Rotation, Camera_Container.transform.eulerAngles.y, Camera_Container.transform.eulerAngles.z);
    }

    public void Jump()
    {
        if (Is_Grounded)
        {
            Player_Rigid_Body.AddForce(Vector3.up * (Jump_Height + Mathf.Sqrt(Gravity * 2f)), ForceMode.VelocityChange);
            Is_Grounded = false;
        }
    }

    public void Grounded(bool Grounded_State)
    {
        Is_Grounded = Grounded_State;
    }

    private void Apply_Gravity()
    {
        if (!Is_Grounded)
        {
            Player_Rigid_Body.AddForce(Vector3.down * Gravity, ForceMode.Acceleration);
        }
    }
}