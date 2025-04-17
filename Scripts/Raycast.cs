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


