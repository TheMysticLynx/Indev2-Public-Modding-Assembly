namespace Utility
{
    public static class ExtraMath
    {
        public static int Modulo(this int x, int m) {
            int r = x%m;
            return r<0 ? r+m : r;
        }
    }
}