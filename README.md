# Ray-cast-cena

<h3>Integrantes: Guilherme Fonseca da Silva,Kevin Novais Bezerra</h3>

<h3>Série: 3º Ano Programação de Jogos Digitais</h3>
<br>
<h3>Explicação do Código</h3>
Criamos a classe "player", com atributos de Vector3  mover, Vector3 girar, e foram adicionados métodos de movimento e rotação, o GameObject do player é uma cápsula pega no próprio unity e deixamos ela transparente.

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


Criamos o scripty "Raycast" que com botão esquerdo do mouse lança um raio e se o GameObject atingido tiver a tag sapo ele será destruido.

using UnityEngine;

public class DestruirComClique : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Botão esquerdo do mouse
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o objeto clicado tem a tag "Sapo"
                if (hit.collider.CompareTag("Sapo"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}


Para representar a mira do jogador de forma minimalista, foi criado um Canvas no Unity contendo apenas um texto centralizado com um ponto ".". Esse ponto funciona como uma mira simples, posicionada no centro da tela para ajudar o jogador a mirar nos objetos do jogo, como inimigos ou itens interativos.

O procedimento foi:

Criado um Canvas do tipo Screen Space - Overlay.

Adicionado um objeto de Texto (Text ou TextMeshPro) como filho do Canvas.

O texto foi posicionado no centro da tela com alinhamento central.

O conteúdo do texto é apenas um ".", funcionando como uma mira discreta.

A cor, tamanho e fonte do ponto foram ajustados para garantir boa visibilidade.

<h3>Prefabs Utilizados:</h3>

https://sketchfab.com/3d-models/woods-and-mountains-16b25ba0bfc94bb1862dc52f3964f99f

https://sketchfab.com/3d-models/tiny-frog-c25c8980b93a460aa521ae62d3d94e0e

<h3>Função</h3>

Guilherme:

Kevin:
