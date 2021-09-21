using System;
namespace SOLID.ISP.ISP.KO
{
    public class Batman :IHero
    {
        public Batman() { }

        public void Rich() { /*Es rico*/ }

        public void Fly() { throw new Exception("No puede Volar"); }

        public void SuperHearing() { throw new Exception("No tiene super oido"); }

        public void SuperSpeed() { throw new Exception("No tiene super velocidad"); }

        public void SuperStrength() { throw new Exception("No tiene super fuerza"); }

        public void SuperVision() { throw new Exception("No tiene super visión"); }
    }
}
