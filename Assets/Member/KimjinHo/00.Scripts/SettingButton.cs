using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;

    [SerializeField] private List<GameObject> buttons;
    private GameObject currentHoveredButton = null;

    [SerializeField] private List<GameObject> _settingButton;
    private GameObject currentHoveredSettingButton = null;


    [SerializeField] private string _sceneName;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        OnMouse();
        OnExitMouse();
    }

    public void FadeOut1()
    {
        ChangeStartScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }



    public void ChangeStartScene()
    {
        DOTween.KillAll();
        if (_sceneName != null)
            SceneManager.LoadScene(_sceneName);
    }


    private void OnMouse()
    {
        GameObject hoveredButton = GetHoveredButton();

        if (hoveredButton != currentHoveredButton)
        {
            currentHoveredButton = hoveredButton;

            foreach (GameObject button in buttons)
            {
                if (button == null) continue;

                if (button == currentHoveredButton)
                    button.transform.DOScale(1.5f, 0.3f);
                else
                    button.transform.DOScale(0.8f, 0.3f);
            }
        }

        if (currentHoveredButton == null)
        {
            foreach (GameObject button in buttons)
            {
                if (button == null) continue;
                button.transform.DOScale(1f, 0.3f);
            }
        }
    }

    private void OnExitMouse()
    {
        GameObject hoveredButton = GetHoveredExitButton();

        if (hoveredButton != currentHoveredSettingButton)
        {
            currentHoveredSettingButton = hoveredButton;

            foreach (GameObject button in _settingButton)
            {
                if (button == null) continue;

                if (button == currentHoveredSettingButton)
                    button.transform.DOScale(1.5f, 0.3f);
            }
        }

        if (currentHoveredSettingButton == null)
        {
            foreach (GameObject button in _settingButton)
            {
                if (button == null) continue;
                button.transform.DOScale(1f, 0.3f);
            }
        }
    }

    private GameObject GetHoveredExitButton()
    {
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
            foreach (GameObject button in _settingButton)
                if (result.gameObject == button)
                    return button;
        return null;
    }

    private GameObject GetHoveredButton()
    {
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
            foreach (GameObject button in buttons)
                if (result.gameObject == button)
                    return button;
        return null;
    }
}