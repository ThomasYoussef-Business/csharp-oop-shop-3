namespace TipiCustom {
    public readonly struct Litri {
        private readonly double v;

        public Litri(double v) {
            if (v is < 0) { throw new ArgumentOutOfRangeException(nameof(v)); }
            this.v = v;
        }

        public static implicit operator Litri(double v) { return new Litri(v); }
        public static implicit operator double(Litri litri) { return litri.v; }
        public override string ToString() {
            return v.ToString();
        }
    }

    public readonly struct pH {
        private readonly double v;

        public pH(double v) {
            if (v is < 0 or > 14) { throw new ArgumentOutOfRangeException(nameof(v)); }
            this.v = v;
        }

        public static implicit operator pH(double v) { return new pH(v); }
        public static implicit operator double(pH litri) { return litri.v; }
        public override string ToString() {
            return v.ToString();
        }
    }
}
