using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;

    [SerializeField] private List<GameObject> buttons; // 여러 버튼들을 담을 리스트
    private GameObject currentHoveredButton = null;   // 현재 마우스가 오버된 버튼

    private void Update()
    {
        OnMouse();
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
                {
                    button.transform.DOScale(1.5f, 0.3f);
                }
                else
                {
                    button.transform.DOScale(0.8f, 0.3f);
                }
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


    private GameObject GetHoveredButton()
    {
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
        {
            foreach (GameObject button in buttons)
            {
                if (result.gameObject == button)
                    return button;
            }
        }
        return null;
    }
}
