using UnityEngine;
using UnityEngine.InputSystem;

public class handcontroller : MonoBehaviour
{

    public InputActionReference triggerBtn;
    public InputActionReference gripBtn;
    public Animator handAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = triggerBtn.action.ReadValue<float>();
        float gripValue = gripBtn.action.ReadValue<float>();
        Debug.Log("trigger Value: " + triggerValue);
        Debug.Log("grip Value: " + gripValue);

        handAnimator.SetFloat("trigger", triggerValue);
        handAnimator.SetFloat("grip", gripValue);
    }
}
