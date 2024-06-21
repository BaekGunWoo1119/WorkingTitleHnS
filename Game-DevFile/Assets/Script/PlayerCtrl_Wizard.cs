using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl_Wizard : MonoBehaviour
{
    float hAxis;
    float vAxis;
    public float moveSpeed;

    public GameObject PlayerModel;

    bool isSkill = false;
    bool isAttack = false;
    


    Vector3 moveVec;

    Animator anim;
    Rigidbody rd;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rd = GetComponent<Rigidbody>();

         anim.SetBool("isIdle", true);
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Attack();
        Skill();
        Vector3 currentRotation = transform.rotation.eulerAngles;
        if (currentRotation.z == 0)
        {

        }
        else
        {
            currentRotation.z = 0f;
            transform.rotation = Quaternion.Euler(currentRotation);
            Transform childTransform = transform.GetChild(0);
            Vector3 childRotation = transform.rotation.eulerAngles;
            childRotation = childTransform.localRotation.eulerAngles;
            childRotation.z = 0f;
            transform.rotation = Quaternion.Euler(childRotation);
        }
        /*AnimatorClipInfo[] currentClips = anim.GetCurrentAnimatorClipInfo(0);
        
       
        if (currentClips.Length > 0)
        {
            string currentClipName = currentClips[0].clip.name;
            Debug.Log("현재 재생 중인 애니메이션 클립: " + currentClipName);
        }*/
    }
    
    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }

    void Move()
{
    if (!isSkill && !isAttack)
    {
        moveVec = new Vector3(vAxis, 0, -hAxis).normalized;
        transform.position += moveVec * moveSpeed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
    }

    StartCoroutine(Delay());
}

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("CommonAttack");
            isAttack = true;
        }
    }

    void Skill()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Skill_Q");
            isSkill = true;
            //StartCoroutine(MoveForwardForSeconds(2.0f));
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Skill_W");
            isSkill = true;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Skill_E");
            isSkill = true;
        }
    }

    IEnumerator MoveForwardForSeconds(float seconds)
    {
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            PlayerModel.transform.rotation = Quaternion.Euler(0,0,0);
            isAttack = false;
            isSkill = false;
        }

    }

}
