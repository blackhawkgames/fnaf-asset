using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    // Lista de c�meras
    public List<Camera> cameras;

    // Lista de Raw Images para exibir o feed das c�meras
    public List<RawImage> rawImages;

    // �ndice da c�mera inicial que estar� ativa no come�o
    public int defaultCameraIndex = 0;

    private GoldenEnemy ge;

    void Start()
    {
        ge = FindObjectOfType<GoldenEnemy>();
        // Verifica se a quantidade de c�meras e rawImages s�o iguais
        if (cameras.Count != rawImages.Count)
        {
            Debug.LogError("O n�mero de c�meras e RawImages n�o s�o iguais!");
            return;
        }

        // Ativa a c�mera padr�o no in�cio do jogo
        InitializeDefaultCamera();
    }

    // M�todo p�blico para ativar uma c�mera espec�fica, cham�vel pelo bot�o
    public void SelectCamera(int cameraIndex)
    {
        if(cameraIndex == ge.NumCamPanfleto)
        {
            ge.StartTry();
        }
        // Desativa todas as c�meras antes de ativar a nova
        DisableAllCameras();

        // Verifica se o �ndice est� dentro do intervalo da lista
        if (cameraIndex >= 0 && cameraIndex < cameras.Count)
        {
            // Ativa a c�mera correspondente e seu RawImage
            cameras[cameraIndex].gameObject.SetActive(true);
            rawImages[cameraIndex].enabled = true;

            // Atualiza a textura da RawImage com o feed da c�mera
            rawImages[cameraIndex].texture = cameras[cameraIndex].targetTexture;
        }
        else
        {
            Debug.LogError("�ndice de c�mera fora do intervalo!");
        }
    }

    // M�todo para desativar todas as c�meras e RawImages
    private void DisableAllCameras()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(false);
            rawImages[i].enabled = false;
        }
    }

    // Ativa a c�mera padr�o no in�cio
    private void InitializeDefaultCamera()
    {
        // Desativa todas as c�meras
        DisableAllCameras();

        // Ativa a c�mera padr�o e o RawImage correspondente
        if (defaultCameraIndex >= 0 && defaultCameraIndex < cameras.Count)
        {
            cameras[defaultCameraIndex].gameObject.SetActive(true);
            rawImages[defaultCameraIndex].enabled = true;
            rawImages[defaultCameraIndex].texture = cameras[defaultCameraIndex].targetTexture;
        }
        else
        {
            Debug.LogError("�ndice da c�mera padr�o fora do intervalo!");
        }
    }
}
