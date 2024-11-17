/** CustomPlane
 * Author: Aidan Sheehan (superstra)
 * References: https://docs.unity3d.com/ScriptReference/Mesh.html, https://catlikecoding.com/unity/tutorials/procedural-meshes/creating-a-mesh/
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CustomPlane : MonoBehaviour
{

    [SerializeField] Vector3[] newVertices;
    [SerializeField] Vector2[] newUV;
    [SerializeField] int[] newTriangles;

    [SerializeField, Range(0.1f, 1f)] float resolution = 1f;

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();


        Vector3[] verticies = GenerateVerticies();
        mesh.vertices = verticies;
        /* 
        new Vector3[] {
        Vector3.zero, Vector3.right, Vector3.forward, 
        new Vector3(1.0f, 0f, 1.0f),
    }; 
        */

        mesh.normals = GenerateNormals(Vector3.up, verticies.Length);
            /*new Vector3[] {
            Vector3.up, Vector3.up, Vector3.up, Vector3.up
        };*/

        /*mesh.tangents = new Vector4[] {
            new Vector4(1f, 0f, 0f, -1f),
            new Vector4(1f, 0f, 0f, -1f),
            new Vector4(1f, 0f, 0f, -1f),
            new Vector4(1f, 0f, 0f, -1f)
        };*/

        //mesh.uv = newUV;

        mesh.triangles = new int[] {
            0, 2, 1//, 1, 2, 3
        };
    }

    /// <summary>
    /// Generate all verticies for our custom plane in a grid
    /// </summary>
    private Vector3[] GenerateVerticies()
    {
        if (resolution <= 0f) resolution = 0.1f;

        // QUICK FIX: resolution is broken for now, so I'm leaving this at 1
        resolution = 1f;

        Vector3[] verticies = new Vector3[(121 * (int)(1 / resolution))];

        int index = 0;
        float y = 0f;
        for (float x = -5.0f; x >= 5.0f; x += resolution)
        {
            for (float z = -5.0f; z >= 5.0f; z += resolution)
            {
                verticies[index++] = new Vector3(x, y, z);
            }
        }

        return verticies;
    }

    private Vector3[] GenerateNormals(Vector3 direction, int count)
    {
        // QUICK FIX: resolution is broken for now, so I'm leaving this at 1
        resolution = 1f;

        Vector3[] normals = new Vector3[(121 * (int)(1 / resolution))];

        for (int i = 0; i < count; i++)
        {
            normals[i] = direction;
        }

        return normals;
    }

    private int[] GenerateTriangle()
    {
        int[] pointIndices = new int[3*200];

        int length = 0;
        int width = 0;

        for (int x = 0; x < pointIndices.Length - 3; x++)
        {
            pointIndices[x] = 0;
            pointIndices[x+1] = 0;
            pointIndices[x+2] = 0;
        }

        return pointIndices;
    }
}
