using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class AttackAnimationdata
{
    public Character dealer;
    public Character reciever;

    public bool playerAttacks;

    public int damage;
}
public class AttackAnimationHandler : MonoBehaviour
{
    [SerializeField] private GameObject AttackAnimationPanel;
    [SerializeField] private RectTransform PlayerAnimationObject;
    [SerializeField] private Image PlayerAnimationSprite;
    [SerializeField] private RectTransform EnemyAnimationObject;
    [SerializeField] private Image EnemyAnimationSprite;
    [SerializeField] private RectTransform DamageTextObject;
    [SerializeField] private TMP_Text DamageTextText;


    public AttackAnimationdata TEST = new();


    [SerializeField] private RectTransform PlayerAttackingAnchor;
    [SerializeField] private RectTransform PlayerGettingAttackedAnchor;
    [SerializeField] private RectTransform EnemyAttackingAnchor;
    [SerializeField] private RectTransform EnemyGettingAttackedAnchor;

    public void Awake()
    {
        Utilities.AnimationEvent += InitateAnimation; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartAttackAnimation(TEST));
        }
    }


    public void InitateAnimation(AttackAnimationdata AAD)
    {
        StartCoroutine(StartAttackAnimation(AAD));
    }
    public IEnumerator StartAttackAnimation(AttackAnimationdata AAD)
    {

        PlayerAnimationObject.position = PlayerGettingAttackedAnchor.position;
        EnemyAnimationObject.position = EnemyGettingAttackedAnchor.position;
        AttackAnimationPanel.SetActive(true);

        Coroutine MovePlayerCoroutine = null;
        Coroutine MoveEnemyCoroutine = null;
        Coroutine MoveTextCoroutine = null;

        if (AAD.playerAttacks)
        {
            if (AAD.reciever == null)
            {
                EnemyAnimationObject.gameObject.SetActive(false);
                PlayerAnimationSprite.sprite = AAD.dealer.CharacterSprite;
                PlayerAnimationObject.position = PlayerAttackingAnchor.position;

                DamageTextText.text = "NOT IMPLEMENTED YET FULLY";

                MovePlayerCoroutine =
                    StartCoroutine(MoveImageInDirection(PlayerAnimationObject, Vector3.right, 0.025f, 99999));
                MoveTextCoroutine =
                    StartCoroutine(MoveImageInDirection(DamageTextObject, new Vector3(1, 1, 0), 0.025f, 99999));
            }
            else
            {
                PlayerAnimationSprite.sprite = AAD.dealer.CharacterSprite;
                EnemyAnimationSprite.sprite = AAD.reciever.CharacterSprite;

                PlayerAnimationObject.position = PlayerAttackingAnchor.position;
                DamageTextObject.position = EnemyGettingAttackedAnchor.position;

                DamageTextText.text = "-" + AAD.damage + "HP";

                MovePlayerCoroutine =
                    StartCoroutine(MoveImageInDirection(PlayerAnimationObject, Vector3.right, 0.025f, 99999));
                MoveEnemyCoroutine =
                    StartCoroutine(MoveImageInDirection(EnemyAnimationObject, Vector3.right, 0.010f, 99999));
                MoveTextCoroutine =
                    StartCoroutine(MoveImageInDirection(DamageTextObject, new Vector3(1, 1, 0), 0.025f, 99999));
            }
        }
        else
        {
            if(AAD.reciever == null)
            {
                PlayerAnimationObject.gameObject.SetActive(false);
                EnemyAnimationSprite.sprite = AAD.dealer.CharacterSprite;
                EnemyAnimationObject.position = EnemyAttackingAnchor.position;

                DamageTextText.text = "NOT YET IMPLEMENTED FULLY";

                MoveEnemyCoroutine =
                    StartCoroutine(MoveImageInDirection(EnemyAnimationObject, Vector3.left, 0.025f, 99999));
                MoveTextCoroutine =
                    StartCoroutine(MoveImageInDirection(DamageTextObject, new Vector3(-1, 1, 0), 0.025f, 99999));
            }
            else
            {
                PlayerAnimationSprite.sprite = AAD.reciever.CharacterSprite;
                EnemyAnimationSprite.sprite = AAD.dealer.CharacterSprite;

                EnemyAnimationObject.position = EnemyAttackingAnchor.position;
                DamageTextObject.position = PlayerGettingAttackedAnchor.position;

                DamageTextText.text = "-" + AAD.damage + "HP";

                MovePlayerCoroutine =
                    StartCoroutine(MoveImageInDirection(PlayerAnimationObject, Vector3.left, 0.010f, 99999));
                MoveEnemyCoroutine =
                    StartCoroutine(MoveImageInDirection(EnemyAnimationObject, Vector3.left, 0.025f, 99999));
                MoveTextCoroutine =
                    StartCoroutine(MoveImageInDirection(DamageTextObject, new Vector3(-1, 1, 0), 0.025f, 99999));
            }
        }


        yield return new WaitForSecondsRealtime(1);

        StopCoroutine(MovePlayerCoroutine);
        StopCoroutine(MoveEnemyCoroutine);
        StopCoroutine(MoveTextCoroutine);

        PlayerAnimationObject.gameObject.SetActive(true);
        EnemyAnimationObject.gameObject.SetActive(true);
        AttackAnimationPanel.SetActive(false);
    }


    public IEnumerator MoveImageInDirection(RectTransform image, Vector3 direction, float speed, int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            image.position += direction.normalized * speed;
            yield return null;
        }
    }

}
