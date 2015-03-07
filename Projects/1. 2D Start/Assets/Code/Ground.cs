using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

    public float ScrollSpeed = 5f;

	// Update is called once per frame
    void Update()
    {
        if (GameState.IsPaused)
            return;

        Vector2 offset = this.renderer.material.GetTextureOffset("_MainTex");

        float amountToScroll = Time.deltaTime * ScrollSpeed;

        float newOffsetX = offset.x + amountToScroll;

        offset = new Vector2(newOffsetX, offset.y);

        this.renderer.material.SetTextureOffset("_MainTex", offset);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel(0);
    }
}
