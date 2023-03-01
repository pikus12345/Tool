using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public List<Tool> tools;
    public int selectedTool;
    public SpriteRenderer toolRenderer;
    private GameManager gameManager;
    private void Start()
    {
        RefreshTool();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if(GameManager.IsGameRunning)
            CheckKeySelectTool();
    }
    public void CheckKeySelectTool()
    {
        if (Input.GetKeyDown("1"))
            SelectTool(0);
        if (Input.GetKeyDown("2"))
            SelectTool(1);
        if (Input.GetKeyDown("3"))
            SelectTool(2);
        if (Input.GetKeyDown("4"))
            SelectTool(3);
        if (Input.GetKeyDown("5"))
            SelectTool(4);
    }

    public void RefreshTool()
    {
        toolRenderer.sprite = tools[selectedTool].toolSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb != null)
        {
            if (rb.CompareTag("Obstacle"))
            {
                if (rb.GetComponent<Obstacle>().toolToDestroy == tools[selectedTool])
                {
                    rb.GetComponent<Obstacle>().DestroyObstacle();
                    gameManager.AddScore();

                }
                else
                {
                    gameManager.StopGame();
                }
            }
            
        }
    }
    public void SelectTool(int toolIndex)
    {
        selectedTool = toolIndex;
        RefreshTool();
    }
}
