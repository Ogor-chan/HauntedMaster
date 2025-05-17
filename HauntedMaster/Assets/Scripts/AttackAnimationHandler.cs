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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartAttackAnimation(TEST));
        }
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
            PlayerAnimationSprite.sprite = AAD.dealer.CharacterSprite;
            EnemyAnimationSprite.sprite = AAD.reciever.CharacterSprite;

            PlayerAnimationObject.position = PlayerAttackingAnchor.position;
            DamageTextObject.position = EnemyGettingAttackedAnchor.position;


            MovePlayerCoroutine = 
                StartCoroutine(MoveImageInDirection(PlayerAnimationObject, Vector3.right, 0.025f, 99999));
            MoveEnemyCoroutine =
                StartCoroutine(MoveImageInDirection(EnemyAnimationObject, Vector3.right, 0.010f, 99999));
            MoveTextCoroutine =
                StartCoroutine(MoveImageInDirection(DamageTextObject, new Vector3(1, 1, 0), 0.025f, 99999));
        }
        else
        {
            PlayerAnimationSprite.sprite = AAD.reciever.CharacterSprite;
            EnemyAnimationSprite.sprite = AAD.dealer.CharacterSprite;

            EnemyAnimationObject.position = EnemyAttackingAnchor.position;
            DamageTextObject.position = PlayerGettingAttackedAnchor.position;

            MovePlayerCoroutine =
                StartCoroutine(MoveImageInDirection(PlayerAnimationObject, Vector3.left, 0.010f, 99999));
            MoveEnemyCoroutine =
                StartCoroutine(MoveImageInDirection(EnemyAnimationObject, Vector3.left, 0.025f, 99999));
            MoveTextCoroutine =
                StartCoroutine(MoveImageInDirection(DamageTextObject, new Vector3(-1, 1, 0), 0.025f, 99999));
        }

        DamageTextText.text = "-" + AAD.damage + "HP";


        yield return new WaitForSecondsRealtime(1);

        StopCoroutine(MovePlayerCoroutine);
        StopCoroutine(MoveEnemyCoroutine);
        StopCoroutine(MoveTextCoroutine);

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
