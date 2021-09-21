using System;
namespace SOLID.ISP.ISP.KO
{
    public class Flash :IHero
    {
        public Flash() { }

        public void Fly() { throw new Exception("No puede Volar"); }

        public void SuperHearing() { throw new Exception("No tiene super oido"); }

        public void SuperSpeed() { /*Puede correr muy rápido*/ }

        public void SuperStrength() { throw new Exception("No tiene super fuerza"); }

        public void SuperVision() { throw new Exception("No tiene super visión"); }
    }
}
