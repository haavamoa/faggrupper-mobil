namespace Friends.Models
{
    public  struct Postcode
    {
        public long? Integer;
        public string String;

        public static implicit operator Postcode(long Integer) => new Postcode { Integer = Integer };
        public static implicit operator Postcode(string String) => new Postcode { String = String };
    }
}