using System;
using UnityEngine;

public class ValveScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;

    [Header("Variables")]
    [SerializeField] private float InteractionDist;
    [SerializeField] private bool isOpened = false;

    public event EventHandler OnOpenValve;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var interactionManager = InteractionManager.instance;
        interactionManager.OnInteract += InteractionManager_OnInteract;
    }

    private void InteractionManager_OnInteract(object sender, System.EventArgs e)
    {
        if (!isOpened)
        {
            OpenValve();
        }
        else
        {
            return;
        }
    }

    private void OpenValve()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, InteractionDist);
        if(hit.collider == null) 
        {
            return; 
        }
        if (hit.collider.CompareTag("Player"))
        {
            OnOpenValve?.Invoke(this, EventArgs.Empty);
        }
    }
}
