using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engines.Input
{
    public class Command
    {
        private int availability = 0;
        /// <summary>
        /// buffertime is NOT a restriction;  It is to allow some 'give' time between when a player hits a key and when it actually takes effect.
        /// </summary>
        public const int buffertime = 10;
        public bool isBuffered { get { return buffertime != 0;  } }

        public bool trigger()
        {
            if (isBuffered == false) return true; // short circuit if there's no buffertime

            if (availability < 0 )
            {
                availability = buffertime;
                return true;
            }
            return false;
        }

        public void tickdown()
        {
            if(availability > 0 && isBuffered )
            {
                availability--;
            }
        }

        public void reset()
        {
            availability = 0;
        }
    };

    public class MobileInput
    {
        public Command attack = new Command();
        public Command special = new Command();
        public Command block = new Command();
        public Command pickup = new Command();
        public Command jump = new Command();

        public Command moveLeft = new Command();
        public Command moveRight = new Command();
        public Command moveBack = new Command();
        public Command moveFore = new Command();

        public void tickdown()
        {
            attack.tickdown();
            special.tickdown();
            block.tickdown();
            pickup.tickdown();
            jump.tickdown();
            moveLeft.tickdown();
            moveRight.tickdown();
            moveBack.tickdown();
            moveFore.tickdown();
        }
    }
}
