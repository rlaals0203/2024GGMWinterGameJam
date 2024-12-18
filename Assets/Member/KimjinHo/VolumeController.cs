using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // �����̴� UI ���

    private void Start()
    {
        // �����̴� �� ����� ȣ��� �̺�Ʈ ���
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // ��ü ���� ���� �Լ�
    private void SetVolume(float volume)
    {
        AudioListener.volume = volume; // AudioListener�� volume ���� ����
    }
}