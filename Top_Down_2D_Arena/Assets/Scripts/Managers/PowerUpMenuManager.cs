using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenuManager : MonoBehaviour
{
    [SerializeField] private Canvas powerUpsMenuCanvas;
    [SerializeField] private UiManager ui;
    [SerializeField] GameObject[] powerUpPanels;    

    private Vector2 leftPanelPosition = new Vector2(-588, 0);
    private Vector2 centerPanelPosition = new Vector2(0, -7.26251221f);
    private Vector2 rightPanelPosition = new Vector2(590, -7.26251221f);

    private PlayerController playerController;

    private List<GameObject> selectedObjects;

    private int selectedObjectsAmount = 3;
    private int currentExperience;
    private int experienceToUpgrade = 0;
    private int nextUpgrade = 600;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        selectedObjects = new List<GameObject>();

        for (int i = 0; i < selectedObjectsAmount; i++)
        {
            int randomIndex = Random.Range(0, powerUpPanels.Length);
            int attempts = 0;
            
            while (selectedObjects.Contains(powerUpPanels[randomIndex]))
            {
                randomIndex = Random.Range(0, powerUpPanels.Length);
                attempts++;
                if (attempts >= powerUpPanels.Length)
                {
                    return;
                }
            }
            selectedObjects.Add(powerUpPanels[randomIndex]);
        }
    }

    void Update()
    {
        currentExperience = ui.totalExperience;

        DisplayRandomPowerUps();
    }

    private void DisplayRandomPowerUps()
    {
        if (currentExperience >= experienceToUpgrade)
        {
            powerUpsMenuCanvas.enabled = true;

            playerController.enabled = false;

            GameObject leftPanel = Instantiate(selectedObjects[0], powerUpsMenuCanvas.transform);
            RectTransform leftPanelRectTransform = leftPanel.GetComponent<RectTransform>();
            leftPanelRectTransform.anchoredPosition = leftPanelPosition;

            GameObject centerPanel = Instantiate(selectedObjects[1], powerUpsMenuCanvas.transform);
            RectTransform centerPanelRectTransform = centerPanel.GetComponent<RectTransform>();
            centerPanelRectTransform.anchoredPosition = centerPanelPosition;

            GameObject rightPanel = Instantiate(selectedObjects[2], powerUpsMenuCanvas.transform);
            RectTransform rightPanelRectTransform = rightPanel.GetComponent<RectTransform>();
            rightPanelRectTransform.anchoredPosition = rightPanelPosition;

            Time.timeScale = 0;

            experienceToUpgrade += nextUpgrade;
        }
    }    
}
