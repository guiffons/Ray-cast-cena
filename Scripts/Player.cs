using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    [Header("Movimentação")]
    public float velocidade = 5f;

    [Header("Mouse")]
    public float sensibilidade = 100f;
    public Transform cameraJogador;

    private float rotacaoVertical = 0f;
    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Rotação com o mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;

        rotacaoVertical -= mouseY;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -90f, 90f);

        cameraJogador.localRotation = Quaternion.Euler(rotacaoVertical, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); // Gira o Player (horizontal)

        // Movimento com teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direcao = transform.right * horizontal + transform.forward * vertical;
        Vector3 movimento = direcao * velocidade * Time.deltaTime;

        rb.MovePosition(rb.position + movimento);
    }
}
