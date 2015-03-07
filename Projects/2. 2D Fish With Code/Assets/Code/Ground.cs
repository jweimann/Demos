using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private float _scrollSpeed = 5f;

	// Update is called once per frame
    void Update()
    {
        if (GameState.IsPaused)
            return;

        // Get the current Texture Offset
        Vector2 currentOffset = this.renderer.material.GetTextureOffset("_MainTex");

        // Multiply the speed set in the inspector by the time since the last frame
        float amountToScroll = Time.deltaTime * _scrollSpeed;

        // Calculate the new X (horizontal) position by adding our amountToScroll to the current
        float newOffsetX = currentOffset.x + amountToScroll;

        // Create a new Vector2 for the offset with the x that we calculated and the original Y (height)
        Vector2 newOffset = new Vector2(newOffsetX, currentOffset.y);

        // Set the offset on the quads renderer material.
        this.renderer.material.SetTextureOffset("_MainTex", newOffset);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel(0);
    }
}
