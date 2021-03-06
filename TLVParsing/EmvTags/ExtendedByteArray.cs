using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TLVParsing.EmvTags
{
    [Serializable]
    public class ExtendedByteArray : ISerializable
    {
        private byte[] _value;

        [XmlIgnore]
        public byte[] Bytes { get => _value; set => _value = value; }

        [XmlText]
        public string Hex { get => _value.ByteArrayToHexString(); set => _value = value.HexStringToByteArray(); }

        [XmlIgnore]
        public string Ascii { get => _value.ByteArrayToAsciiString(); set => _value = value.AsciiStringToByteArray(); }

        [XmlIgnore]
        public int Length { get => _value.Length; set { } }

        public override string ToString() => Hex;

        public ExtendedByteArray() { }
        public ExtendedByteArray(string val) => Hex = val;
        public ExtendedByteArray(byte val) => Bytes = new byte[] { val };
        public ExtendedByteArray(byte[] val) => Bytes = val;

        public static implicit operator ExtendedByteArray(string val) => new ExtendedByteArray(val);
        public static implicit operator ExtendedByteArray(byte val) => new ExtendedByteArray(val);
        public static implicit operator ExtendedByteArray(byte[] val) => new ExtendedByteArray(val);

        public override bool Equals(object value)
        {
            return Equals(value as ExtendedByteArray);
        }

        public bool Equals(ExtendedByteArray value)
        {
            // Is null?
            if (Object.ReferenceEquals(null, value)) return false;

            // Is the same object?
            if (Object.ReferenceEquals(this, value)) return true;

            return IsEqual(value);
        }

        private bool IsEqual(ExtendedByteArray value)
        {
            return _value.SequenceEqual(value.Bytes);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Hex", Hex);
        }

        public static bool operator ==(ExtendedByteArray lhs, ExtendedByteArray rhs)
        {
            // Check for null on left side.
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ExtendedByteArray lhs, ExtendedByteArray rhs)
        {
            return !(lhs == rhs);
        }

    }
}
