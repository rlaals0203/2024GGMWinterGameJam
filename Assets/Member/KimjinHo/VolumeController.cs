using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // 슬라이더 UI 요소

    void Start()
    {
        // 슬라이더 값 변경시 호출될 이벤트 등록
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // 전체 음량 조절 함수
    void SetVolume(float volume)
    {
        AudioListener.volume = volume; // AudioListener의 volume 값을 변경
    }
}