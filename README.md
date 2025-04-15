
#  Ray Cast - Cena de Captura de Sapos no Unity

###  Integrantes  
- Guilherme Fonseca da Silva — Programação, lógica de jogo e implementação da mira (Canvas)  
- Kevin Novais Bezerra — Pesquisa e integração de prefabs, documentação

###  Série  
3º Ano — Programação de Jogos Digitais

---

##  Sobre o Projeto

Este projeto consiste em uma cena interativa desenvolvida no Unity, em primeira pessoa, onde o jogador utiliza a técnica de **Ray Cast** para capturar (destruir) sapos posicionados no cenário. A mecânica foi feita com scripts simples, mas que demonstram na prática a aplicação do Ray Cast em jogabilidade, além de movimentação de personagem e interface básica.

---

##  Como funciona

### Visão em Primeira Pessoa  
O jogador é representado por um **GameObject do tipo cápsula**, com um **material transparente** aplicado. Uma **Câmera** é filha desse objeto, criando o efeito de visualização em primeira pessoa.

#### Componentes da cápsula:
- Rigidbody  
- Capsule Collider  
- Script `MovimentacaoJogador`  
- Script `DestruirComClique`  

---

##  Script de Movimentação (`MovimentacaoJogador.cs`)

Este script controla o movimento e a rotação do jogador com teclado e mouse. A câmera é controlada pelo eixo vertical do mouse, enquanto o jogador gira no eixo horizontal.

```csharp
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
```

## Script de Ray Cast (DestruirComClique.cs)

Este script utiliza um raycast que parte da câmera (centro da tela) e, ao clicar com o botão esquerdo do mouse, verifica se colidiu com algum objeto com a tag "Sapo". Se sim, o objeto é destruído.

```csharp

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

```

---

## Mira com Canvas

Para representar uma mira simples, foi criado um Canvas do tipo Screen Space - Overlay contendo apenas um Text centralizado com um ponto final ".", funcionando como uma mira discreta.


![Print do canvas](https://github.com/user-attachments/assets/8f6c1e4f-7b94-4cd0-af9e-c6db33944b97)

Configurações:

- Alinhamento: centralizado

- Texto: "."

- Tamanho ajustado para boa visibilidade

- Cor: branca

- Objeto de texto posicionado no centro da tela


---

## Prefabs Utilizados

### Sapos

![Print do sapo](https://github.com/user-attachments/assets/b56a052a-797a-4f22-9694-a58d3ba63744)
- Os sapos foram posicionados manualmente no cenário como alvos para o jogador.
### Cenário

 ![Print do cenário](https://github.com/user-attachments/assets/3a32a011-2f71-49ae-b17f-aba9098e70ab)
- Um prefab de uma floresta simples para ser o cenário da cena.

### Links dos prefabs:

- https://sketchfab.com/3d-models/woods-and-mountains-16b25ba0bfc94bb1862dc52f3964f99f
- https://sketchfab.com/3d-models/tiny-frog-c25c8980b93a460aa521ae62d3d94e0e

  
---

## Componentes e Hierarquia

Jogador (Capsule)
├── Rigidbody
├── Capsule Collider
├── MovimentacaoJogador.cs
├── DestruirComClique.cs
└── Camera (filha da cápsula)

Canvas
└── Text (mira ".")


---

## Funções dos Integrantes

Guilherme Fonseca da Silva: Programação do jogador e raycast, implementação da mira com Canvas, organização geral da lógica de jogo.

Kevin Novais Bezerra: Pesquisa e organização dos prefabs, documentação do projeto.
