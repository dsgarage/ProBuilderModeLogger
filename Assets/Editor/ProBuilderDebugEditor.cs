using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder;
using System.Collections.Generic;
using System.Linq;

[InitializeOnLoad]
public class ProBuilderModeLogger
{
    private static SelectMode currentMode = SelectMode.Object; // デフォルトはオブジェクトモード
    private static bool modeLocked = false;
    private static List<int> lastSelectedVertices = new List<int>();
    private static List<Edge> lastSelectedEdges = new List<Edge>();
    private static List<Face> lastSelectedFaces = new List<Face>();

    static ProBuilderModeLogger()
    {
        EditorApplication.update += OnEditorUpdate;
    }

    private static void OnEditorUpdate()
    {
        var pbMesh = Selection.activeGameObject?.GetComponent<ProBuilderMesh>();
        if (pbMesh == null)
        {
            modeLocked = false; // オブジェクトが選択されていない場合はロックを解除
            return;
        }

        if (!modeLocked)
        {
            DetermineInitialMode(pbMesh);
            modeLocked = true; // モードを決定した後はロック
        }

        switch (currentMode)
        {
            case SelectMode.Vertex:
                HandleVertexMode(pbMesh);
                break;
            case SelectMode.Edge:
                HandleEdgeMode(pbMesh);
                break;
            case SelectMode.Face:
                HandleFaceMode(pbMesh);
                break;
        }
    }

    private static void DetermineInitialMode(ProBuilderMesh pbMesh)
    {
        if (pbMesh.selectedVertices.Count > 0)
        {
            currentMode = SelectMode.Vertex;
            HandleVertexMode(pbMesh);
        }
        else if (pbMesh.selectedEdges.Count > 0)
        {
            currentMode = SelectMode.Edge;
            HandleEdgeMode(pbMesh);
        }
        else if (pbMesh.GetSelectedFaces().Length > 0)
        {
            currentMode = SelectMode.Face;
            HandleFaceMode(pbMesh);
        }
    }

    private static void HandleVertexMode(ProBuilderMesh pbMesh)
    {
        var currentSelectedVertices = new List<int>(pbMesh.selectedVertices);
        if (currentSelectedVertices.Count > 0 && !AreVerticesEqual(lastSelectedVertices, currentSelectedVertices))
        {
            Debug.Log("Vertex Mode Selected");
            lastSelectedVertices = new List<int>(currentSelectedVertices);
            lastSelectedEdges.Clear();
            lastSelectedFaces.Clear();
            foreach (var vertex in currentSelectedVertices)
            {
                Debug.Log($"Vertex Position: {pbMesh.positions[vertex]}");
            }
        }
    }

    private static void HandleEdgeMode(ProBuilderMesh pbMesh)
    {
        var currentSelectedEdges = new List<Edge>(pbMesh.selectedEdges);
        if (currentSelectedEdges.Count > 0 && !AreEdgesEqual(lastSelectedEdges, currentSelectedEdges))
        {
            Debug.Log("Edge Mode Selected");
            lastSelectedEdges = new List<Edge>(currentSelectedEdges);
            lastSelectedVertices.Clear();
            lastSelectedFaces.Clear();
            foreach (var edge in currentSelectedEdges)
            {
                var startVertex = pbMesh.positions[edge.a];
                var endVertex = pbMesh.positions[edge.b];
                Debug.Log($"Edge: Start {startVertex}, End {endVertex}");
            }
        }
    }

    private static void HandleFaceMode(ProBuilderMesh pbMesh)
    {
        var currentSelectedFaces = pbMesh.GetSelectedFaces();
        var currentSelectedFacesList = currentSelectedFaces.ToList(); 
        if (currentSelectedFaces.Length > 0 && !AreFacesEqual(lastSelectedFaces, currentSelectedFacesList))
        {
            Debug.Log("Face Mode Selected");
            lastSelectedFaces = currentSelectedFacesList;
            lastSelectedVertices.Clear();
            lastSelectedEdges.Clear();
            foreach (var face in currentSelectedFaces)
            {
                Debug.Log("Face vertices:");
                foreach (var index in face.indexes)
                {
                    Debug.Log($"Vertex: {pbMesh.positions[index]}");
                }
            }
        }
    }

    private static bool AreVerticesEqual(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }
        return true;
    }

    private static bool AreEdgesEqual(List<Edge> list1, List<Edge> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (!list1[i].Equals(list2[i]))
                return false;
        }
        return true;
    }

    private static bool AreFacesEqual(List<Face> list1, List<Face> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (!list1[i].Equals(list2[i]))
                return false;
        }
        return true;
    }
}
