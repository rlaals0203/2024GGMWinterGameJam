using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // �����̴� UI ���

    void Start()
    {
        // �����̴� �� ����� ȣ��� �̺�Ʈ ���
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // ��ü ���� ���� �Լ�
    void SetVolume(float volume)
    {
        AudioListener.volume = volume; // AudioListener�� volume ���� ����
    }
}