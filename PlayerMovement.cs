using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        // Obtém o componente CharacterController do objeto
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verifica se o personagem está no chão
        if (controller.isGrounded)
        {
            // Movimento Horizontal (Esquerda/Direita)
            float moveHorizontal = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(moveHorizontal, 0, 0); // Use (moveHorizontal, 0, 0) para 2D, ou o desejado para 3D
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Pulo
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Aplica a gravidade ao longo do tempo
        moveDirection.y -= gravity * Time.deltaTime;

        // Move o personagem
        controller.Move(moveDirection * Time.deltaTime);
    }
}
