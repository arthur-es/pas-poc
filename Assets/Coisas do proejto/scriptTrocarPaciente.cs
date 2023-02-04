using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptTrocarPaciente : MonoBehaviour
{
    [SerializeField]
    public Text nomePaciente;
    [SerializeField]
    public Text condicaoPaciente;

    public void OnSelectPaciente(Item item)
    {
        nomePaciente.text = item.nomePaciente;
        condicaoPaciente.text = item.condicaoPaciente;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string nomePaciente;
    public new string condicaoPaciente;
}
