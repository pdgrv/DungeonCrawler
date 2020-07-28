﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _expGived;
    [SerializeField] private int _scoreGived;
    [SerializeField] private Player _player;

    public Player Player => _player; 

    private Animator _animator;
    private EnemyController _enemyController;
    private CharacterController _controller;

    private int _currentHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyController = GetComponent<EnemyController>();
        _controller = GetComponent<CharacterController>();        
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_currentHealth > 0)
        {
            _animator.SetTrigger("ApplyDamage");
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {        
        _enemyController.enabled = false;
        _controller.enabled = false; 

        _animator.SetTrigger("Die");
        Debug.Log(transform.name + "Die...");

        _player.AddReward(_expGived, _scoreGived);
    }
}