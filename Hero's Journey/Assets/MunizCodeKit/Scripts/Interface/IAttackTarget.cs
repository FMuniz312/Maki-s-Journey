using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MunizCodeKit.Systems;
namespace MunizCodeKit.Interface
{
    public interface IAttackTarget
    {
        PointsSystem GetHealthSystem();
        void Attacked();
        void Attacked(float damage);
    }
}