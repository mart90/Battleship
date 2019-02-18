namespace MBRD.Boats
{
    public interface IBoat
    {
        int length { get; set; }
        string frontImage { get; set; }
        string midImage { get; set; }
        string backImage { get; set; }

        void Hit();
    }
}
