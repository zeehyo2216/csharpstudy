using System;

namespace HoleAdapter
{
    public interface IRound
    {
        int getRadius();

    

        //string fits(RoundPeg roundpeg);
    }

    public class RoundHole : IRound
    {
        public int radius;

        public RoundHole(int radius)
        {
            this.radius = radius;
        }

        public int getRadius()
        {
            return radius;
        }

        public string fits(RoundPeg roundpeg)
        {
            if (roundpeg.radius == radius) { return "True"; }
            else { return "False"; }
        }
    }
    public class RoundPeg
    {
        public int radius;

        public RoundPeg(int radius)
        {
            this.radius = radius;
        }

        public int getRadius()
        {
            return radius;
        }
    }
    public class SquarePeg
    {
        public int width;

        public SquarePeg(int width)
        {
            this.width = width;
        }

        public int getWidth()
        {
            return width;
        }
    }

    class RAdapter : IRound
    {
        private readonly SquarePeg _squarepeg;

        public RoundPeg peg;

        public RAdapter(SquarePeg squarepeg)
        {
            this._squarepeg = squarepeg;
        }
        public int getRadius()
        {
            int num = (int)(_squarepeg.getWidth() * Math.Sqrt(2.0) / 2);
            this.peg = new RoundPeg(num);
            return num;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SquarePeg squarePeg = new SquarePeg(10);
            RoundHole roundhole = new RoundHole(6);
            RoundPeg roundpeg = new RoundPeg(6);

            RAdapter target = new RAdapter(squarePeg);

            Console.WriteLine("Roundhole: " + roundhole.getRadius());
            Console.WriteLine("T or F: " + roundhole.fits(roundpeg));
            Console.WriteLine("Target:  " + target.getRadius());
            Console.WriteLine("T or F: " + roundhole.fits(target.peg));
        }
    }


}
