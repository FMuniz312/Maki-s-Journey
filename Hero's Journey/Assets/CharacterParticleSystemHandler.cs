using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParticleSystemHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem dustWalking;
    [SerializeField] ParticleSystem attackingNormal;



    public void EmitDustWalking(int particleAmount)
    {
        dustWalking.Emit(particleAmount);
        dustWalking.Play();
    }

    public void EmitAttacking(int particleAmount)
    {
        attackingNormal.Emit(particleAmount);
        attackingNormal.Play();
    }
}
