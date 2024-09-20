using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    // Lista de câmeras
    public List<Camera> cameras;

    // Lista de Raw Images para exibir o feed das câmeras
    public List<RawImage> rawImages;

    // Índice da câmera inicial que estará ativa no começo
    public int defaultCameraIndex = 0;

    private GoldenEnemy ge;

    void Start()
    {
        ge = FindObjectOfType<GoldenEnemy>();
        // Verifica se a quantidade de câmeras e rawImages são iguais
        if (cameras.Count != rawImages.Count)
        {
            Debug.LogError("O número de câmeras e RawImages não são iguais!");
            return;
        }

        // Ativa a câmera padrão no início do jogo
        InitializeDefaultCamera();
    }

    // Método público para ativar uma câmera específica, chamável pelo botão
    public void SelectCamera(int cameraIndex)
    {
        if(cameraIndex == ge.NumCamPanfleto)
        {
            ge.StartTry();
        }
        // Desativa todas as câmeras antes de ativar a nova
        DisableAllCameras();

        // Verifica se o índice está dentro do intervalo da lista
        if (cameraIndex >= 0 && cameraIndex < cameras.Count)
        {
            // Ativa a câmera correspondente e seu RawImage
            cameras[cameraIndex].gameObject.SetActive(true);
            rawImages[cameraIndex].enabled = true;

            // Atualiza a textura da RawImage com o feed da câmera
            rawImages[cameraIndex].texture = cameras[cameraIndex].targetTexture;
        }
        else
        {
            Debug.LogError("Índice de câmera fora do intervalo!");
        }
    }

    // Método para desativar todas as câmeras e RawImages
    private void DisableAllCameras()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(false);
            rawImages[i].enabled = false;
        }
    }

    // Ativa a câmera padrão no início
    private void InitializeDefaultCamera()
    {
        // Desativa todas as câmeras
        DisableAllCameras();

        // Ativa a câmera padrão e o RawImage correspondente
        if (defaultCameraIndex >= 0 && defaultCameraIndex < cameras.Count)
        {
            cameras[defaultCameraIndex].gameObject.SetActive(true);
            rawImages[defaultCameraIndex].enabled = true;
            rawImages[defaultCameraIndex].texture = cameras[defaultCameraIndex].targetTexture;
        }
        else
        {
            Debug.LogError("Índice da câmera padrão fora do intervalo!");
        }
    }
}
