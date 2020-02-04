using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Standart Enemy", fileName = "New Enemy")]
public class EnemyData : ScriptableObject
{
    [Tooltip("Основная модель")]
    [SerializeField]private Mesh meshFilter;
    public Mesh MainMesh
    {
        get { return meshFilter; }
        protected set { }
    }

    [Tooltip("Название врага")]
    [SerializeField] private string NameEnemy;
    public string Name
    {
        get { return NameEnemy; }
        protected set { }
    }

    [Tooltip("Здоровье врага")]
    [SerializeField] private float HealthEnemy;
    public float Health
    {
        get { return HealthEnemy; }
        protected set { }
    }

    [Tooltip("Аттака врага")]
    [SerializeField] private float AttackEnemy;
    public float Damage
    {
        get { return AttackEnemy; }
        protected set { }
    }

    [Tooltip("Скорость врага")]
    [SerializeField] private float SpeedEnemy;
    public float Speed
    {
        get { return SpeedEnemy; }
        protected set { }
    }

    [Tooltip("Скорость атаки врага")]
    [SerializeField] private float AttackSpeedEnemy;

    public float AttackSpeed
    {
        get { return AttackSpeedEnemy; }
        protected set { }
    }

    [Tooltip("Материал врага")]
    [SerializeField] private Material MaterialEnemy;

    public Material MaterialE
    {
        get { return MaterialEnemy; }
        protected set { }
    }

    /*[Tooltip("Animator врага")]
    [SerializeField] private RuntimeAnimatorController AnimatorEnemy;

    public RuntimeAnimatorController AnimatorE
    {
        get { return AnimatorEnemy; }
        protected set { }
    }*/

}
   
