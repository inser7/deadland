using UnityEngine;
using System.Collections;

public class HeroControllerScript : MonoBehaviour
{

    //переменная для установки макс. скорости персонажаssss
    public float maxSpeed = 10.0f;
    public float turnAngle = 1.0f;
    public float currentZRotation = 0.0f;
    //направление движения
    public Vector2 forward = new Vector2(0.0f, 0.0f);
    //переменная для определения направления персонажа вправо/влево
    //ссылка на компонент анимаций
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    //	void Update()
    {
        //используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
        //при стандартных настройках проекта 
        //-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
        //1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
        var moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Mathf.Abs(moveDirection.y) > 0.5f)
        { //если двигаемся
            anim.SetFloat("Speed", Mathf.Abs(moveDirection.y));
            rigidbody2D.velocity = forward * maxSpeed * moveDirection.y;
        }
        else
            rigidbody2D.velocity = new Vector2(0.0f, 0.0f);


        if (!(Mathf.Abs(moveDirection.x) > 0.2f)) 
            return;

        if (currentZRotation > 359.0f) currentZRotation = 0.0f;
        if (currentZRotation < 0.0f) currentZRotation = 360.0f;
        var koef = 1;
        if (moveDirection.x < 0) koef = -1;
        currentZRotation -= turnAngle * koef;// moveDirection.x;
        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x));

        var newX = forward.x * Mathf.Cos( /*Mathf.Deg2Rad */ currentZRotation)//* Mathf.Rad2Deg 
                     - forward.y * Mathf.Sin( /*Mathf.Deg2Rad */ currentZRotation);//* Mathf.Rad2Deg;

        var newY = forward.x * Mathf.Sin( /*Mathf.Deg2Rad */ currentZRotation)//* Mathf.Rad2Deg 
                     + forward.y * Mathf.Cos( /*Mathf.Deg2Rad */ currentZRotation);//* Mathf.Rad2Deg;

        forward = new Vector2(newX, newY);// + new Vector2( transform.position.x,transform.position.y);
        forward.Normalize();
        Debug.Log("pos = " + transform.position);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentZRotation);
        //float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;// - transform.rotation.z;// - 90;
        //transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler( 0, 0, angleKoeff * targetAngle), maxSpeed * Time.deltaTime );
    }

}
