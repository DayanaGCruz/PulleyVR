using UnityEngine;

public class CubePainter : MonoBehaviour
{
    public Texture2D brushTexture;  // The brush texture used for painting.
    public float brushSize = 0.1f;  // The size of the brush.
    public Color brushColor = Color.red; // The color of the brush.

    private RaycastHit hit;
    private Renderer cubeRenderer;
    private Texture2D canvasTexture;
    private bool isPainting = false;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        canvasTexture = Instantiate(cubeRenderer.material.mainTexture) as Texture2D;
        cubeRenderer.material.mainTexture = canvasTexture;
    }

    void Update()
    {
        // Check for the "B" key press to start/stop painting.
        if (Input.GetKeyDown(KeyCode.B))
        {
            isPainting = !isPainting;
        }

        if (isPainting && Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Vector2 pixelUV = hit.textureCoord;

                // Convert hit texture coordinates to pixel coordinates.
                pixelUV.x *= canvasTexture.width;
                pixelUV.y *= canvasTexture.height;

                Paint(pixelUV);
            }
        }
    }

    void Paint(Vector2 pixelUV)
    {
        int brushSizeInPixels = Mathf.RoundToInt(brushSize * canvasTexture.width);

        for (int x = 0; x < brushSizeInPixels; x++)
        {
            for (int y = 0; y < brushSizeInPixels; y++)
            {
                int brushPixelX = Mathf.RoundToInt(pixelUV.x - brushSizeInPixels / 2 + x);
                int brushPixelY = Mathf.RoundToInt(pixelUV.y - brushSizeInPixels / 2 + y);

                if (brushPixelX >= 0 && brushPixelX < canvasTexture.width &&
                    brushPixelY >= 0 && brushPixelY < canvasTexture.height)
                {
                    canvasTexture.SetPixel(brushPixelX, brushPixelY, brushColor);
                }
            }
        }

        // Apply changes to the texture.
        canvasTexture.Apply();
    }
}
