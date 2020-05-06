using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    BorderBlock border;

    private void Awake()
    {
        border = GetComponent<BorderBlock>();
    }

    private void Update()
    {
        if(border != null)
        {
            SnapToGrid();
        }
    }

    private void SnapToGrid()
    {
        int gridSize = border.GetGridSize();
        Vector2 gridPos = border.GetGridPos() * gridSize;

        transform.position = new Vector3(
            gridPos.x,
            .5f,
            gridPos.y
        );
    }
}
