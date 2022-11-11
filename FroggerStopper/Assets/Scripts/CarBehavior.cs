using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    private UserInput userInput;
    private bool snap;
    public bool awake;
    private Collider2D slot;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        userInput = FindObjectOfType<UserInput>();
        snap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!awake)
        {
            float desiredScale = .5f;
            sprite.color = new Color(1f, 0f, 0f, .5f);
            transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
        }
        else
        {
            sprite.color = new Color(1f, 0f, 0f, 1f);
        }

        if (snap && !Input.GetMouseButton(0))
        {
            transform.position = slot.transform.position;
            awake = false;
            snap = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "slot")
        {
            snap = true;
            slot = collider;
        }
    }
}
