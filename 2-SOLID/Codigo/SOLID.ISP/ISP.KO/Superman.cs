using System;
namespace SOLID.ISP.ISP.KO
{
    public class Superman : IHero
    {
        public Superman() { }

        public void Fly() { /*Puede Volar */}

        public void SuperHearing() {/*Puede Escuchar muy lejos*/ }

        public void SuperSpeed() { /*Puede correr muy rápido*/ }

        public void SuperStrength() { /*Es muy fuerte*/ }

        public void SuperVision() { /*Puede ver a través de los objetos*/ }
    }
}
