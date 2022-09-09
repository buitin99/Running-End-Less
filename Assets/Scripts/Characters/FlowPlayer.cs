using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FlowPlayer : MonoBehaviour
{
    //Tin custom
    public Transform player;
    public Character character;
    static int s_IsSliding = Animator.StringToHash("isSlide");
    static int s_IsBreath = Animator.StringToHash("isBreath");
    static int s_IsRunning = Animator.StringToHash("isRun");
    static int s_IsDead = Animator.StringToHash("isDead");
    static int s_IsReset = Animator.StringToHash("isReset");
    [SerializeField]
    private Vector3 space  = new Vector3 (0,0,2);
    private bool isCanRun;

    void Awake()
    {
        CharacterInputController.onPlayerMove += SetRun ;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate() {
        if(isCanRun) {
            EnemyMoveFollowPlayer();
        }
    }

    // Update is called once per frame
    // void LateUpdate()
    // {
       
    //     //Vector3 newPos = transform.position;
    //     if (CharacterInputController.isRun)
    //     {
    //         transform.position = player.position - space;
    //         if (CharacterInputController.isStop)
    //         {
    //             transform.position = player.position - (space - new Vector3(0,0,1));
    //         }
    //         //if (transform.position.x != player.position.x)
    //         //{
    //         //    newPos.x = Mathf.MoveTowards(newPos.x, player.position.x, Time.deltaTime * speed);
    //         //    transform.position = newPos;
    //         //}
    //         //if (transform.position.z >= 100)
    //         //{
    //         //    newPos.z = Mathf.MoveTowards(newPos.z, 0,100);
    //         //    transform.position = newPos;
    //         //    Debug.Log(newPos.z);
    //         //}
    //         //else
    //         //{
    //         //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
    //         //}    
    //     }
    //     if (CharacterInputController.isRun)
    //     {
    //         character.animator.SetBool(s_IsRunning, true);
    //     }
            
    //     if (CharacterInputController.isSlide)
    //     {
    //         character.animator.SetBool(s_IsSliding, true);
    //     }  
    //     else if (!CharacterInputController.isSlide)
    //     {
    //         character.animator.SetBool(s_IsSliding, false);
    //     }

    //     if (CharacterInputController.isStop)
    //     {
    //         character.animator.SetBool(s_IsBreath, true);

    //     } else if (!CharacterInputController.isStop)
    //     {
    //         character.animator.SetBool(s_IsBreath, false);
    //     }

    //     if (CharacterCollider.isDead)
    //     {
    //         character.animator.SetBool(s_IsDead, true);
    //     }
      
    // }

    private void SetRun(CharacterInputController character)
    {
        isCanRun = true;
    }
    void EnemyMoveFollowPlayer()
    {

        CharacterInputController _instanceController = CharacterInputController.Instance;
        CharacterCollider _instanceCollider = CharacterCollider.Instance;
        RestartRunning _instanceResetRunning = RestartRunning.Instance;
        transform.position = player.position - space;
        character.animator.SetBool(s_IsRunning, true);

        if (_instanceCollider.PlayerDead())
        {
            character.animator.SetBool(s_IsReset, true); 
        }
 
        if (_instanceController.PlayerStopping())
        {
            character.animator.SetBool(s_IsBreath, true);
        }else if (!_instanceController.PlayerStopping())
        {
            character.animator.SetBool(s_IsBreath, false);
        }

        if (_instanceController.PlayerSliding())
        {
            character.animator.SetBool(s_IsSliding, true);
        }else if (!_instanceController.PlayerSliding())
        {
            character.animator.SetBool(s_IsSliding, false);
        }

        if (_instanceCollider.PlayerDead())
        {
            character.animator.SetBool(s_IsDead, true);
        }
    }
}
