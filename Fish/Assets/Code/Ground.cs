using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

    [SerializeField]
    private float _scrollSpeed = 5f;

	// Update is called once per frame
    void Update()
    {
        if (GameState.IsPaused)
            return;

        ScrollTextureLeftUsingSetTextureOffset();
    }

    private void ScrollTextureLeftUsingSetTextureOffset()
    {
        // Get the current offset
        Vector2 currentTextureOffset = this.renderer.material.GetTextureOffset("_MainTex");

        // Determine the amount to scroll this frame
        float distanceToScrollLeft = Time.deltaTime * _scrollSpeed; 

        // Calculate the new offset (Add current + distance)
        float newTextureOffset_X = currentTextureOffset.x + distanceToScrollLeft;

        // Create a new Vector2 with the updated offset
        currentTextureOffset = new Vector2(newTextureOffset_X, currentTextureOffset.y);

        // Set the offset to our new value
        this.renderer.material.SetTextureOffset("_MainTex", currentTextureOffset);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel(0);
    }
}
