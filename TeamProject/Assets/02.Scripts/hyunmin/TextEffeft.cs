using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class TextEffeft : BaseMeshEffect
{
    TextMeshProUGUI textMeshProUGUI;
    
    public Gradient gradient;
    public float gradienWaveTime;

    protected override void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        gradienWaveTime += Time.deltaTime;
        //textMeshProUGUI.
    }

    public override void ModifyMesh(VertexHelper vh)
    {
        List<UIVertex> vertices = new List<UIVertex>();
            vh.GetUIVertexStream(vertices);
        vh.Clear();
        vh.AddUIVertexTriangleStream(vertices);

        for(int i = 0; i < vertices.Count; i++)
        {
            var v = vertices[i];
            v.color = new Color(Random.value, Random.value, Random.value, 1);
            vertices[i] = v;
        }
    }
}
