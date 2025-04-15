# Ray-cast-cena

<h3>Integrantes: Guilherme Fonseca da Silva,Kevin Novais Bezerra</h3>

<h3>Série: 3º Ano Programação de Jogos Digitais</h3>
<br>
<h3>Explicação do Código</h3>
Criamos a classe "player", com atributos de Vector3  mover, Vector3 girar, e foram adicionados métodos de movimento e rotação, o GameObject do player é uma cápsula pega no próprio unity e deixamos ela transparente.


A Câmera é filha do GameObject player, criamos o scripty "Raycast" que com botão esquerdo do mouse lança um raio e se o GameObject atingido tiver a tag sapo ele será destruido.


Para representar a mira do jogador de forma minimalista, foi criado um Canvas no Unity contendo apenas um texto centralizado com um ponto ".". Esse ponto funciona como uma mira simples, posicionada no centro da tela para ajudar o jogador a mirar nos objetos do jogo, como inimigos ou itens interativos.

O procedimento foi:

Criado um Canvas do tipo Screen Space - Overlay.

Adicionado um objeto de Texto (Text ou TextMeshPro) como filho do Canvas.

O texto foi posicionado no centro da tela com alinhamento central.

O conteúdo do texto é apenas um ".", funcionando como uma mira discreta.

A cor, tamanho e fonte do ponto foram ajustados para garantir boa visibilidade.

<h3>Função</h3>

Guilherme:

Kevin:
