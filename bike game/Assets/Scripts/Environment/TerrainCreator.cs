using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class TerrainCreator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField, Range(3f,100f)] private int LevelLength = 10;
    [SerializeField,Range(1f,50f)] private  float xMultiplier = 2f;
    [SerializeField,Range(1f,50f)] private  float yMultiplier = 2f;
    [SerializeField,Range(1f,50f)] private  float curveSmoothness = 2f;
    [SerializeField] private float noiseStep = 0.5f;
    [SerializeField] private float bottom = 10f;

    private Vector3 lastPosition;
private void OnValidate()
{
    spriteShapeController.spline.Clear();
    lastPosition = Vector3.zero;

    // Generate top terrain points
    for (int i = 0; i < LevelLength; i++)
    {
        lastPosition = transform.position + new Vector3(i * xMultiplier, Mathf.PerlinNoise(i * noiseStep, 0) * yMultiplier, 0);
        spriteShapeController.spline.InsertPointAt(i, lastPosition);

        if (i != 0 && i != LevelLength - 1)
        {
            spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
            spriteShapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
        }
    }

    // Add bottom-right point
    spriteShapeController.spline.InsertPointAt(LevelLength, new Vector3(lastPosition.x, transform.position.y - bottom, 0));

    // Add bottom-left point
    spriteShapeController.spline.InsertPointAt(LevelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom, 0));
}

}