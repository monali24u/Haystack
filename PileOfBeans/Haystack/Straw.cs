
namespace PileOfBeans.Haystack
{
    public class Straw
    {
        public decimal LengthInCm { get; private set; }
        public int ColorRed { get; private set; }
        public int ColorGreen { get; private set; }
        public int ColorBlue { get; private set; }

        public Straw(
            decimal lengthInCm,
            int colorRed,
            int colorGreen,
            int colorBlue)
        {
            LengthInCm = lengthInCm;
            ColorRed = colorRed;
            ColorGreen = colorGreen;
            ColorBlue = colorBlue;
        }

        public override bool Equals(object obj)
        {
            Straw tobj = obj as Straw;
            return tobj != null && tobj.LengthInCm == this.LengthInCm && tobj.ColorRed == this.ColorRed && tobj.ColorGreen == this.ColorGreen && tobj.ColorBlue == this.ColorBlue;
        }

        public override int GetHashCode()
        {
            return this.LengthInCm.GetHashCode() ^ this.ColorRed.GetHashCode() ^ this.ColorGreen.GetHashCode() ^ this.ColorBlue.GetHashCode();
        }
    }
}
