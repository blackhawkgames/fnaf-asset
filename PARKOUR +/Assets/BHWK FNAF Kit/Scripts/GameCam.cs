using UnityEngine;

public class GameCam : MonoBehaviour
{
    public float rotationSpeed = 50f;  // Velocidade de rotação
    public float maxHorizontalAngle = 40f; // Ângulo máximo horizontal que a câmera pode rotacionar
    public float minHorizontalAngle = 140f;
    public float edgeThreshold = 50f;

    private float currentXRotation = 0f;
    private float currentYRotation = 180f;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        // Movimento horizontal (direita/esquerda) quando o mouse está nas laterais da tela
        if (mousePosition.x <= edgeThreshold)
        {
            currentYRotation -= rotationSpeed * Time.deltaTime;
        }
        else if (mousePosition.x >= Screen.width - edgeThreshold)
        {
            currentYRotation += rotationSpeed * Time.deltaTime;
        }

        // Limitar os ângulos de rotação
        currentYRotation = Mathf.Clamp(currentYRotation, minHorizontalAngle, maxHorizontalAngle);

        // Aplica a rotação na câmera
        transform.localRotation = Quaternion.Euler(currentXRotation, currentYRotation, 0f);
    }
}