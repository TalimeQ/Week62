using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Gameplay
{ 
    public interface IKidListener {

        void OnKidHit(int candyValue, GameObject kid);
    }
}