using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public int dimention = 10;
    public float uvScale;
    public Octave[] octaves;

    protected MeshFilter meshFilter;
    protected Mesh mesh;

    private Vector3[] GenerateVertices()
    {

        var verts = new Vector3[(dimention + 1) * (dimention + 1)];
        for (int x = 0; x <= dimention; x++)
        {
            for (int z = 0; z <= dimention; z++)
            {
                verts[index(x, z)] = new Vector3(x, 0, z);
            }
        }
        return verts;
    }
    private int[] GenerateTriangles()
    {
        var trian = new int[mesh.vertices.Length * 6];

        for (int x = 0; x < dimention; x++)
        {
            for (int z = 0; z < dimention; z++)
            {
                trian[index(x, z) * 6] = index(x, z);
                trian[index(x, z) * 6 + 1] = index(x + 1, z + 1);
                trian[index(x, z) * 6 + 2] = index(x + 1, z);
                trian[index(x, z) * 6 + 3] = index(x, z);
                trian[index(x, z) * 6 + 4] = index(x, z + 1);
                trian[index(x, z) * 6 + 5] = index(x + 1, z + 1);
            }
        }
        return trian;

    }
    private Vector2[] GenerateUvs()
    {
        var uvs = new Vector2[mesh.vertices.Length];

        for (int x = 0; x < dimention; x++)
        {
            for (int z = 0; z < dimention; z++)
            {
                var vec = new Vector2((x / uvScale) % 2, (z / uvScale) % 2);
                uvs[index(x, z)] = new Vector2(vec.x <= 1 ? vec.x : 2 - vec.x, vec.y <= 1 ? vec.y : 2 - vec.y);
            }
        }


        return uvs;
    }
    private int index(int x, int z)
    {
        return x * (dimention + 1) + z;
    }

    public float GetHeight(Vector3 position)
    {
        //scale factor and position in local space
        var scale = new Vector3(1 / transform.lossyScale.x, 0, 1 / transform.lossyScale.z);
        var localPos = Vector3.Scale((position - transform.position), scale);

        //get edge points
        var p1 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Floor(localPos.z));
        var p2 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Ceil(localPos.z));
        var p3 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Floor(localPos.z));
        var p4 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Ceil(localPos.z));

        //clamp if the position is outside the plane
        p1.x = Mathf.Clamp(p1.x, 0, dimention);
        p1.z = Mathf.Clamp(p1.z, 0, dimention);
        p2.x = Mathf.Clamp(p2.x, 0, dimention);
        p2.z = Mathf.Clamp(p2.z, 0, dimention);
        p3.x = Mathf.Clamp(p3.x, 0, dimention);
        p3.z = Mathf.Clamp(p3.z, 0, dimention);
        p4.x = Mathf.Clamp(p4.x, 0, dimention);
        p4.z = Mathf.Clamp(p4.z, 0, dimention);

        //get the max distance to one of the edges and take that to compute max - dist
        var max = Mathf.Max(Vector3.Distance(p1, localPos), Vector3.Distance(p2, localPos), Vector3.Distance(p3, localPos), Vector3.Distance(p4, localPos) + Mathf.Epsilon);
        var dist = (max - Vector3.Distance(p1, localPos))
                 + (max - Vector3.Distance(p2, localPos))
                 + (max - Vector3.Distance(p3, localPos))
                 + (max - Vector3.Distance(p4, localPos) + Mathf.Epsilon);
        //weighted sum
        var height = mesh.vertices[index((int)p1.x, (int)p1.z)].y * (max - Vector3.Distance(p1, localPos))
                   + mesh.vertices[index((int)p2.x, (int)p2.z)].y * (max - Vector3.Distance(p2, localPos))
                   + mesh.vertices[index((int)p3.x, (int)p3.z)].y * (max - Vector3.Distance(p3, localPos))
                   + mesh.vertices[index((int)p4.x, (int)p4.z)].y * (max - Vector3.Distance(p4, localPos));

        //scale
        return height * transform.lossyScale.y / dist;

    }

    [Serializable]
    public struct Octave
    {
        public Vector2 speed;
        public Vector2 scale;
        public float height;
        public bool alternate;
    }

    private void Start()
    {
        mesh = new Mesh();
        mesh.name = gameObject.name;

        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();
        mesh.uv = GenerateUvs();
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();


        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }
    private void Update()
    {
        var verts = mesh.vertices;
        for (int x = 0; x < dimention; x++)
        {
            for (int z = 0; z < dimention; z++)
            {
                float y = 0f;

                for (int o = 0; o < octaves.Length; o++)
                {
                    if (octaves[0].alternate)
                    {
                        var perl = Mathf.PerlinNoise((x * octaves[o].scale.x) / dimention, (z * octaves[o].scale.y) / dimention) * Math.PI * 2f;
                        y += Mathf.Cos((float)perl + octaves[o].speed.magnitude * Time.time) * octaves[o].height;
                    }
                    else
                    {
                        var perl = Mathf.PerlinNoise((x * octaves[o].scale.x + Time.time * octaves[o].speed.x) / dimention, (z * octaves[o].scale.y + Time.time * octaves[o].speed.y) / dimention) - 0.5f;
                        y += (float)perl * octaves[o].height;
                    }
                }
                verts[index(x, z)] = new Vector3(x, y, z);

            }

        }
        mesh.vertices = verts;
        mesh.RecalculateNormals();
    }

}

