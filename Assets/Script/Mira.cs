using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public Camera mainCamera;

    private void Update()
    {
        Vector3 centroTela = new Vector3(0.5f, 0.5f, 0f); // Centro da tela em coordenadas normalizadas
        Ray raioCentral = mainCamera.ViewportPointToRay(centroTela);
        RaycastHit hitInfo;

        if (Physics.Raycast(raioCentral, out hitInfo))
        {
            transform.position = hitInfo.point;
        }
        else
        {
            // Define a posição padrão se o raio não atingir nada
            transform.position = mainCamera.transform.position + mainCamera.transform.forward * 10f;
        }
    }
}
