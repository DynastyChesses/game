using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class OutlineController : MonoBehaviour, IMaterialModifier
{
    [SerializeField] bool outlineEnabled = true;
    
    private Graphic m_Graphic;
    private Material m_MaterialInstance;

    void Awake()
    {
        m_Graphic = GetComponent<Graphic>();
        m_Graphic.material = m_Graphic.defaultMaterial;
        UpdateOutlineState();
    }

    void OnValidate()
    {
        if (m_Graphic != null)
            UpdateOutlineState();
    }

    public void SetOutlineEnabled(bool state)
    {
        outlineEnabled = state;
        UpdateOutlineState();
    }

    void UpdateOutlineState()
    {
        if (m_Graphic == null) return;
        
        // 使用UV1通道传递控制参数
        var vh = new VertexHelper();
        m_Graphic.SetVerticesDirty();
    }

    public Material GetModifiedMaterial(Material baseMaterial)
    {
        if (!isActiveAndEnabled) return baseMaterial;

        if (m_MaterialInstance == null)
        {
            m_MaterialInstance = new Material(baseMaterial);
            m_MaterialInstance.hideFlags = HideFlags.HideAndDontSave;
        }

        // 设置控制参数到材质实例
        m_MaterialInstance.SetFloat("_UseVertexControl", 1);
        return m_MaterialInstance;
    }

    void OnDisable()
    {
        if (m_MaterialInstance != null)
            DestroyImmediate(m_MaterialInstance);
    }

    // 顶点数据修改
    public void ModifyMesh(VertexHelper vh)
    {
        if (!isActiveAndEnabled) return;

        UIVertex vertex = new UIVertex();
        for (int i = 0; i < vh.currentVertCount; i++)
        {
            vh.PopulateUIVertex(ref vertex, i);
            // 使用uv1.x传递控制参数
            vertex.uv1.x = outlineEnabled ? 1 : 0;
            vh.SetUIVertex(vertex, i);
        }
    }
}