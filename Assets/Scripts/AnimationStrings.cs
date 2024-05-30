using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;




internal class AnimationStrings
{
    //player animation strings
    internal static readonly string isMoving = "IsMoving";
    internal static readonly string isRunning = "IsRunning";
    internal static readonly string yVelocity = "yVelocity";
    internal static readonly string isGrounded = "isGrounded";
    internal static readonly string jump = "jump";
    internal static readonly string sliding = "isSlide";

    //door animationstrings
    internal static readonly string Open = "PlayerEnter";
    internal static readonly string close = "PlayerLeave";

    //attack animationstrings
    internal static readonly string AttackTrigger = "attack";
    internal static readonly string canMove = "canMove";


    //door
    internal static readonly string nextScene = "NextScene";


    //box
    internal static readonly string hit = "Hit";
}
