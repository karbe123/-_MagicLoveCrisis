using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    //스파인 애니를 위한 변수선언 ㅅㅂ 나도 왜하는지모름 이거 해야 움직인대 하ㅣ...ㅜ
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
        //스파인을 위한 선언
        xx = Input.GetAxisRaw("Horizontal");

        if (xx == 0f )
        {
            _AnimState = AnimState.Standing;

        }
        else
        {
            _AnimState = AnimState.Work;
            transform.localScale = new Vector2(xx, 1); // 좌우반전시켜주긔
        }
        SetCurrentAnimation(_AnimState);
    

        //방향입력
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
            return; //동일애니 재생 금지

        skeletonAnimation.state.SetAnimation(0, animClip, loop).TimeScale = timeScale;

        CurrentAnimation = animClip.name; //지금 재생되는 애니 값 변경
    }

    private void SetCurrentAnimation(AnimState _state) // 애니변경
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
