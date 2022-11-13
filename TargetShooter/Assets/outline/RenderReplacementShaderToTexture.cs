using UnityEngine;

public class RenderReplacementShaderToTexture : MonoBehaviour
{
    [SerializeField]
    Shader replacementShader;

    [SerializeField]
    RenderTextureFormat renderTextureFormat = RenderTextureFormat.ARGB32;

    [SerializeField]
    FilterMode filterMode = FilterMode.Point;

    [SerializeField]
    int renderTextureDepth = 24;

    [SerializeField]
    CameraClearFlags cameraClearFlags = CameraClearFlags.Color;

    [SerializeField]
    Color background = Color.black;

    [SerializeField]
    string targetTexture = "_RenderTexture";

    private RenderTexture renderTexture;
    private new Camera camera;

    private void Start()
    {
        foreach (Transform t in transform)
        {
            DestroyImmediate(t.gameObject);
        }

        Camera thisCamera = GetComponent<Camera>();

        renderTexture = new RenderTexture(thisCamera.pixelWidth, thisCamera.pixelHeight, renderTextureDepth, renderTextureFormat);
        renderTexture.filterMode = filterMode;
        Shader.SetGlobalTexture(targetTexture, renderTexture);

        GameObject copy = new GameObject("Camera" + targetTexture);
        camera = copy.AddComponent<Camera>();
        camera.CopyFrom(thisCamera);
        camera.transform.SetParent(transform);
        camera.targetTexture = renderTexture;
        camera.SetReplacementShader(replacementShader, "RenderType");
        camera.depth = thisCamera.depth - 1;
        camera.clearFlags = cameraClearFlags;
        camera.backgroundColor = background;
    }
}
