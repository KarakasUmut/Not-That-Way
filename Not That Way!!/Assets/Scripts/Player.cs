using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public float PlayerSpeed;
    public float HorSpeed;
    public float JumpHeight;
    public float jumpDuration;
    public Transform jumpObject;
    public UiManager UiManager;
    

    Animator animator;
    private Rigidbody rb;
    private bool _Jump = false;
    private Vector3 originalPos;

    
   

    private void Start()
    {
        originalPos = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        transform.Translate(Vector3.forward * PlayerSpeed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 hareket = new Vector3(touch.deltaPosition.x, 0, 0) * HorSpeed * Time.deltaTime;
                transform.Translate(hareket);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            Time.timeScale = 0f;
            UiManager.finishScreen();
            

        }
        else if(other.gameObject.CompareTag("Jump"))
        {
            Jump();
            _Jump = true;
            animator.SetTrigger("Jump");
        }

       
       


    }

   



    private void Jump()
    {
        _Jump = true;

        // Jump objesine doðru bir yukarý hareket oluþtur
        transform.DOMoveY(jumpObject.position.y + JumpHeight, jumpDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(Fall);
    }

    private void Fall()
    {
        // Ýlk konumuna geri dön
        transform.DOMoveY(originalPos.y, jumpDuration)
            .SetEase(Ease.InQuad)
            .OnComplete(ResetJump);
    }

    private void ResetJump()
    {
        _Jump = false;
    }

}
