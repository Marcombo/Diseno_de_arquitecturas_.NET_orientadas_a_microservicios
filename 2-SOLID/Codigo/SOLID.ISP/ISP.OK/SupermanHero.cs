using System;
namespace SOLID.ISP.ISP.OK
{
    public class SupermanHero : ISupermanPower
    {
        public SupermanHero() { }

        public void Fly() { /*Puede Volar */}

        public void SuperHearing() {/*Puede Escuchar muy lejos*/ }

        public void SuperSpeed() { /*Puede correr muy rápido*/ }

        public void SuperStrength() { /*Es muy fuerte*/ }

        public void SuperVision() { /*Puede ver a través de los objetos*/ }
    }
}
