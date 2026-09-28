using DG.Tweening;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Enemy_Health
{
    [Header("Enemy_Health")]
    [field:SerializeField]public float Enemy_Hp {  get; private set; }

    [Header("Kill_Banner")]
    [SerializeField] private CanvasGroup kill_banner_A;
    [SerializeField] private Transform kill_banner_T;
    private Sequence _seq;

    private void Awake()
    {
        Enemy_Hp = 150;
    }

    public void Damage(int value)
    {
        Enemy_Hp -= value;
        Debug.Log(value);
        if (Enemy_Hp <= 0)
        {
            Show_Kill_Banner();
            Enemy_Hp = 150;
        }
    }

    private void Show_Kill_Banner()
    {
        if (_seq != null && _seq.IsPlaying())
        {
            kill_banner_T.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360);
        }
        else
        {
            _seq.Kill();
            _seq = DOTween.Sequence();
            _seq.Append(kill_banner_A.DOFade(1, 1))
            .Join(kill_banner_T.DOScale(1, 1))
            .Join(kill_banner_T.DORotate(new Vector3(0, 0, 360f), 1,RotateMode.FastBeyond360));
            _seq.AppendInterval(2f);
            _seq.Append(kill_banner_A.DOFade(0, 1));
            _seq.Join(kill_banner_T.DOScale(0, 1));
            _seq.Play();
        }
    }
}
