
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using TMPro;

public class ClickHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _clicked;

    private BoxCollider _collider;
    private MouseInputProvider _mouse;
    private Rigidbody m_rigidbody;
    private GameObject outroPaciente;
    private GameObject nome;
    private TextMeshProUGUI nomeText;
    private GameObject condicao;
    private TextMeshProUGUI condicaoText;
    private Rigidbody rbOutroPaciente;
    private string nomeS;
    private string condicaoS;

    private void Awake()
    {
        _mouse = FindObjectOfType<MouseInputProvider>();
        _collider = GetComponent<BoxCollider>();
        _mouse.Clicked += MouseOnClicked;
        m_rigidbody = GetComponent<Rigidbody>();
        nome = GameObject.Find("nome");
        condicao = GameObject.Find("condicao");
        condicaoText = condicao.GetComponent<TextMeshProUGUI>();
        nomeText = nome.GetComponent<TextMeshProUGUI>();
        if (this.name == "Paciente1")
        {
            outroPaciente = GameObject.Find("Paciente2");

        } else
        {
            outroPaciente = GameObject.Find("Paciente1");
        }
        rbOutroPaciente = outroPaciente.GetComponent(typeof(Rigidbody)) as Rigidbody;
    }

    private void MouseOnClicked()
    {
        
        if (_collider.bounds.Contains(_mouse.WorldPosition))
        {
            _clicked?.Invoke();
            Vector3 pos = m_rigidbody.position;
            Vector3 pos2 = rbOutroPaciente.position;
            if (pos.x == 0)
            {
                pos.x = (float)-1.5;
                pos.z = (float)1.8;
                pos2.x = 0;
                pos2.z = 1;
                nomeText.text = "Nome: Jose";
                condicaoText.text = "Condicao: Dor de dente";
            } else
            {
                nomeText.text = "Nome: Joao";
                condicaoText.text = "Condicao: Dor de dedo";
                pos.x = 0;
                pos.z = 1;
                pos2.x = (float)-1.5;
                pos2.z = (float)1.8;

            }
            m_rigidbody.MovePosition(pos);
            rbOutroPaciente.MovePosition(pos2);
        }
    }
}
