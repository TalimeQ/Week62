using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Player
{ 
    public interface IPlayerListener {

        /// <summary>
        ///  Called when player is dead.
        /// </summary>
        void OnPlayerDeath();
        /// <summary>
        ///  Called when player finishes level;
        /// </summary>
        void OnPlayerFinish();

    }
}