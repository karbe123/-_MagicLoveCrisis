using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    //������ �ִϸ� ���� �������� ���� ���� ���ϴ����� �̰� �ؾ� �����δ� �Ϥ�...��
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] AnimClip;

    public enum AnimState
    {
        Standing, Work
    }
    private AnimState _AnimState;

    private string CurrentAnimation;

    private Rigidbody2D rig;
    private float xx;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�������� ���� ����
        xx = Input.GetAxisRaw("Horizontal");

        if (xx == 0f )
        {
            _AnimState = AnimState.Standing;

        }
        else
        {
            _AnimState = AnimState.Work;
            transform.localScale = new Vector2(xx, 1); // �¿���������ֱ�
        }
        SetCurrentAnimation(_AnimState);
    

        //�����Է�
            if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }


    }
    private void _AsyncAnimation(AnimationReferenceAsset animClip, bool loop, float timeScale)
    {
        if (animClip.name.Equals(CurrentAnimation))
            return; //���Ͼִ� ��� ����

        skeletonAnimation.state.SetAnimation(0, animClip, loop).TimeScale = timeScale;

        CurrentAnimation = animClip.name; //���� ����Ǵ� �ִ� �� ����
    }

    private void SetCurrentAnimation(AnimState _state) // �ִϺ���
    {
        switch (_state)
        {
            case AnimState.Standing:
                _AsyncAnimation(AnimClip[(int)AnimState.Standing], true,1f);
                break;
            case AnimState.Work:
                _AsyncAnimation(AnimClip[(int)AnimState.Work], true, 1f);
                break;
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }


}
