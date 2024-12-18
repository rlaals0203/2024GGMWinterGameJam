using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // �����̴� UI ���

    private string AllName = "All";

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat(AllName);
        volumeSlider.value = volume;
        SetVolume(volume);
        // �����̴� �� ����� ȣ��� �̺�Ʈ ���
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // ��ü ���� ���� �Լ�
    private void SetVolume(float volume)
    {
        AudioListener.volume = volume; // AudioListener�� volume ���� ����
        PlayerPrefs.SetFloat(AllName, volume);
    }
}