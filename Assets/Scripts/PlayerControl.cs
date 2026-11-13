using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //Liikkuminen/nopeus (voidaan editoida Inspectorissa)
    public float speed = 5.0f;
    public float turnSpeed;

    //Näppäimet liikkumiseen (voidaan editoida Inspectorissa)
    public InputAction moveAction;

    //tämänhetkinen syötteen arvo(x=oikea/vasen, y=eteen/taakse), yksityiseksi sisäistä käyttöä varten
    private Vector2 moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Ota MoveAction käyttöön, jotta näppäimet toimivat
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //lue 2d vectoria MoveActioinsta (x:horizontal, y:vertical)
        moveInput = moveAction.ReadValue<Vector2>();

        //Liikuta autoa eteenpäin
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        //Käännä autoa sivuttain
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
    }
}
