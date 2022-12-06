namespace TipiCustom {
    public readonly struct Litri {
        private readonly double v;

        public Litri(double v) {
            if (v is < 0) { throw new ArgumentOutOfRangeException(nameof(v)); }
            this.v = v;
        }

        public static implicit operator Litri(double v) { return new Litri(v); }
        public static implicit operator double(Litri litri) { return litri.v; }
    }
}
