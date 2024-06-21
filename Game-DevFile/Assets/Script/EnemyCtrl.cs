using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject SpinSpot;
    public int numBullets = 8;
    public float bulletSpeed = 10f;

    public float rotationSpeed = 30.0f;

    public float damage = 20f;
    public float moveSpeed = 2f;
    private Vector3 initialPosition;

    private Transform playerTransform;
    private Rigidbody rb;

    public float chargeSpeed = 3.0f;
    private bool isRush = false;
    private bool isSwing = false;

    public Animator animator;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;

        StartCoroutine(Think());
    }
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, playerTransform.position));
        Vector3 currentRotation = playerTransform.rotation.eulerAngles;
        currentRotation.x = 0;
        if (isRush == false)
        {
            if (isSwing == true)
            {
                animator.SetBool("Walk", true);
                Vector3 targetPosition = playerTransform.position;
                Vector3 direction = (targetPosition - transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;

                transform.position += transform.forward * moveSpeed * 2 * Time.deltaTime;
            }
            else
            {
                animator.SetBool("Walk", true);
                Vector3 targetPosition = playerTransform.position;
                Vector3 direction = (targetPosition - transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;

                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(1.0f);

        int ranAction = Random.Range(0, 5);
        switch (ranAction)
        {
            case 0:
                break;
            case 1:
                StartCoroutine(RushAttack());
                break;
            case 2:
                StartCoroutine(SwingAttack());
                break;
        }
    }

    IEnumerator SwingAttack()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("보스 : 회전공격");
        isSwing = true;
        float elapsedTime = 0.0f; // 경과 시간

        while (elapsedTime < 5.0f)
        {
            // 물체를 회전합니다.
            SpinSpot.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
        isSwing = false;
        StartCoroutine(Think());
    }

    IEnumerator RushAttack()
    {
        yield return new WaitForSeconds(0.2f);
        isRush = true;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        animator.SetBool("Walk", false);
        yield return new WaitForSeconds(2.0f);

        Debug.Log("보스 : 돌진공격");
        animator.SetBool("Run", true);
        Vector3 targetPosition = playerTransform.position - (playerTransform.forward * 2.0f);

        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
        float startTime = Time.time;

        while (Time.time - startTime < 2.5f)
        {
            rb.AddForce(transform.forward * chargeSpeed);
            yield return null;
        }

        rb.velocity = Vector3.zero;
        isRush = false;
        animator.SetBool("Run", false);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Think());
    }
}